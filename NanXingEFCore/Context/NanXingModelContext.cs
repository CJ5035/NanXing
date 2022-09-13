using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Data;
using NanXingModel.Models;

namespace NanXingEFCore.Context
{
    [ConnectionStringName("Default")]
    public partial class NanXingModelContext 
        //:DbContext
        : AbpDbContext<NanXingModelContext>
    {
        //public NanXingModelContext()            
        //{
        //}

        public NanXingModelContext(DbContextOptions<NanXingModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgvalarmLog> AgvalarmLogs { get; set; } = null!;
        public virtual DbSet<AgvmissionInfo> AgvmissionInfos { get; set; } = null!;
        public virtual DbSet<AgvmissionInfoFloor> AgvmissionInfoFloors { get; set; } = null!;
        public virtual DbSet<Config> Configs { get; set; } = null!;
        public virtual DbSet<Crmfile> Crmfiles { get; set; } = null!;
        public virtual DbSet<CrmplanHead> CrmplanHeads { get; set; } = null!;
        public virtual DbSet<CrmplanList> CrmplanLists { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Dept> Depts { get; set; } = null!;
        public virtual DbSet<DeviceStatesInfo> DeviceStatesInfos { get; set; } = null!;
        public virtual DbSet<FaHuoPlan> FaHuoPlans { get; set; } = null!;
        public virtual DbSet<ItemInfo> ItemInfos { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<NumSeq> NumSeqs { get; set; } = null!;
        public virtual DbSet<Online> Onlines { get; set; } = null!;
        public virtual DbSet<Pbcatcol> Pbcatcols { get; set; } = null!;
        public virtual DbSet<Pbcatedt> Pbcatedts { get; set; } = null!;
        public virtual DbSet<Pbcatfmt> Pbcatfmts { get; set; } = null!;
        public virtual DbSet<Pbcattbl> Pbcattbls { get; set; } = null!;
        public virtual DbSet<Pbcatvld> Pbcatvlds { get; set; } = null!;
        public virtual DbSet<Pchao> Pchaos { get; set; } = null!;
        public virtual DbSet<Power> Powers { get; set; } = null!;
        public virtual DbSet<PrdMissionSl> PrdMissionSls { get; set; } = null!;
        public virtual DbSet<ProcessClass> ProcessClasses { get; set; } = null!;
        public virtual DbSet<ProductOrderheader> ProductOrderheaders { get; set; } = null!;
        public virtual DbSet<ProductOrderlist> ProductOrderlists { get; set; } = null!;
        public virtual DbSet<Production> Productions { get; set; } = null!;
        public virtual DbSet<Productiondt> Productiondts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SensorDatum> SensorData { get; set; } = null!;
        public virtual DbSet<Serialno> Serialnos { get; set; } = null!;
        public virtual DbSet<StockPlan> StockPlans { get; set; } = null!;
        public virtual DbSet<Sysparm> Sysparms { get; set; } = null!;
        public virtual DbSet<TelenClient> TelenClients { get; set; } = null!;
        public virtual DbSet<TiShengJiInfo> TiShengJiInfos { get; set; } = null!;
        public virtual DbSet<TiShengJiRunRecord> TiShengJiRunRecords { get; set; } = null!;
        public virtual DbSet<TiShengJiState> TiShengJiStates { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;
        public virtual DbSet<TouLiaoRecord> TouLiaoRecords { get; set; } = null!;
        public virtual DbSet<TrayPro> TrayPros { get; set; } = null!;
        public virtual DbSet<TrayState> TrayStates { get; set; } = null!;
        public virtual DbSet<TrayWeightRecord> TrayWeightRecords { get; set; } = null!;
        public virtual DbSet<UpdateApp> UpdateApps { get; set; } = null!;
        public virtual DbSet<UpdateFile> UpdateFiles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WareArea> WareAreas { get; set; } = null!;
        public virtual DbSet<WareAreaClass> WareAreaClasses { get; set; } = null!;
        public virtual DbSet<WareHouse> WareHouses { get; set; } = null!;
        public virtual DbSet<WareLocation> WareLocations { get; set; } = null!;
        public virtual DbSet<WeiXinSetting> WeiXinSettings { get; set; } = null!;
        public virtual DbSet<WorkShopProcess> WorkShopProcesses { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=NanXingGuoRen_WMS;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgvalarmLog>(entity =>
            {
                entity.ToTable("AGVAlarmLog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlarmDate)
                    .HasColumnType("datetime")
                    .HasColumnName("alarmDate");

                entity.Property(e => e.AlarmDesc)
                    .HasMaxLength(50)
                    .HasColumnName("alarmDesc");

                entity.Property(e => e.AlarmGrade).HasColumnName("alarmGrade");

                entity.Property(e => e.AlarmReadFlag).HasColumnName("alarmReadFlag");

                entity.Property(e => e.AlarmSource)
                    .HasMaxLength(50)
                    .HasColumnName("alarmSource");

                entity.Property(e => e.AlarmType).HasColumnName("alarmType");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.ChannelDeviceId)
                    .HasMaxLength(50)
                    .HasColumnName("channelDeviceId");

                entity.Property(e => e.ChannelName)
                    .HasMaxLength(256)
                    .HasColumnName("channelName");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .HasColumnName("deviceName");

                entity.Property(e => e.DeviceNum)
                    .HasMaxLength(50)
                    .HasColumnName("deviceNum");

                entity.Property(e => e.RecTime)
                    .HasColumnType("datetime")
                    .HasColumnName("recTime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AgvmissionInfo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_AGVMISSIONINFO")
                    .IsClustered(false);

                entity.ToTable("AGVMissionInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgvcarId)
                    .HasMaxLength(20)
                    .HasColumnName("AGVCarId");

                entity.Property(e => e.EndLocation).HasMaxLength(50);

                entity.Property(e => e.EndPosition).HasMaxLength(50);

                entity.Property(e => e.Mark).HasMaxLength(50);

                entity.Property(e => e.MissionFloorId).HasColumnName("MissionFloor_ID");

                entity.Property(e => e.MissionNo).HasMaxLength(20);

                entity.Property(e => e.ModelProcessCode).HasMaxLength(20);

                entity.Property(e => e.OrderGroupId).HasMaxLength(255);

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.RunState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SendMsg).HasMaxLength(100);

                entity.Property(e => e.SendState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartLocation).HasMaxLength(50);

                entity.Property(e => e.StartPosition).HasMaxLength(50);

                entity.Property(e => e.StateMsg)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StateTime).HasColumnType("datetime");

                entity.Property(e => e.StockPlanId).HasColumnName("StockPlan_ID");

                entity.Property(e => e.TrayNo).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("userId");

                entity.Property(e => e.Whname)
                    .HasMaxLength(20)
                    .HasColumnName("WHName");

                entity.HasOne(d => d.MissionFloor)
                    .WithMany(p => p.AgvmissionInfos)
                    .HasForeignKey(d => d.MissionFloorId)
                    .HasConstraintName("FK_dbo.AGVMissionInfo_dbo.AGVMissionInfo_Floor_MissionFloor_ID");
            });

            modelBuilder.Entity<AgvmissionInfoFloor>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("AGVMissionInfo_Floor");

                entity.HasIndex(e => e.MissionFloorId, "IX_MissionFloor_ID");

                entity.HasIndex(e => e.TiShengJiRecordId, "IX_TiShengJiRecord_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgvcarId)
                    .HasMaxLength(20)
                    .HasColumnName("AGVCarId");

                entity.Property(e => e.EndLocation).HasMaxLength(50);

                entity.Property(e => e.EndPosition).HasMaxLength(50);

                entity.Property(e => e.Mark).HasMaxLength(50);

                entity.Property(e => e.MissionFloorId).HasColumnName("MissionFloor_ID");

                entity.Property(e => e.MissionNo).HasMaxLength(20);

                entity.Property(e => e.ModelProcessCode).HasMaxLength(20);

                entity.Property(e => e.OrderGroupId).HasMaxLength(255);

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.RunState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SendMsg).HasMaxLength(50);

                entity.Property(e => e.SendState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartLocation).HasMaxLength(50);

                entity.Property(e => e.StartPosition).HasMaxLength(50);

                entity.Property(e => e.StateMsg)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StateTime).HasColumnType("datetime");

                entity.Property(e => e.StockPlanId).HasColumnName("StockPlan_ID");

                entity.Property(e => e.TiShengJiRecordId).HasColumnName("TiShengJiRecord_ID");

                entity.Property(e => e.TrayNo).HasMaxLength(50);

                entity.Property(e => e.TsjName)
                    .HasMaxLength(20)
                    .HasColumnName("TSJ_Name");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("userId");

                entity.HasOne(d => d.TiShengJiRecord)
                    .WithMany(p => p.AgvmissionInfoFloors)
                    .HasForeignKey(d => d.TiShengJiRecordId)
                    .HasConstraintName("FK_dbo.AGVMissionInfo_Floor_dbo.TiShengJiRunRecord_TiShengJiRecord_ID");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConfigKey).HasMaxLength(50);

                entity.Property(e => e.ConfigValue).HasMaxLength(4000);

                entity.Property(e => e.Remark).HasMaxLength(500);
            });

            modelBuilder.Entity<Crmfile>(entity =>
            {
                entity.ToTable("CRMFiles");

                entity.HasIndex(e => e.Crmid, "IX_CRMID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CrmfilePath)
                    .HasMaxLength(1000)
                    .HasColumnName("CRMFilePath");

                entity.Property(e => e.Crmid)
                    .HasMaxLength(1000)
                    .HasColumnName("CRMID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<CrmplanHead>(entity =>
            {
                entity.ToTable("CRMPlanHead");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicantDept).HasMaxLength(1000);

                entity.Property(e => e.ApplicantId).HasMaxLength(1000);

                entity.Property(e => e.ApplicantJob).HasMaxLength(1000);

                entity.Property(e => e.ApplicantName).HasMaxLength(1000);

                entity.Property(e => e.ApplicantPhone).HasMaxLength(1000);

                entity.Property(e => e.ApplyTime).HasColumnType("datetime");

                entity.Property(e => e.ClientName).HasMaxLength(1000);

                entity.Property(e => e.ClientNo).HasMaxLength(1000);

                entity.Property(e => e.CrmapplyNo)
                    .HasMaxLength(1000)
                    .HasColumnName("CRMApplyNo");

                entity.Property(e => e.MakeClass).HasMaxLength(20);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderSource).HasMaxLength(1000);

                entity.Property(e => e.Photo).HasMaxLength(4000);

                entity.Property(e => e.Remark).HasMaxLength(3000);

                entity.Property(e => e.Reserve1).HasMaxLength(1000);

                entity.Property(e => e.Reserve2).HasMaxLength(1000);

                entity.Property(e => e.Reserve3).HasMaxLength(1000);

                entity.Property(e => e.SaleGroup).HasMaxLength(1000);
            });

            modelBuilder.Entity<CrmplanList>(entity =>
            {
                entity.ToTable("CRMPlanList");

                entity.HasIndex(e => e.CrmapplyListInCode, "IX_CRMApplyList_InCode");

                entity.HasIndex(e => e.CrmplanHeadId, "IX_CRMPlanHead_Id");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplyNoState).HasMaxLength(1000);

                entity.Property(e => e.Biaozhun).HasMaxLength(1000);

                entity.Property(e => e.BoxName).HasMaxLength(1000);

                entity.Property(e => e.BoxNo).HasMaxLength(1000);

                entity.Property(e => e.BoxRemark).HasMaxLength(3000);

                entity.Property(e => e.ConvertRate).HasMaxLength(1000);

                entity.Property(e => e.CrmListStatus)
                    .HasMaxLength(20)
                    .HasColumnName("crmListStatus");

                entity.Property(e => e.CrmListType)
                    .HasMaxLength(1000)
                    .HasColumnName("crmListType");

                entity.Property(e => e.CrmapplyListInCode)
                    .HasMaxLength(1000)
                    .HasColumnName("CRMApplyList_InCode");

                entity.Property(e => e.CrmapplyNoXuhao)
                    .HasMaxLength(1000)
                    .HasColumnName("CRMApplyNo_Xuhao");

                entity.Property(e => e.CrmplanHeadId).HasColumnName("CRMPlanHead_Id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("deliveryDate");

                entity.Property(e => e.EmergencyDegree).HasMaxLength(1000);

                entity.Property(e => e.InventoryCount).HasMaxLength(1000);

                entity.Property(e => e.ItemName).HasMaxLength(1000);

                entity.Property(e => e.ItemNo).HasMaxLength(1000);

                entity.Property(e => e.OrderCountOnkg)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("OrderCountONkg");

                entity.Property(e => e.ProductRecipe).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(3000);

                entity.Property(e => e.Reserve2).HasMaxLength(1000);

                entity.Property(e => e.Reserve3).HasMaxLength(1000);

                entity.Property(e => e.Reserve4).HasMaxLength(50);

                entity.Property(e => e.Reserve5).HasMaxLength(1000);

                entity.Property(e => e.Reserve6).HasMaxLength(1000);

                entity.Property(e => e.Reserve7).HasMaxLength(1000);

                entity.Property(e => e.Spec).HasMaxLength(1000);

                entity.Property(e => e.Unit).HasMaxLength(1000);

                entity.HasOne(d => d.CrmplanHead)
                    .WithMany(p => p.CrmplanLists)
                    .HasForeignKey(d => d.CrmplanHeadId)
                    .HasConstraintName("FK_dbo.CRMPlanList_dbo.CRMPlanHead_CRMPlanHead_Id");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Abstract)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("abstract");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Principal)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("principal");

                entity.Property(e => e.Syscode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("syscode");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasIndex(e => e.ParentId, "IX_ParentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(60);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.Depts_dbo.Depts_ParentID");
            });

            modelBuilder.Entity<DeviceStatesInfo>(entity =>
            {
                entity.ToTable("DeviceStatesInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Battery)
                    .HasMaxLength(50)
                    .HasColumnName("battery");

                entity.Property(e => e.DeviceCode)
                    .HasMaxLength(50)
                    .HasColumnName("deviceCode");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .HasColumnName("deviceName");

                entity.Property(e => e.DevicePosition)
                    .HasMaxLength(50)
                    .HasColumnName("devicePosition");

                entity.Property(e => e.DevicePostionRec)
                    .HasMaxLength(50)
                    .HasColumnName("devicePostionRec");

                entity.Property(e => e.DevicePostionX)
                    .HasMaxLength(10)
                    .HasColumnName("devicePostionX");

                entity.Property(e => e.DevicePostionY)
                    .HasMaxLength(10)
                    .HasColumnName("devicePostionY");

                entity.Property(e => e.DeviceStatus)
                    .HasMaxLength(50)
                    .HasColumnName("deviceStatus");

                entity.Property(e => e.DeviceStatusInt).HasColumnName("deviceStatusInt");

                entity.Property(e => e.PayLoad)
                    .HasMaxLength(50)
                    .HasColumnName("payLoad");

                entity.Property(e => e.RecTime)
                    .HasColumnType("datetime")
                    .HasColumnName("recTime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<FaHuoPlan>(entity =>
            {
                entity.ToTable("FaHuoPlan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Boxnum)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("boxnum");

                entity.Property(e => e.Danjuno)
                    .HasMaxLength(100)
                    .HasColumnName("danjuno");

                entity.Property(e => e.Danjutype)
                    .HasMaxLength(100)
                    .HasColumnName("danjutype");

                entity.Property(e => e.Fhdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fhdate");

                entity.Property(e => e.Itemname)
                    .HasMaxLength(100)
                    .HasColumnName("itemname");

                entity.Property(e => e.Itemno)
                    .HasMaxLength(100)
                    .HasColumnName("itemno");

                entity.Property(e => e.Outqut)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("outqut");

                entity.Property(e => e.Salequt)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("salequt");

                entity.Property(e => e.Saleunit)
                    .HasMaxLength(100)
                    .HasColumnName("saleunit");

                entity.Property(e => e.Spec)
                    .HasMaxLength(100)
                    .HasColumnName("spec");
            });

            modelBuilder.Entity<ItemInfo>(entity =>
            {
                entity.ToTable("ItemInfo");

                entity.HasIndex(e => e.ItemNo, "IX_ItemNo");

                entity.HasIndex(e => e.ModTimeCrm, "IX_ModTime_CRM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConvertRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Crmid)
                    .HasMaxLength(200)
                    .HasColumnName("CRMID");

                entity.Property(e => e.InName).HasMaxLength(200);

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.ItemNo).HasMaxLength(100);

                entity.Property(e => e.MainUtil).HasMaxLength(100);

                entity.Property(e => e.MaterialItem).HasMaxLength(200);

                entity.Property(e => e.ModTimeAps)
                    .HasColumnType("datetime")
                    .HasColumnName("ModTime_APS");

                entity.Property(e => e.ModTimeCrm)
                    .HasColumnType("datetime")
                    .HasColumnName("ModTime_CRM");

                entity.Property(e => e.ModUserAps)
                    .HasMaxLength(50)
                    .HasColumnName("ModUser_APS");

                entity.Property(e => e.SlaveUtil).HasMaxLength(100);

                entity.Property(e => e.Spec).HasMaxLength(400);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Workshops).HasMaxLength(255);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LogAction).HasMaxLength(255);

                entity.Property(e => e.LogAmount).HasMaxLength(255);

                entity.Property(e => e.Logdate).HasColumnType("datetime");

                entity.Property(e => e.MarkLogLevel).HasMaxLength(50);

                entity.Property(e => e.StackTrace).HasMaxLength(255);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasIndex(e => e.ParentId, "IX_ParentID");

                entity.HasIndex(e => e.ViewPowerId, "IX_ViewPowerID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NavigateUrl).HasMaxLength(200);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.ViewPowerId).HasColumnName("ViewPowerID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.Menus_dbo.Menus_ParentID");

                entity.HasOne(d => d.ViewPower)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.ViewPowerId)
                    .HasConstraintName("FK_dbo.Menus_dbo.Powers_ViewPowerID");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<NumSeq>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NumSeq");

                entity.Property(e => e.Cate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CrTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateNo)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Online>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ipadddress)
                    .HasMaxLength(50)
                    .HasColumnName("IPAdddress");

                entity.Property(e => e.LoginTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Onlines)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Onlines_dbo.Users_UserID");
            });

            modelBuilder.Entity<Pbcatcol>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcatcol");

                entity.HasIndex(e => new { e.PbcTnam, e.PbcOwnr, e.PbcCnam }, "pbcatcol_idx")
                    .IsUnique();

                entity.Property(e => e.PbcBmap)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pbc_bmap")
                    .IsFixedLength();

                entity.Property(e => e.PbcCase).HasColumnName("pbc_case");

                entity.Property(e => e.PbcCid).HasColumnName("pbc_cid");

                entity.Property(e => e.PbcCmnt)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbc_cmnt");

                entity.Property(e => e.PbcCnam)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pbc_cnam")
                    .IsFixedLength();

                entity.Property(e => e.PbcEdit)
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("pbc_edit");

                entity.Property(e => e.PbcHdr)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbc_hdr");

                entity.Property(e => e.PbcHght).HasColumnName("pbc_hght");

                entity.Property(e => e.PbcHpos).HasColumnName("pbc_hpos");

                entity.Property(e => e.PbcInit)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbc_init");

                entity.Property(e => e.PbcJtfy).HasColumnName("pbc_jtfy");

                entity.Property(e => e.PbcLabl)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbc_labl");

                entity.Property(e => e.PbcLpos).HasColumnName("pbc_lpos");

                entity.Property(e => e.PbcMask)
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("pbc_mask");

                entity.Property(e => e.PbcOwnr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pbc_ownr")
                    .IsFixedLength();

                entity.Property(e => e.PbcPtrn)
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("pbc_ptrn");

                entity.Property(e => e.PbcTag)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbc_tag");

                entity.Property(e => e.PbcTid).HasColumnName("pbc_tid");

                entity.Property(e => e.PbcTnam)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pbc_tnam")
                    .IsFixedLength();

                entity.Property(e => e.PbcWdth).HasColumnName("pbc_wdth");
            });

            modelBuilder.Entity<Pbcatedt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcatedt");

                entity.HasIndex(e => new { e.PbeName, e.PbeSeqn }, "pbcatedt_idx")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.PbeCntr).HasColumnName("pbe_cntr");

                entity.Property(e => e.PbeEdit)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbe_edit");

                entity.Property(e => e.PbeFlag).HasColumnName("pbe_flag");

                entity.Property(e => e.PbeName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pbe_name");

                entity.Property(e => e.PbeSeqn).HasColumnName("pbe_seqn");

                entity.Property(e => e.PbeType).HasColumnName("pbe_type");

                entity.Property(e => e.PbeWork)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("pbe_work")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pbcatfmt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcatfmt");

                entity.HasIndex(e => e.PbfName, "pbcatfmt_idx")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.PbfCntr).HasColumnName("pbf_cntr");

                entity.Property(e => e.PbfFrmt)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbf_frmt");

                entity.Property(e => e.PbfName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pbf_name");

                entity.Property(e => e.PbfType).HasColumnName("pbf_type");
            });

            modelBuilder.Entity<Pbcattbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcattbl");

                entity.HasIndex(e => new { e.PbtTnam, e.PbtOwnr }, "pbcattbl_idx")
                    .IsUnique();

                entity.Property(e => e.PbdFchr).HasColumnName("pbd_fchr");

                entity.Property(e => e.PbdFfce)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("pbd_ffce")
                    .IsFixedLength();

                entity.Property(e => e.PbdFhgt).HasColumnName("pbd_fhgt");

                entity.Property(e => e.PbdFitl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pbd_fitl")
                    .IsFixedLength();

                entity.Property(e => e.PbdFptc).HasColumnName("pbd_fptc");

                entity.Property(e => e.PbdFunl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pbd_funl")
                    .IsFixedLength();

                entity.Property(e => e.PbdFwgt).HasColumnName("pbd_fwgt");

                entity.Property(e => e.PbhFchr).HasColumnName("pbh_fchr");

                entity.Property(e => e.PbhFfce)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("pbh_ffce")
                    .IsFixedLength();

                entity.Property(e => e.PbhFhgt).HasColumnName("pbh_fhgt");

                entity.Property(e => e.PbhFitl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pbh_fitl")
                    .IsFixedLength();

                entity.Property(e => e.PbhFptc).HasColumnName("pbh_fptc");

                entity.Property(e => e.PbhFunl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pbh_funl")
                    .IsFixedLength();

                entity.Property(e => e.PbhFwgt).HasColumnName("pbh_fwgt");

                entity.Property(e => e.PblFchr).HasColumnName("pbl_fchr");

                entity.Property(e => e.PblFfce)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("pbl_ffce")
                    .IsFixedLength();

                entity.Property(e => e.PblFhgt).HasColumnName("pbl_fhgt");

                entity.Property(e => e.PblFitl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pbl_fitl")
                    .IsFixedLength();

                entity.Property(e => e.PblFptc).HasColumnName("pbl_fptc");

                entity.Property(e => e.PblFunl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pbl_funl")
                    .IsFixedLength();

                entity.Property(e => e.PblFwgt).HasColumnName("pbl_fwgt");

                entity.Property(e => e.PbtCmnt)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbt_cmnt");

                entity.Property(e => e.PbtOwnr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pbt_ownr")
                    .IsFixedLength();

                entity.Property(e => e.PbtTid).HasColumnName("pbt_tid");

                entity.Property(e => e.PbtTnam)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pbt_tnam")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pbcatvld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pbcatvld");

                entity.HasIndex(e => e.PbvName, "pbcatvld_idx")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.PbvCntr).HasColumnName("pbv_cntr");

                entity.Property(e => e.PbvMsg)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbv_msg");

                entity.Property(e => e.PbvName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pbv_name");

                entity.Property(e => e.PbvType).HasColumnName("pbv_type");

                entity.Property(e => e.PbvVald)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("pbv_vald");
            });

            modelBuilder.Entity<Pchao>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pchao");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Lotno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lotno");

                entity.Property(e => e.Oper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("oper");
            });

            modelBuilder.Entity<Power>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<PrdMissionSl>(entity =>
            {
                entity.HasKey(e => e.Sn)
                    .HasName("PK_PRDMISSIONSL");

                entity.ToTable("PrdMissionSL");

                entity.Property(e => e.Sn).HasColumnName("SN");

                entity.Property(e => e.AuditDate).HasColumnType("datetime");

                entity.Property(e => e.Auditer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BoxLblName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Caseno)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.Checkman)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHECKMAN");

                entity.Property(e => e.Client)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("COLOR");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Grade)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GRADE");

                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KaiDan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KaiDanDate).HasColumnType("datetime");

                entity.Property(e => e.LabelName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Lotno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOTNO");

                entity.Property(e => e.Operator)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OPERATOR");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ORDERNO");

                entity.Property(e => e.PackMan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PiZhun)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PiZhunDate).HasColumnType("datetime");

                entity.Property(e => e.PrdMissionNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prodate)
                    .HasColumnType("datetime")
                    .HasColumnName("PRODate");

                entity.Property(e => e.Qcstandard)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QCStandard");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Reserve1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE1");

                entity.Property(e => e.Reserve10)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE10");

                entity.Property(e => e.Reserve11)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE11");

                entity.Property(e => e.Reserve12)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE12");

                entity.Property(e => e.Reserve13)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE13");

                entity.Property(e => e.Reserve14)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE14");

                entity.Property(e => e.Reserve15)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE15");

                entity.Property(e => e.Reserve16)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE16");

                entity.Property(e => e.Reserve17)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE17");

                entity.Property(e => e.Reserve18)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE18");

                entity.Property(e => e.Reserve19)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE19");

                entity.Property(e => e.Reserve2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE2");

                entity.Property(e => e.Reserve20)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE20");

                entity.Property(e => e.Reserve21)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE21");

                entity.Property(e => e.Reserve22)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE22");

                entity.Property(e => e.Reserve23)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE23");

                entity.Property(e => e.Reserve24)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE24");

                entity.Property(e => e.Reserve25)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE25");

                entity.Property(e => e.Reserve26)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE26");

                entity.Property(e => e.Reserve27)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE27");

                entity.Property(e => e.Reserve28)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE28");

                entity.Property(e => e.Reserve29)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE29");

                entity.Property(e => e.Reserve3)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE3");

                entity.Property(e => e.Reserve30)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE30");

                entity.Property(e => e.Reserve4)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE4");

                entity.Property(e => e.Reserve5)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE5");

                entity.Property(e => e.Reserve6)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE6");

                entity.Property(e => e.Reserve7)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE7");

                entity.Property(e => e.Reserve8)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE8");

                entity.Property(e => e.Reserve9)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE9");

                entity.Property(e => e.Spec)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnName("WEIGHT");

                entity.Property(e => e.Workgrp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("WORKGRP");
            });

            modelBuilder.Entity<ProcessClass>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProcessClassName).HasMaxLength(50);

                entity.Property(e => e.ProcessReamrk).HasMaxLength(300);
            });

            modelBuilder.Entity<ProductOrderheader>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MergeCells)
                    .HasMaxLength(255)
                    .HasColumnName("mergeCells");

                entity.Property(e => e.MergeCellsValue)
                    .HasMaxLength(255)
                    .HasColumnName("mergeCellsValue");

                entity.Property(e => e.Moddate).HasColumnType("datetime");

                entity.Property(e => e.Newdate).HasColumnType("datetime");

                entity.Property(e => e.Optdate).HasColumnType("datetime");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(20)
                    .HasColumnName("orderNo");

                entity.Property(e => e.PositionClass).HasMaxLength(50);

                entity.Property(e => e.ProductOrderNo).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.Workshops).HasMaxLength(255);

                entity.Property(e => e.WorkshopsValue).HasMaxLength(300);
            });

            modelBuilder.Entity<ProductOrderlist>(entity =>
            {
                entity.HasIndex(e => e.CrmplanListId, "IX_CRMPlanList_ID");

                entity.HasIndex(e => e.ProductOrderheaderId, "IX_ProductOrderheader_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo).HasMaxLength(100);

                entity.Property(e => e.Biaozhun).HasMaxLength(20);

                entity.Property(e => e.BoxName).HasMaxLength(300);

                entity.Property(e => e.BoxNo).HasMaxLength(50);

                entity.Property(e => e.BoxRemark).HasMaxLength(500);

                entity.Property(e => e.Chejianclass).HasMaxLength(50);

                entity.Property(e => e.Class).HasMaxLength(20);

                entity.Property(e => e.Clientname).HasMaxLength(200);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.CrmplanListId).HasColumnName("CRMPlanList_ID");

                entity.Property(e => e.ErporderNo)
                    .HasMaxLength(20)
                    .HasColumnName("ERPOrderNo");

                entity.Property(e => e.GiveDept).HasMaxLength(50);

                entity.Property(e => e.InName).HasMaxLength(200);

                entity.Property(e => e.Ingredients).HasMaxLength(100);

                entity.Property(e => e.ItemName).HasMaxLength(200);

                entity.Property(e => e.Itemno).HasMaxLength(50);

                entity.Property(e => e.Jingbanren).HasMaxLength(20);

                entity.Property(e => e.MaterialItem).HasMaxLength(200);

                entity.Property(e => e.Moddate).HasColumnType("datetime");

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Newdate).HasColumnType("datetime");

                entity.Property(e => e.PcCount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PcCount03Bag)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PcCount_03_Bag");

                entity.Property(e => e.PcCount03Box)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PcCount_03_Box");

                entity.Property(e => e.PcCount03Tank)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PcCount_03_Tank");

                entity.Property(e => e.PcCount07Bag)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PcCount_07_Bag");

                entity.Property(e => e.PcCount07Box)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PcCount_07_Box");

                entity.Property(e => e.PcCount07Tank)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PcCount_07_Tank");

                entity.Property(e => e.PlanDate).HasColumnType("datetime");

                entity.Property(e => e.PrintState).HasMaxLength(10);

                entity.Property(e => e.Priority).HasMaxLength(10);

                entity.Property(e => e.ProductOrderState)
                    .HasMaxLength(10)
                    .HasColumnName("ProductOrder_State");

                entity.Property(e => e.ProductOrderXuHao)
                    .HasMaxLength(200)
                    .HasColumnName("ProductOrder_XuHao");

                entity.Property(e => e.ProductOrderheaderId).HasColumnName("ProductOrderheader_ID");

                entity.Property(e => e.ProductRecipe).HasMaxLength(1000);

                entity.Property(e => e.Spec).HasMaxLength(20);

                entity.Property(e => e.Unit).HasMaxLength(10);

                entity.HasOne(d => d.CrmplanList)
                    .WithMany(p => p.ProductOrderlists)
                    .HasForeignKey(d => d.CrmplanListId)
                    .HasConstraintName("FK_dbo.ProductOrderlists_dbo.CRMPlanList_CRMPlanList_ID");

                entity.HasOne(d => d.ProductOrderheader)
                    .WithMany(p => p.ProductOrderlists)
                    .HasForeignKey(d => d.ProductOrderheaderId)
                    .HasConstraintName("FK_dbo.ProductOrderlists_dbo.ProductOrderheaders_ProductOrderheader_ID");
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.ToTable("Production");

                entity.HasIndex(e => e.ProductOrderlistsId, "IX_ProductOrderlistsID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(100)
                    .HasColumnName("batchNo");

                entity.Property(e => e.BoxName)
                    .HasMaxLength(50)
                    .HasColumnName("boxName");

                entity.Property(e => e.BoxNo)
                    .HasMaxLength(50)
                    .HasColumnName("boxNo");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .HasColumnName("class");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.Danjuhao)
                    .HasMaxLength(100)
                    .HasColumnName("danjuhao");

                entity.Property(e => e.Ingredients)
                    .HasMaxLength(50)
                    .HasColumnName("ingredients");

                entity.Property(e => e.Itemno)
                    .HasMaxLength(50)
                    .HasColumnName("itemno");

                entity.Property(e => e.Position)
                    .HasMaxLength(20)
                    .HasColumnName("position");

                entity.Property(e => e.Probiaozhun)
                    .HasMaxLength(50)
                    .HasColumnName("probiaozhun");

                entity.Property(e => e.Prodate)
                    .HasColumnType("datetime")
                    .HasColumnName("prodate");

                entity.Property(e => e.ProductOrderlistsId).HasColumnName("ProductOrderlistsID");

                entity.Property(e => e.Proname)
                    .HasMaxLength(50)
                    .HasColumnName("proname");

                entity.Property(e => e.Prosn)
                    .HasMaxLength(50)
                    .HasColumnName("prosn");

                entity.Property(e => e.Protype)
                    .HasMaxLength(50)
                    .HasColumnName("protype");

                entity.Property(e => e.Remark1).HasColumnName("remark1");

                entity.Property(e => e.Spec)
                    .HasMaxLength(50)
                    .HasColumnName("spec");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .HasColumnName("unit");

                entity.Property(e => e.YuanliaobatchNo)
                    .HasMaxLength(100)
                    .HasColumnName("yuanliaobatchNo");

                entity.HasOne(d => d.ProductOrderlists)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.ProductOrderlistsId)
                    .HasConstraintName("FK_dbo.Production_dbo.ProductOrderlists_ProductOrderlistsID");
            });

            modelBuilder.Entity<Productiondt>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK_PRODUCTIONdt");

                entity.ToTable("Productiondt");

                entity.HasComment("fdsfds fdsfsfd  fsd fds f");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.Checkman)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHECKMAN");

                entity.Property(e => e.Client)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLOR");

                entity.Property(e => e.Grade)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GRADE");

                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lotno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOTNO")
                    .HasComment("fds fds  fds fdsfds fs");

                entity.Property(e => e.Operator)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OPERATOR");

                entity.Property(e => e.Orderno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ORDERNO");

                entity.Property(e => e.PackMan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrdMissionNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProSn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("产品编号");

                entity.Property(e => e.Prodate)
                    .HasColumnType("datetime")
                    .HasColumnName("PRODate")
                    .HasComment("生产日期");

                entity.Property(e => e.Qcstandard)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QCStandard");

                entity.Property(e => e.Remark)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Reserve1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE1");

                entity.Property(e => e.Reserve10)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE10");

                entity.Property(e => e.Reserve2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE2");

                entity.Property(e => e.Reserve3)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE3");

                entity.Property(e => e.Reserve4)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE4");

                entity.Property(e => e.Reserve5)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE5");

                entity.Property(e => e.Reserve6)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE6");

                entity.Property(e => e.Reserve7)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE7");

                entity.Property(e => e.Reserve8)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE8");

                entity.Property(e => e.Reserve9)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE9");

                entity.Property(e => e.Spec)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("WEIGHT");

                entity.Property(e => e.Workgrp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("WORKGRP");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.HasMany(d => d.Powers)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RolePower",
                        l => l.HasOne<Power>().WithMany().HasForeignKey("PowerId").HasConstraintName("FK_dbo.RolePowers_dbo.Powers_PowerID"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_dbo.RolePowers_dbo.Roles_RoleID"),
                        j =>
                        {
                            j.HasKey("RoleId", "PowerId").HasName("PK_dbo.RolePowers");

                            j.ToTable("RolePowers");

                            j.HasIndex(new[] { "PowerId" }, "IX_PowerID");

                            j.HasIndex(new[] { "RoleId" }, "IX_RoleID");

                            j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");

                            j.IndexerProperty<int>("PowerId").HasColumnName("PowerID");
                        });

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoleUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_dbo.RoleUsers_dbo.Users_UserID"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_dbo.RoleUsers_dbo.Roles_RoleID"),
                        j =>
                        {
                            j.HasKey("RoleId", "UserId").HasName("PK_dbo.RoleUsers");

                            j.ToTable("RoleUsers");

                            j.HasIndex(new[] { "RoleId" }, "IX_RoleID");

                            j.HasIndex(new[] { "UserId" }, "IX_UserID");

                            j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");

                            j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        });
            });

            modelBuilder.Entity<SensorDatum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Floor).HasMaxLength(10);

                entity.Property(e => e.RefleshTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Serialno>(entity =>
            {
                entity.HasKey(e => e.Serialname);

                entity.ToTable("SERIALNO");

                entity.Property(e => e.Serialname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SERIALNAME");

                entity.Property(e => e.Serialno1).HasColumnName("SERIALNO");
            });

            modelBuilder.Entity<StockPlan>(entity =>
            {
                entity.ToTable("StockPlan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(50)
                    .HasColumnName("batchNo");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.Count)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("count");

                entity.Property(e => e.Mark)
                    .HasMaxLength(10)
                    .HasColumnName("mark");

                entity.Property(e => e.PlanNo).HasMaxLength(50);

                entity.Property(e => e.PlanUser)
                    .HasMaxLength(50)
                    .HasColumnName("planUser");

                entity.Property(e => e.Plantime)
                    .HasColumnType("datetime")
                    .HasColumnName("plantime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Position)
                    .HasMaxLength(20)
                    .HasColumnName("position");

                entity.Property(e => e.Probiaozhun)
                    .HasMaxLength(50)
                    .HasColumnName("probiaozhun");

                entity.Property(e => e.Proname)
                    .HasMaxLength(50)
                    .HasColumnName("proname");

                entity.Property(e => e.Spec)
                    .HasMaxLength(50)
                    .HasColumnName("spec");

                entity.Property(e => e.States)
                    .HasMaxLength(50)
                    .HasColumnName("states");
            });

            modelBuilder.Entity<Sysparm>(entity =>
            {
                entity.HasKey(e => e.Paraitem);

                entity.ToTable("SYSPARM");

                entity.Property(e => e.Paraitem)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("paraitem");

                entity.Property(e => e.ItemCls)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Paravalue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("paravalue");

                entity.Property(e => e.Reserve1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reserve2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reserve3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Reserve4)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TelenClient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Bank)
                    .HasMaxLength(50)
                    .HasColumnName("bank");

                entity.Property(e => e.ClientManager).HasColumnName("clientManager");

                entity.Property(e => e.Condiction)
                    .HasMaxLength(50)
                    .HasColumnName("condiction");

                entity.Property(e => e.Eamil).HasMaxLength(50);

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .HasColumnName("fax");

                entity.Property(e => e.Gendan).HasColumnName("gendan");

                entity.Property(e => e.Implementer).HasColumnName("implementer");

                entity.Property(e => e.LevelCode)
                    .HasMaxLength(50)
                    .HasColumnName("levelCode");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasColumnName("nickname");

                entity.Property(e => e.Number).HasMaxLength(20);

                entity.Property(e => e.Openid).HasColumnName("openid");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .HasColumnName("remark");

                entity.Property(e => e.ServerTime)
                    .HasColumnType("datetime")
                    .HasColumnName("serverTime");
            });

            modelBuilder.Entity<TiShengJiInfo>(entity =>
            {
                entity.ToTable("TiShengJiInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgvserverIp)
                    .HasMaxLength(20)
                    .HasColumnName("AGVServerIP");

                entity.Property(e => e.Floors).HasMaxLength(200);

                entity.Property(e => e.InputTime).HasColumnType("datetime");

                entity.Property(e => e.TsjInModel1f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjInModel_1F");

                entity.Property(e => e.TsjInModel2f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjInModel_2F");

                entity.Property(e => e.TsjInModel3f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjInModel_3F");

                entity.Property(e => e.TsjIp).HasMaxLength(25);

                entity.Property(e => e.TsjName).HasMaxLength(20);

                entity.Property(e => e.TsjOutModel1f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjOutModel_1F");

                entity.Property(e => e.TsjOutModel2f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjOutModel_2F");

                entity.Property(e => e.TsjOutModel3f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjOutModel_3F");

                entity.Property(e => e.TsjPosition1f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjPosition_1F");

                entity.Property(e => e.TsjPosition2f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjPosition_2F");

                entity.Property(e => e.TsjPosition3f)
                    .HasMaxLength(20)
                    .HasColumnName("TsjPosition_3F");
            });

            modelBuilder.Entity<TiShengJiRunRecord>(entity =>
            {
                entity.ToTable("TiShengJiRunRecord");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndFloor).HasMaxLength(20);

                entity.Property(e => e.InsideTrayNo).HasMaxLength(20);

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.OutsideTrayNo).HasMaxLength(20);

                entity.Property(e => e.StartFloor).HasMaxLength(20);

                entity.Property(e => e.TsjIp).HasMaxLength(25);

                entity.Property(e => e.TsjName).HasMaxLength(20);
            });

            modelBuilder.Entity<TiShengJiState>(entity =>
            {
                entity.ToTable("TiShengJiState");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarState)
                    .HasMaxLength(20)
                    .HasColumnName("carState");

                entity.Property(e => e.CarState2).HasMaxLength(20);

                entity.Property(e => e.CarTarget)
                    .HasMaxLength(20)
                    .HasColumnName("carTarget");

                entity.Property(e => e.DeviceState)
                    .HasMaxLength(20)
                    .HasColumnName("deviceState");

                entity.Property(e => e.F1count).HasColumnName("F1Count");

                entity.Property(e => e.F1duiJieWei)
                    .HasMaxLength(20)
                    .HasColumnName("F1DuiJieWei");

                entity.Property(e => e.F1state)
                    .HasMaxLength(20)
                    .HasColumnName("F1State");

                entity.Property(e => e.F2count).HasColumnName("F2Count");

                entity.Property(e => e.F2duiJieWei)
                    .HasMaxLength(20)
                    .HasColumnName("F2DuiJieWei");

                entity.Property(e => e.F2state)
                    .HasMaxLength(20)
                    .HasColumnName("F2State");

                entity.Property(e => e.F3count).HasColumnName("F3Count");

                entity.Property(e => e.F3duiJieWei)
                    .HasMaxLength(20)
                    .HasColumnName("F3DuiJieWei");

                entity.Property(e => e.F3state)
                    .HasMaxLength(20)
                    .HasColumnName("F3State");

                entity.Property(e => e.InputTime).HasColumnType("datetime");

                entity.Property(e => e.OrderReceive).HasMaxLength(20);

                entity.Property(e => e.TsjIp).HasMaxLength(25);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Titles)
                    .UsingEntity<Dictionary<string, object>>(
                        "TitleUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_dbo.TitleUsers_dbo.Users_UserID"),
                        r => r.HasOne<Title>().WithMany().HasForeignKey("TitleId").HasConstraintName("FK_dbo.TitleUsers_dbo.Titles_TitleID"),
                        j =>
                        {
                            j.HasKey("TitleId", "UserId").HasName("PK_dbo.TitleUsers");

                            j.ToTable("TitleUsers");

                            j.HasIndex(new[] { "TitleId" }, "IX_TitleID");

                            j.HasIndex(new[] { "UserId" }, "IX_UserID");

                            j.IndexerProperty<int>("TitleId").HasColumnName("TitleID");

                            j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        });
            });

            modelBuilder.Entity<TouLiaoRecord>(entity =>
            {
                entity.ToTable("TouLiaoRecord");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Prosn)
                    .HasMaxLength(20)
                    .HasColumnName("prosn");

                entity.Property(e => e.RecTime).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("userID");
            });

            modelBuilder.Entity<TrayPro>(entity =>
            {
                entity.ToTable("TrayPro");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Optdate)
                    .HasColumnType("datetime")
                    .HasColumnName("optdate");

                entity.Property(e => e.Prosn)
                    .HasMaxLength(60)
                    .HasColumnName("prosn");

                entity.Property(e => e.TrayStateId).HasColumnName("TrayStateID");

                entity.HasOne(d => d.TrayState)
                    .WithMany(p => p.TrayPros)
                    .HasForeignKey(d => d.TrayStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrayStateTrayPro");
            });

            modelBuilder.Entity<TrayState>(entity =>
            {
                entity.ToTable("TrayState");

                entity.HasIndex(e => e.TrayNo, "IX_TrayState");

                entity.HasIndex(e => e.WareLocationId, "IX_WareLocation_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(100)
                    .HasColumnName("batchNo");

                entity.Property(e => e.BoxName)
                    .HasMaxLength(10)
                    .HasColumnName("boxName")
                    .IsFixedLength();

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .HasColumnName("color");

                entity.Property(e => e.Itemno)
                    .HasMaxLength(50)
                    .HasColumnName("itemno");

                entity.Property(e => e.Optdate)
                    .HasColumnType("datetime")
                    .HasColumnName("optdate");

                entity.Property(e => e.Position)
                    .HasMaxLength(20)
                    .HasColumnName("position");

                entity.Property(e => e.Probiaozhun)
                    .HasMaxLength(10)
                    .HasColumnName("probiaozhun");

                entity.Property(e => e.Proname)
                    .HasMaxLength(50)
                    .HasColumnName("proname");

                entity.Property(e => e.Remark).HasColumnName("remark");

                entity.Property(e => e.Spec)
                    .HasMaxLength(20)
                    .HasColumnName("spec");

                entity.Property(e => e.TrayNo)
                    .HasMaxLength(20)
                    .HasColumnName("TrayNO");

                entity.Property(e => e.WareLocationId).HasColumnName("WareLocation_ID");

                entity.HasOne(d => d.WareLocation)
                    .WithMany(p => p.TrayStates)
                    .HasForeignKey(d => d.WareLocationId)
                    .HasConstraintName("FK_dbo.TrayState_dbo.WareLocation_WareLocation_ID");
            });

            modelBuilder.Entity<TrayWeightRecord>(entity =>
            {
                entity.ToTable("TrayWeightRecord");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo).HasMaxLength(50);

                entity.Property(e => e.Biaozhun).HasMaxLength(50);

                entity.Property(e => e.BoxName).HasMaxLength(100);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.Itemno).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Proname).HasMaxLength(200);

                entity.Property(e => e.Prosn).HasMaxLength(50);

                entity.Property(e => e.RecTime).HasColumnType("datetime");

                entity.Property(e => e.RecUserId).HasColumnName("Rec_UserID");

                entity.Property(e => e.Result).HasMaxLength(10);

                entity.Property(e => e.Spec).HasMaxLength(50);

                entity.Property(e => e.TrayCount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TrayWeight).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<UpdateApp>(entity =>
            {
                entity.ToTable("UpdateApp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppName)
                    .HasMaxLength(20)
                    .HasColumnName("App_Name");

                entity.Property(e => e.AppNewVersion)
                    .HasMaxLength(10)
                    .HasColumnName("App_NewVersion");

                entity.Property(e => e.AppPath)
                    .HasMaxLength(20)
                    .HasColumnName("App_Path");

                entity.Property(e => e.AppType)
                    .HasMaxLength(10)
                    .HasColumnName("App_Type");

                entity.Property(e => e.AppVersion)
                    .HasMaxLength(10)
                    .HasColumnName("App_Version");

                entity.Property(e => e.LastNewTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UpdateFile>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppName)
                    .HasMaxLength(20)
                    .HasColumnName("App_Name");

                entity.Property(e => e.AppVersion)
                    .HasMaxLength(20)
                    .HasColumnName("App_Version");

                entity.Property(e => e.FileName).HasMaxLength(50);

                entity.Property(e => e.FilePath).HasMaxLength(120);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.DeptId, "IX_DeptID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CellPhone).HasMaxLength(50);

                entity.Property(e => e.ChineseName).HasMaxLength(100);

                entity.Property(e => e.CompanyEmail).HasMaxLength(100);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EnglishName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.HomePhone).HasMaxLength(50);

                entity.Property(e => e.IdentityCard).HasMaxLength(50);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OfficePhone).HasMaxLength(50);

                entity.Property(e => e.OfficePhoneExt).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Photo).HasMaxLength(200);

                entity.Property(e => e.Qq)
                    .HasMaxLength(50)
                    .HasColumnName("QQ");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.TakeOfficeTime).HasColumnType("datetime");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_dbo.Users_dbo.Depts_DeptID");
            });

            modelBuilder.Entity<WareArea>(entity =>
            {
                entity.ToTable("WareArea");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstockRule).HasMaxLength(10);

                entity.Property(e => e.InstockWay).HasMaxLength(10);

                entity.Property(e => e.Protype)
                    .HasMaxLength(10)
                    .HasColumnName("protype");

                entity.Property(e => e.WarId).HasColumnName("War_ID");

                entity.Property(e => e.WareHouseId).HasColumnName("WareHouse_ID");

                entity.Property(e => e.WareNo).HasMaxLength(50);

                entity.HasOne(d => d.War)
                    .WithMany(p => p.WareAreas)
                    .HasForeignKey(d => d.WarId)
                    .HasConstraintName("FK_WAREAREA_REFERENCE_WAREAREA");

                entity.HasOne(d => d.WareHouse)
                    .WithMany(p => p.WareAreas)
                    .HasForeignKey(d => d.WareHouseId)
                    .HasConstraintName("FK_WAREAREA_REFERENCE_WAREHOUS");
            });

            modelBuilder.Entity<WareAreaClass>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_WAREAREACLASS")
                    .IsClustered(false);

                entity.ToTable("WareAreaClass");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaClass).HasMaxLength(50);

                entity.Property(e => e.Remark).HasMaxLength(50);
            });

            modelBuilder.Entity<WareHouse>(entity =>
            {
                entity.ToTable("WareHouse");

                entity.HasComment("仓库主表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgvmodelCode)
                    .HasMaxLength(20)
                    .HasColumnName("AGVModelCode");

                entity.Property(e => e.AgvserverIp)
                    .HasMaxLength(20)
                    .HasColumnName("AGVServerIP");

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.Whname)
                    .HasMaxLength(50)
                    .HasColumnName("WHName");

                entity.Property(e => e.Whposition)
                    .HasMaxLength(50)
                    .HasColumnName("WHPosition");

                entity.Property(e => e.Whstate).HasColumnName("WHState");
            });

            modelBuilder.Entity<WareLocation>(entity =>
            {
                entity.ToTable("WareLocation");

                entity.HasIndex(e => e.TrayStateId, "IX_TrayState_ID");

                entity.HasIndex(e => e.WareLocaLie, "IX_WareLoca_Lie");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Agvposition)
                    .HasMaxLength(50)
                    .HasColumnName("AGVPosition");

                entity.Property(e => e.HeaderId).HasColumnName("header_ID");

                entity.Property(e => e.IsOpen).HasComment("是否启用，0为禁用，1为启用");

                entity.Property(e => e.TrayNo).HasMaxLength(50);

                entity.Property(e => e.TrayStateId).HasColumnName("TrayState_ID");

                entity.Property(e => e.WareAreaId).HasColumnName("WareArea_ID");

                entity.Property(e => e.WareLocaIndex)
                    .HasMaxLength(50)
                    .HasColumnName("WareLoca_Index");

                entity.Property(e => e.WareLocaLie)
                    .HasMaxLength(50)
                    .HasColumnName("WareLoca_Lie");

                entity.Property(e => e.WareLocaNo).HasMaxLength(50);

                entity.Property(e => e.WareLocaState)
                    .HasMaxLength(10)
                    .HasComment("仓位状态：预进、预出、占用、空");

                entity.HasOne(d => d.Header)
                    .WithMany(p => p.WareLocations)
                    .HasForeignKey(d => d.HeaderId)
                    .HasConstraintName("FK_WARELOCA_REFERENCE_USERS");

                entity.HasOne(d => d.TrayState)
                    .WithMany(p => p.WareLocations)
                    .HasForeignKey(d => d.TrayStateId)
                    .HasConstraintName("FK_dbo.WareLocation_dbo.TrayState_TrayState_ID");

                entity.HasOne(d => d.WareArea)
                    .WithMany(p => p.WareLocations)
                    .HasForeignKey(d => d.WareAreaId)
                    .HasConstraintName("FK_WARELOCA_REFERENCE_WAREAREA");
            });

            modelBuilder.Entity<WeiXinSetting>(entity =>
            {
                entity.ToTable("WeiXinSetting");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExpiraitonTime)
                    .HasColumnType("datetime")
                    .HasColumnName("expiraiton_time");

                entity.Property(e => e.Key)
                    .HasMaxLength(200)
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<WorkShopProcess>(entity =>
            {
                entity.HasIndex(e => e.ProcessClassId, "IX_ProcessClass_Id");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProcessClassId).HasColumnName("ProcessClass_Id");

                entity.Property(e => e.WorkShopName).HasMaxLength(50);

                entity.HasOne(d => d.ProcessClass)
                    .WithMany(p => p.WorkShopProcesses)
                    .HasForeignKey(d => d.ProcessClassId)
                    .HasConstraintName("FK_dbo.WorkShopProcesses_dbo.ProcessClasses_ProcessClass_Id");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("STAFF");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Abstract)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("abstract");

                entity.Property(e => e.Account)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("account");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Authorgrp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("authorgrp");

                entity.Property(e => e.Bank)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("bank");

                entity.Property(e => e.Basepay)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("basepay");

                entity.Property(e => e.Demdate)
                    .HasColumnType("datetime")
                    .HasColumnName("demdate");

                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.Edured)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("edured");

                entity.Property(e => e.Idcard)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idcard");

                entity.Property(e => e.Indate)
                    .HasColumnType("datetime")
                    .HasColumnName("indate");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Posstate).HasColumnName("posstate");

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telephone");

                entity.Property(e => e.Timepay)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("timepay");

                entity.Property(e => e.Workcls)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("workcls");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STAFF_REFERENCE_DEPARTME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
