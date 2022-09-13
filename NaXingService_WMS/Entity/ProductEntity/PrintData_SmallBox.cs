﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingService_WMS.Entity.ProductEntity
{
    public class PrintData_SmallBox
    {
        public int ID { get; set; }
        public string PlanOrderNo { get; set; }
        public string PlanOrder_XuHao { get; set; }
        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public string Spec { get; set; }
        public string Unit { get; set; }
        public string BoxNo { get; set; }
        public string BoxName { get; set; }
        public string ClientName { get; set; }

        public decimal PcCount { get; set; }
        public decimal NoWorkCount { get; set; }
        public decimal NoWorkCount_OrderHeader { get; set; }
        public string Priority { get; set; }
        public string Workshops { get; set; }
        public DateTime PlanDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ProductState { get; set; }
        public string Remark { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrl_All { get; set; }
    }
}
