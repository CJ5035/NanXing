using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NanXingData_WMS.Dao
{
    public partial class Model_Data : DbContext
    {
        private string CurrentConnString = "Password=tzhuser;Persist Security Info=True;User ID=tzhuser;Initial catalog=NanXingGuoRen_CangKu_New;Data Source=127.0.0.1";
        //public Model_Data(string connectionString) : base(connectionString)
        //{
        //}
        //public Model_Data()
        //{

        //}
        //public DbContext SetCurrentConnString(string conn)
        //{
        //    CurrentConnString = conn;
        //    return this;
        //}

        public virtual DbSet<pbcatedt> pbcatedt { get; set; }
        public virtual DbSet<pbcatfmt> pbcatfmt { get; set; }
        public virtual DbSet<pbcatvld> pbcatvld { get; set; }
        public virtual DbSet<pchao> pchao { get; set; }
        public virtual DbSet<AGVAlarmLog> AGVAlarmLog { get; set; }
        public virtual DbSet<AGVMissionInfo> AGVMissionInfo { get; set; }
        public virtual DbSet<AGVMissionInfo_Floor> AGVMissionInfo_Floor { get; set; }
        public virtual DbSet<Configs> Configs { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENT { get; set; }
        public virtual DbSet<Depts> Depts { get; set; }
        public virtual DbSet<DeviceStatesInfo> DeviceStatesInfo { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Onlines> Onlines { get; set; }
        public virtual DbSet<Powers> Powers { get; set; }
        //public virtual DbSet<Production> Production { get; set; }
        //public virtual DbSet<ProductOrderheaders> ProductOrderheaders { get; set; }
        //public virtual DbSet<ProductOrderlists> ProductOrderlists { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SERIALNO> SERIALNO { get; set; }
        public virtual DbSet<STAFF> STAFF { get; set; }
        public virtual DbSet<StockPlan> StockPlan { get; set; }
        public virtual DbSet<SYSPARM> SYSPARM { get; set; }
        public virtual DbSet<TelenClients> TelenClients { get; set; }
        public virtual DbSet<TiShengJiState> TiShengJiState { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }
        public virtual DbSet<TrayPro> TrayPro { get; set; }
        public virtual DbSet<TrayState> TrayState { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WareArea> WareArea { get; set; }
        public virtual DbSet<WareAreaClass> WareAreaClass { get; set; }
        public virtual DbSet<WareHouse> WareHouse { get; set; }
        public virtual DbSet<WareLocation> WareLocation { get; set; }
        //public virtual DbSet<CRMPlanHead> CRMPlanHead { get; set; }
        //public virtual DbSet<CRMPlanList> CRMPlanList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AGVMissionInfo>()
                .Property(e => e.SendState)
                .IsUnicode(false);

            modelBuilder.Entity<AGVMissionInfo>()
                .Property(e => e.StateMsg)
                .IsUnicode(false);

            modelBuilder.Entity<AGVMissionInfo>()
                .Property(e => e.RunState)
                .IsUnicode(false);

            modelBuilder.Entity<AGVMissionInfo_Floor>()
                .Property(e => e.SendState)
                .IsUnicode(false);

            modelBuilder.Entity<AGVMissionInfo_Floor>()
                .Property(e => e.StateMsg)
                .IsUnicode(false);

            modelBuilder.Entity<AGVMissionInfo_Floor>()
                .Property(e => e.RunState)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.syscode)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.principal)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e._abstract)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.STAFF)
                .WithRequired(e => e.DEPARTMENT1)
                .HasForeignKey(e => e.department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Depts>()
                .HasMany(e => e.Depts1)
                .WithOptional(e => e.Depts2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<Depts>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Depts)
                .HasForeignKey(e => e.DeptID);

            modelBuilder.Entity<Menus>()
                .HasMany(e => e.Menus1)
                .WithOptional(e => e.Menus2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<Powers>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.Powers)
                .HasForeignKey(e => e.ViewPowerID);

            modelBuilder.Entity<Powers>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Powers)
                .Map(m => m.ToTable("RolePowers").MapLeftKey("PowerID").MapRightKey("RoleID"));

            //modelBuilder.Entity<ProductOrderheaders>()
            //    .Property(e => e.mergeCells)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ProductOrderheaders>()
            //    .Property(e => e.mergeCellsValue)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ProductOrderheaders>()
            //    .HasMany(e => e.ProductOrderlists)
            //    .WithOptional(e => e.ProductOrderheaders)
            //    .HasForeignKey(e => e.ProductOrderheader_ID);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("RoleUsers").MapLeftKey("RoleID").MapRightKey("UserID"));

            modelBuilder.Entity<SERIALNO>()
                .Property(e => e.SERIALNAME)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.idcard)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.edured)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.telephone)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.department)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.authorgrp)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.workcls)
                .HasPrecision(6, 2);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.bank)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.account)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.timepay)
                .HasPrecision(6, 2);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.basepay)
                .HasPrecision(6, 2);

            modelBuilder.Entity<STAFF>()
                .Property(e => e._abstract)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<SYSPARM>()
                .Property(e => e.paraitem)
                .IsUnicode(false);

            modelBuilder.Entity<SYSPARM>()
                .Property(e => e.paravalue)
                .IsUnicode(false);

            modelBuilder.Entity<SYSPARM>()
                .Property(e => e.ItemCls)
                .IsUnicode(false);

            modelBuilder.Entity<SYSPARM>()
                .Property(e => e.Reserve1)
                .IsUnicode(false);

            modelBuilder.Entity<SYSPARM>()
                .Property(e => e.Reserve2)
                .IsUnicode(false);

            modelBuilder.Entity<SYSPARM>()
                .Property(e => e.Reserve3)
                .IsUnicode(false);

            modelBuilder.Entity<SYSPARM>()
                .Property(e => e.Reserve4)
                .IsUnicode(false);

            modelBuilder.Entity<Titles>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Titles)
                .Map(m => m.ToTable("TitleUsers").MapLeftKey("TitleID").MapRightKey("UserID"));

            modelBuilder.Entity<TrayState>()
                .Property(e => e.boxName)
                .IsFixedLength();

            modelBuilder.Entity<TrayState>()
                .HasMany(e => e.TrayPro)
                .WithRequired(e => e.TrayState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Onlines)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.WareLocation)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.header_ID);

            modelBuilder.Entity<WareArea>()
                .HasMany(e => e.WareLocation)
                .WithOptional(e => e.WareArea)
                .HasForeignKey(e => e.WareArea_ID);

            modelBuilder.Entity<WareAreaClass>()
                .HasMany(e => e.WareArea)
                .WithOptional(e => e.WareAreaClass)
                .HasForeignKey(e => e.War_ID);

            modelBuilder.Entity<WareHouse>()
                .HasMany(e => e.WareArea)
                .WithOptional(e => e.WareHouse)
                .HasForeignKey(e => e.WareHouse_ID);

            modelBuilder.Entity<WareLocation>()
                .HasMany(e => e.TrayState)
                .WithOptional(e => e.WareLocation)
                .HasForeignKey(e => e.WareLocation_ID);

            
        }
    }
}
