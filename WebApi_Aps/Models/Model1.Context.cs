﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCSApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NanXingGuoRen_WMSEntities1 : DbContext
    {
        public NanXingGuoRen_WMSEntities1()
            : base("name=NanXingGuoRen_WMSEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AGVMissionInfo> AGVMissionInfo { get; set; }
        public virtual DbSet<Configs> Configs { get; set; }
        public virtual DbSet<Depts> Depts { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Onlines> Onlines { get; set; }
        public virtual DbSet<Powers> Powers { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<ProductOrderheaders> ProductOrderheaders { get; set; }
        public virtual DbSet<ProductOrderlists> ProductOrderlists { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TelenClients> TelenClients { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }
        public virtual DbSet<TrayPro> TrayPro { get; set; }
        public virtual DbSet<TrayState> TrayState { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WareArea> WareArea { get; set; }
        public virtual DbSet<WareAreaClass> WareAreaClass { get; set; }
        public virtual DbSet<WareHouse> WareHouse { get; set; }
        public virtual DbSet<WareLocation> WareLocation { get; set; }
        public virtual DbSet<StockPlan> StockPlan { get; set; }
        public virtual DbSet<DeviceStatesInfo> DeviceStatesInfo { get; set; }
        public virtual DbSet<AGVAlarmLog> AGVAlarmLog { get; set; }
    }
}
