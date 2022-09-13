﻿using NanXingData_WMS.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingService_WMS.Entity.StockEntity
{
    public class ProPlanOrderIndexData
    {

        public int ID { get; set; }

        public string PlanOrder_XuHao { get; set; }

        public string Chejianclass { get; set; }

        public string ItemName { get; set; }

        public string Spec { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? PlanProDate { get; set; }
        public string PlanProTime { get; set; }

        public DateTime? PlanDate { get; set; }

        public string PlanTime { get; set; }

        public decimal? PcCount { get; set; }
        public string Unit { get; set; }
        public string BoxNo { get; set; }

        public string BoxName { get; set; }

        public string BoxRemark { get; set; }
        public string JingBanRen { get; set; }

        public string PlanProRen { get; set; }

        public DateTime? PushProDate { get; set; }


        public string PlanOrder_State { get; set; }

        public string ProListNo { get; set; }
        public List<ProductOrderlists> ProductOrderlists { get; set; }

    }
}
