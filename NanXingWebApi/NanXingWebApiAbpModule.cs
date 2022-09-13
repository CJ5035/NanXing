using Microsoft.OpenApi.Models;
using NanXingApplication;
using NanXingModel.Models;
using NanXingService.IService;
using NanXingService.Services;
using Volo.Abp;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace NanXingWebApi
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpDddApplicationModule),
        //typeof(AbpDddDomainModule),
        //typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(NanXingApplicationModule)
        )]
    public class NanXingWebApiAbpModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.AddTransient<IWareHouseService, WareHouseService>();
            //context.Services.AddControllers();
            context.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NanXingWebApiAbp", Version = "v1" });
            });
            //context.Services.AddAbpDbContext<NanXingModelContext>(options =>
            //{
            //    options.AddDefaultRepositories(includeAllEntities: true);
            //});

            //Configure<AbpDbContextOptions>(options =>
            //{
            //    options.UseSqlServer();
            //});
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NanXingWebApiAbp v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
