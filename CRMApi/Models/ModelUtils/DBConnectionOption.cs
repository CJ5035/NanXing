using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.ModelUtils
{
    public class DBConnectionOption
    {
        public string MainConnectionString { get; set; }
        public List<string> SlaveConnectionStringList { get; set; }
    }
}
