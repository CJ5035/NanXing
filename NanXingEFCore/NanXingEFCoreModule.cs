using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore;
using NanXingModel;
using Microsoft.Extensions.DependencyInjection;
using NanXingModel.Models;
using NanXingEFCore.Context;

namespace NanXingEFCore
{
    [DependsOn(
       typeof(AbpEntityFrameworkCoreModule),
         typeof(NanXingModelModule)
       )]
    public class NanXingEFCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<NanXingModelContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}