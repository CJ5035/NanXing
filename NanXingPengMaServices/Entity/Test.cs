using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingWMS_old.Entity
{
    class Test
    {
        public Test()
        {
        }

        public Test(string orderId)
        {
            this.orderId = orderId;
        }

        public string orderId { get; set; }
    }
}
