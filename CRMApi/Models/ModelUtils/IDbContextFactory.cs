using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.ModelUtils
{
    public interface IDbContextFactory
    {
        public DbContext GetMainOrSlave(ReadWriteEnum readWriteEnum);
    }
}
