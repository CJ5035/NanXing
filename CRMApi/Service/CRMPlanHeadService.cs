using CRMApi.Interface;
using CRMApi.Models.ModelUtils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Service
{
    public class CRMPlanHeadService:BaseService, ICRMPlanHeadService
    {
        public CRMPlanHeadService(DbContextFactory contextFactory) :base(contextFactory)
        {
            //_ContextFactory = contextFactory;
        }
    }
}
