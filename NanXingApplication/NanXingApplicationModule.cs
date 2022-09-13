using NanXingEFCore;
using Volo.Abp.Application;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace NanXingApplication
{
    [DependsOn(
        typeof(AbpDddApplicationModule)
        //,typeof(NanXingEFCoreModule)
        )]
    public class NanXingApplicationModule:AbpModule
    {

    }
}