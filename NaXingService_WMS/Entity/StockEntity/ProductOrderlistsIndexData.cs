using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingService_WMS.Entity.StockEntity
{
    public class ProductOrderlistsIndexData
    {
        public int ID { get; set; }
        //品名 交付日期 规格 单位 计划数 欠数 已生产数 批号 箱号 纸箱 计划日期 计划时间 紧急程度 备注
        public string ProductOrder_XuHao { get; set; }
        public string ItemName { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Spec { get; set; }
       
        public string Unit { get; set; }

        public decimal? PcCount { get; set; }

        public decimal? NoWorkCount { get; set; }
        public decimal? ProCount { get; set; }

        public string BatchNo { get; set; }
        public string BoxNo { get; set; }
        public string BoxName { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? PlanProDate { get; set; }
        public string PlanTime { get; set; }
        public string PlanProTime { get; set; }

        public string Priority { get; set; }
        public string ProductState { get; set; }

        public string Remark { get; set; }
    }
}
