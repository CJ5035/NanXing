using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace NanXingModel.Models
{
    public partial class SensorDatum:Entity<int>
    {
        //public int Id { get; set; }
        public string? Floor { get; set; }
        public DateTime? RefleshTime { get; set; }
        public float Ammeter1 { get; set; }
        public float Ammeter2 { get; set; }
        public float Ammeter3 { get; set; }
        public float Humidity { get; set; }
        public float Temperature { get; set; }
        public float Noise { get; set; }
        public float ToxicGas { get; set; }
        public float StackTemp1 { get; set; }
        public float ChamberTemp1 { get; set; }
        public float StackTemp2 { get; set; }
        public float ChamberTemp2 { get; set; }
        public float StackTemp3 { get; set; }
        public float ChamberTemp3 { get; set; }
        public float? DieselOilFlow { get; set; }
    }
}
