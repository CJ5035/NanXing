using CRMApi.Filter;
using CRMApi.Interface;
using CRMApi.Models.Entity;
using CRMApi.Models.ModelUtils;
using CRMApi.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<DbContext, NanXingGuoRen_Context>();
            //可以获取DbContext 实例的集合；

            services.AddTransient<IDbContextFactory, DbContextFactory>();
            services.AddTransient<LoginService, LoginService>();

            services.AddTransient<IBaseService, BaseService>();
            services.Configure<DBConnectionOption>(Configuration.GetSection("ConnectionStrings"));//注入多个链接
                                                                                                  //services.AddTransient<CRMPlanHeadService, CRMPlanHeadService>();
                                                                                                  //services.AddScoped<CRMPlanHeadService>();

            //添加jwt验证：
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,//是否验证Issuer
                        ValidateAudience = false,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = "yourdomain.com",//Audience
                        ValidIssuer = "yourdomain.com",//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))//拿到SecurityKey
                    };
                });

            //跨域
            services.AddCors(options =>
            {
                options.AddPolicy("cors", builder =>
                {
                    builder.WithOrigins("http://localhost", "http://c.example.com");
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    //.AllowCredentials();
                });
            });
            //"http://a.example.com", "http://c.example.com" 代表着允许访问的域，就好像给这个域开放了一个权限，允许访问的权限，可以写多个逗号分隔
            //AllowAnyMethod允许跨域策略允许所有的方法：GET/POST/PUT/DELETE 等方法  如果进行限制需要 AllowAnyMethod("GET","POST") 这样来进行访问方法的限制
            //AllowAnyHeader允许任何的Header头部标题    有关头部标题如果不设置就不会进行限制
            //AllowAnyOrigin 允许任何来源
            //AllowCredentials 设置凭据来源


            services.AddControllers();

            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRMApi", Version = "v1.0.0" });
                //添加读取注释服务
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "CRMApi.xml");
                c.IncludeXmlComments(xmlPath,true);
                //添加对控制器的标签
                c.DocumentFilter<SwaggerDocTag>();

                #region 启用swagger验证功能

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "",

                });
                #endregion

                //c.OperationFilter<SwaggerOperationFilter>();
                c.OperationFilter<AuthResponsesOperationFilter>();
            });
           

            
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
            
        //    services.AddMvc();
        //}


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IHostApplicationLifetime lifetime)
        {
            //启用跨域
            app.UseRouting();
            app.UseCors("cors"); // 加上这一句

            //添加jwt验证
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //启用中间件服务生成Swagger作为JSON终结点
                app.UseSwagger();
                //启用中间件服务对swagger-ui，指定Swagger JSON终结点
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger"); //swagger为补充的路由
            app.UseRewriter(option);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            

            lifetime.ApplicationStarted.Register(OnAppStarted);

            //Task task = Task.Factory.StartNew(()=> OnAppStarted());
        }

        public void OnAppStarted()
        {
            //Thread.Sleep(10000);
            var url = Configuration[WebHostDefaults.ServerUrlsKey];

            var warm = url.Split(';')[0] + "/CRM/Get";

            new HttpClient().GetAsync(warm).Wait();
        }
    }
}
