﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace NanXingModel
{
    [DependsOn(
        typeof(AbpDddDomainModule)
        )]
    public class NanXingModelModule:AbpModule
    {
    }
}
