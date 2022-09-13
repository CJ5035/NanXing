using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NanXingData_WMS.Dao
{
    public partial class Model_Data : DbContext
    {
        public Model_Data()
            : base("name=Model_Data")
        {
        }
        public Model_Data(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<AGVAlarmLog> AGVAlarmLog { get; set; }
        public virtual DbSet<AGVMissionInfo> AGVMissionInfo { get; set; }
        public virtual DbSet<AGVMissionInfo_Floor> AGVMissionInfo_Floor { get; set; }
        public virtual DbSet<Configs> Configs { get; set; }
        public virtual DbSet<CRMPlanHead> CRMPlanHead { get; set; }
        public virtual DbSet<CRMPlanList> CRMPlanList { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENT { get; set; }
        public virtual DbSet<Depts> Depts { get; set; }
        public virtual DbSet<DeviceStatesInfo> DeviceStatesInfo { get; set; }
        public virtual DbSet<FaHuoPlan> FaHuoPlan { get; set; }
        public virtual DbSet<ItemInfo> ItemInfo { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Onlines> Onlines { get; set; }
        public virtual DbSet<Powers> Powers { get; set; }
        public virtual DbSet<PrdMissionSL> PrdMissionSL { get; set; }
        public virtual DbSet<ProcessClasses> ProcessClasses { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<Productiondt> Productiondt { get; set; }
        public virtual DbSet<ProductOrderheaders> ProductOrderheaders { get; set; }
        public virtual DbSet<ProductOrderlists> ProductOrderlists { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SERIALNO> SERIALNO { get; set; }
        public virtual DbSet<STAFF> STAFF { get; set; }
        public virtual DbSet<StockPlan> StockPlan { get; set; }
        public virtual DbSet<SYSPARM> SYSPARM { get; set; }
        public virtual DbSet<TelenClients> TelenClients { get; set; }
        public virtual DbSet<TiShengJiState> TiShengJiState { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }
        public virtual DbSet<TouLiaoRecord> TouLiaoRecord { get; set; }
        public virtual DbSet<TrayPro> TrayPro { get; set; }
        public virtual DbSet<TrayState> TrayState { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WareArea> WareArea { get; set; }
        public virtual DbSet<WareAreaClass> WareAreaClass { get; set; }
        public virtual DbSet<WareHouse> WareHouse { get; set; }
        public virtual DbSet<WareLocation> WareLocation { get; set; }
        public virtual DbSet<WorkShopProcesses> WorkShopProcesses { get; set; }

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

            modelBuilder.Entity<CRMPlanHead>()
                .HasMany(e => e.CRMPlanList)
                .WithRequired(e => e.CRMPlanHead)
                .HasForeignKey(e => e.CRMPlanHead_Id);

            modelBuilder.Entity<CRMPlanList>()
                .HasMany(e => e.ProductOrderlists)
                .WithOptional(e => e.CRMPlanList)
                .HasForeignKey(e => e.CRMPlanList_ID);

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

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.PrdMissionNo)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.WORKGRP)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.ItemNo)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.QCStandard)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.Client)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.ORDERNO)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.CHECKMAN)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.PackMan)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.COLOR)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.LOTNO)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.GRADE)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.CASENO)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.LabelName)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.BoxLblName)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.OPERATOR)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.KaiDan)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.Auditer)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.PiZhun)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE1)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE2)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE3)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE4)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE5)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE6)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE7)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE8)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE9)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE10)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE11)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE12)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE13)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE14)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE15)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE16)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE17)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE18)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE19)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE20)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE21)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE22)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE23)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE24)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE25)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE26)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE27)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE28)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE29)
                .IsUnicode(false);

            modelBuilder.Entity<PrdMissionSL>()
                .Property(e => e.RESERVE30)
                .IsUnicode(false);

            modelBuilder.Entity<ProcessClasses>()
                .HasMany(e => e.WorkShopProcesses)
                .WithRequired(e => e.ProcessClasses)
                .HasForeignKey(e => e.ProcessClass_Id);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.ProSn)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.WORKGRP)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.PrdMissionNo)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.ItemNo)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.QCStandard)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.Client)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.ORDERNO)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.CHECKMAN)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.PackMan)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.COLOR)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.LOTNO)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.GRADE)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.WEIGHT)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.CASENO)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.OPERATOR)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE1)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE2)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE3)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE4)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE5)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE6)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE7)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE8)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE9)
                .IsUnicode(false);

            modelBuilder.Entity<Productiondt>()
                .Property(e => e.RESERVE10)
                .IsUnicode(false);

            modelBuilder.Entity<ProductOrderheaders>()
                .HasMany(e => e.ProductOrderlists)
                .WithOptional(e => e.ProductOrderheaders)
                .HasForeignKey(e => e.ProductOrderheader_ID);

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
