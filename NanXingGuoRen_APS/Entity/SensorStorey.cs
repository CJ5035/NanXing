using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingGuoRen_APS.Entity
{
    public class SensorStorey
    {
        public int ID { get; set; }
        public string position { get; set; }
        public DateTime RefleshTime { get; set; }
        public double Ammeter1 {get;set;}
        public double Ammeter2 {get;set;}
        public double Ammeter3 {get;set;}
        public double Humidity {get;set;}
        public double Temperature {get;set;}
        public double Noise {get;set;}
        public double ToxicGas {get;set;}
        public double Thermostat1 {get;set;}
        public double Thermostat2 {get;set;}
        public double Thermostat3 {get;set;}
        public double Thermostat4 {get;set;}
        public double Thermostat5 {get;set;}
        public double Thermostat6 {get;set;}
        public double DieselOilFlow { get; set; }
    }
}