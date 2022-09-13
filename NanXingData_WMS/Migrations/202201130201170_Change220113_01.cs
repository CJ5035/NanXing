namespace NanXingData_WMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Change220113_01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CRMPlanList", "CRMPlanHead_Id", "dbo.CRMPlanHead");
            DropForeignKey("dbo.ProductOrderlists", "CRMPlanList_ID", "dbo.CRMPlanList");
            DropIndex("dbo.CRMPlanList", new[] { "CRMPlanHead_Id" });
            DropIndex("dbo.ProductOrderlists", new[] { "CRMPlanList_ID" });
            DropPrimaryKey("dbo.CRMPlanHead");
            DropPrimaryKey("dbo.CRMPlanList");
            AlterColumn("dbo.CRMPlanHead", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.CRMPlanHead", "CRMApplyNo", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "ClientNo", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "ClientName", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "ApplicantId", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "ApplicantName", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "ApplicantPhone", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "ApplicantDept", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "ApplicantJob", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "SaleGroup", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "OrderSource", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "Remark", c => c.String(maxLength: 3000));
            AlterColumn("dbo.CRMPlanHead", "Reserve1", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "Reserve2", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanHead", "Reserve3", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.CRMPlanList", "CRMApplyNo_Xuhao", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "ItemNo", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "ItemName", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "Spec", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "Unit", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "InventoryCount", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "BoxNo", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "BoxName", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "BoxRemark", c => c.String(maxLength: 3000));
            AlterColumn("dbo.CRMPlanList", "Biaozhun", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "ApplyNoState", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "EmergencyDegree", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "Remark", c => c.String(maxLength: 3000));
            AlterColumn("dbo.CRMPlanList", "Reserve1", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "Reserve2", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "Reserve3", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "Reserve5", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "Reserve6", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "Reserve7", c => c.String(maxLength: 1000));
            AlterColumn("dbo.CRMPlanList", "CRMPlanHead_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.CRMPlanList", "crmListType", c => c.String(maxLength: 1000));
            AlterColumn("dbo.ProductOrderlists", "CRMPlanList_ID", c => c.Long());
            AddPrimaryKey("dbo.CRMPlanHead", "ID");
            AddPrimaryKey("dbo.CRMPlanList", "ID");
            CreateIndex("dbo.CRMPlanList", "CRMPlanHead_Id");
            CreateIndex("dbo.ProductOrderlists", "CRMPlanList_ID");
            AddForeignKey("dbo.CRMPlanList", "CRMPlanHead_Id", "dbo.CRMPlanHead", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductOrderlists", "CRMPlanList_ID", "dbo.CRMPlanList", "ID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.ProductOrderlists", "CRMPlanList_ID", "dbo.CRMPlanList");
            DropForeignKey("dbo.CRMPlanList", "CRMPlanHead_Id", "dbo.CRMPlanHead");
            DropIndex("dbo.ProductOrderlists", new[] { "CRMPlanList_ID" });
            DropIndex("dbo.CRMPlanList", new[] { "CRMPlanHead_Id" });
            DropPrimaryKey("dbo.CRMPlanList");
            DropPrimaryKey("dbo.CRMPlanHead");
            AlterColumn("dbo.ProductOrderlists", "CRMPlanList_ID", c => c.Int());
            AlterColumn("dbo.CRMPlanList", "crmListType", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanList", "CRMPlanHead_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CRMPlanList", "Reserve7", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "Reserve6", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "Reserve5", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "Reserve3", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "Reserve2", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "Reserve1", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "Remark", c => c.String(maxLength: 500));
            AlterColumn("dbo.CRMPlanList", "EmergencyDegree", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "ApplyNoState", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "Biaozhun", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanList", "BoxRemark", c => c.String(maxLength: 500));
            AlterColumn("dbo.CRMPlanList", "BoxName", c => c.String(maxLength: 300));
            AlterColumn("dbo.CRMPlanList", "BoxNo", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanList", "InventoryCount", c => c.String(maxLength: 30));
            AlterColumn("dbo.CRMPlanList", "Unit", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanList", "Spec", c => c.String(maxLength: 100));
            AlterColumn("dbo.CRMPlanList", "ItemName", c => c.String(maxLength: 300));
            AlterColumn("dbo.CRMPlanList", "ItemNo", c => c.String(maxLength: 100));
            AlterColumn("dbo.CRMPlanList", "CRMApplyNo_Xuhao", c => c.String(maxLength: 30));
            AlterColumn("dbo.CRMPlanList", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CRMPlanHead", "Reserve3", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanHead", "Reserve2", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanHead", "Reserve1", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanHead", "Remark", c => c.String(maxLength: 255));
            AlterColumn("dbo.CRMPlanHead", "OrderSource", c => c.String(maxLength: 10));
            AlterColumn("dbo.CRMPlanHead", "SaleGroup", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanHead", "ApplicantJob", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanHead", "ApplicantDept", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanHead", "ApplicantPhone", c => c.String(maxLength: 15));
            AlterColumn("dbo.CRMPlanHead", "ApplicantName", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanHead", "ApplicantId", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanHead", "ClientName", c => c.String(maxLength: 50));
            AlterColumn("dbo.CRMPlanHead", "ClientNo", c => c.String(maxLength: 20));
            AlterColumn("dbo.CRMPlanHead", "CRMApplyNo", c => c.String(maxLength: 30));
            AlterColumn("dbo.CRMPlanHead", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CRMPlanList", "ID");
            AddPrimaryKey("dbo.CRMPlanHead", "ID");
            CreateIndex("dbo.ProductOrderlists", "CRMPlanList_ID");
            CreateIndex("dbo.CRMPlanList", "CRMPlanHead_Id");
            AddForeignKey("dbo.ProductOrderlists", "CRMPlanList_ID", "dbo.CRMPlanList", "ID");
            AddForeignKey("dbo.CRMPlanList", "CRMPlanHead_Id", "dbo.CRMPlanHead", "ID", cascadeDelete: true);
        }

        /*
                         IF object_id(N'[dbo].[FK_dbo.CRMPlanList_dbo.CRMPlanHead_CRMPlanHead_Id]', N'F') IS NOT NULL
                    ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [FK_dbo.CRMPlanList_dbo.CRMPlanHead_CRMPlanHead_Id]
                IF object_id(N'[dbo].[FK_dbo.ProductOrderlists_dbo.CRMPlanList_CRMPlanList_ID]', N'F') IS NOT NULL
                    ALTER TABLE [dbo].[ProductOrderlists] DROP CONSTRAINT [FK_dbo.ProductOrderlists_dbo.CRMPlanList_CRMPlanList_ID]
                IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_CRMPlanHead_Id' AND object_id = object_id(N'[dbo].[CRMPlanList]', N'U'))
                    DROP INDEX [IX_CRMPlanHead_Id] ON [dbo].[CRMPlanList]
                IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_CRMPlanList_ID' AND object_id = object_id(N'[dbo].[ProductOrderlists]', N'U'))
                    DROP INDEX [IX_CRMPlanList_ID] ON [dbo].[ProductOrderlists]
                ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [PK_dbo.CRMPlanHead]
                ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [PK_dbo.CRMPlanList]
                DECLARE @var0 nvarchar(128)
                SELECT @var0 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'ID';
                IF @var0 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var0 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [ID] [bigint] NOT NULL
                DECLARE @var1 nvarchar(128)
                SELECT @var1 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'CRMApplyNo';
                IF @var1 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var1 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [CRMApplyNo] [nvarchar](1000) NULL
                DECLARE @var2 nvarchar(128)
                SELECT @var2 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'ClientNo';
                IF @var2 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var2 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [ClientNo] [nvarchar](1000) NULL
                DECLARE @var3 nvarchar(128)
                SELECT @var3 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'ClientName';
                IF @var3 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var3 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [ClientName] [nvarchar](1000) NULL
                DECLARE @var4 nvarchar(128)
                SELECT @var4 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'ApplicantId';
                IF @var4 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var4 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [ApplicantId] [nvarchar](1000) NULL
                DECLARE @var5 nvarchar(128)
                SELECT @var5 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'ApplicantName';
                IF @var5 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var5 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [ApplicantName] [nvarchar](1000) NULL
                DECLARE @var6 nvarchar(128)
                SELECT @var6 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'ApplicantPhone';
                IF @var6 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var6 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [ApplicantPhone] [nvarchar](1000) NULL
                DECLARE @var7 nvarchar(128)
                SELECT @var7 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'ApplicantDept';
                IF @var7 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var7 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [ApplicantDept] [nvarchar](1000) NULL
                DECLARE @var8 nvarchar(128)
                SELECT @var8 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'ApplicantJob';
                IF @var8 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var8 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [ApplicantJob] [nvarchar](1000) NULL
                DECLARE @var9 nvarchar(128)
                SELECT @var9 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'SaleGroup';
                IF @var9 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var9 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [SaleGroup] [nvarchar](1000) NULL
                DECLARE @var10 nvarchar(128)
                SELECT @var10 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'OrderSource';
                IF @var10 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var10 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [OrderSource] [nvarchar](1000) NULL
                DECLARE @var11 nvarchar(128)
                SELECT @var11 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'Remark';
                IF @var11 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var11 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [Remark] [nvarchar](3000) NULL
                DECLARE @var12 nvarchar(128)
                SELECT @var12 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve1';
                IF @var12 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var12 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [Reserve1] [nvarchar](1000) NULL
                DECLARE @var13 nvarchar(128)
                SELECT @var13 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve2';
                IF @var13 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var13 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [Reserve2] [nvarchar](1000) NULL
                DECLARE @var14 nvarchar(128)
                SELECT @var14 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanHead')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve3';
                IF @var14 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanHead] DROP CONSTRAINT [' + @var14 + ']')
                ALTER TABLE [dbo].[CRMPlanHead] ALTER COLUMN [Reserve3] [nvarchar](1000) NULL
                DECLARE @var15 nvarchar(128)
                SELECT @var15 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'ID';
                IF @var15 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var15 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [ID] [bigint] NOT NULL
                DECLARE @var16 nvarchar(128)
                SELECT @var16 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'CRMApplyNo_Xuhao';
                IF @var16 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var16 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [CRMApplyNo_Xuhao] [nvarchar](1000) NULL
                DECLARE @var17 nvarchar(128)
                SELECT @var17 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'ItemNo';
                IF @var17 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var17 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [ItemNo] [nvarchar](1000) NULL
                DECLARE @var18 nvarchar(128)
                SELECT @var18 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'ItemName';
                IF @var18 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var18 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [ItemName] [nvarchar](1000) NULL
                DECLARE @var19 nvarchar(128)
                SELECT @var19 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Spec';
                IF @var19 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var19 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Spec] [nvarchar](1000) NULL
                DECLARE @var20 nvarchar(128)
                SELECT @var20 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Unit';
                IF @var20 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var20 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Unit] [nvarchar](1000) NULL
                DECLARE @var21 nvarchar(128)
                SELECT @var21 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'InventoryCount';
                IF @var21 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var21 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [InventoryCount] [nvarchar](1000) NULL
                DECLARE @var22 nvarchar(128)
                SELECT @var22 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'BoxNo';
                IF @var22 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var22 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [BoxNo] [nvarchar](1000) NULL
                DECLARE @var23 nvarchar(128)
                SELECT @var23 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'BoxName';
                IF @var23 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var23 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [BoxName] [nvarchar](1000) NULL
                DECLARE @var24 nvarchar(128)
                SELECT @var24 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'BoxRemark';
                IF @var24 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var24 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [BoxRemark] [nvarchar](3000) NULL
                DECLARE @var25 nvarchar(128)
                SELECT @var25 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Biaozhun';
                IF @var25 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var25 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Biaozhun] [nvarchar](1000) NULL
                DECLARE @var26 nvarchar(128)
                SELECT @var26 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'ApplyNoState';
                IF @var26 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var26 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [ApplyNoState] [nvarchar](1000) NULL
                DECLARE @var27 nvarchar(128)
                SELECT @var27 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'EmergencyDegree';
                IF @var27 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var27 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [EmergencyDegree] [nvarchar](1000) NULL
                DECLARE @var28 nvarchar(128)
                SELECT @var28 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Remark';
                IF @var28 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var28 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Remark] [nvarchar](3000) NULL
                DECLARE @var29 nvarchar(128)
                SELECT @var29 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve1';
                IF @var29 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var29 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Reserve1] [nvarchar](1000) NULL
                DECLARE @var30 nvarchar(128)
                SELECT @var30 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve2';
                IF @var30 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var30 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Reserve2] [nvarchar](1000) NULL
                DECLARE @var31 nvarchar(128)
                SELECT @var31 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve3';
                IF @var31 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var31 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Reserve3] [nvarchar](1000) NULL
                DECLARE @var32 nvarchar(128)
                SELECT @var32 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve5';
                IF @var32 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var32 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Reserve5] [nvarchar](1000) NULL
                DECLARE @var33 nvarchar(128)
                SELECT @var33 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve6';
                IF @var33 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var33 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Reserve6] [nvarchar](1000) NULL
                DECLARE @var34 nvarchar(128)
                SELECT @var34 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'Reserve7';
                IF @var34 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var34 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [Reserve7] [nvarchar](1000) NULL
                DECLARE @var35 nvarchar(128)
                SELECT @var35 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'CRMPlanHead_Id';
                IF @var35 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var35 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [CRMPlanHead_Id] [bigint] NOT NULL
                DECLARE @var36 nvarchar(128)
                SELECT @var36 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.CRMPlanList')
                AND col_name(parent_object_id, parent_column_id) = 'crmListType';
                IF @var36 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[CRMPlanList] DROP CONSTRAINT [' + @var36 + ']')
                ALTER TABLE [dbo].[CRMPlanList] ALTER COLUMN [crmListType] [nvarchar](1000) NULL
                DECLARE @var37 nvarchar(128)
                SELECT @var37 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.ProductOrderlists')
                AND col_name(parent_object_id, parent_column_id) = 'CRMPlanList_ID';
                IF @var37 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[ProductOrderlists] DROP CONSTRAINT [' + @var37 + ']')
                ALTER TABLE [dbo].[ProductOrderlists] ALTER COLUMN [CRMPlanList_ID] [bigint] NULL
                ALTER TABLE [dbo].[CRMPlanHead] ADD CONSTRAINT [PK_dbo.CRMPlanHead] PRIMARY KEY ([ID])
                ALTER TABLE [dbo].[CRMPlanList] ADD CONSTRAINT [PK_dbo.CRMPlanList] PRIMARY KEY ([ID])
                CREATE INDEX [IX_CRMPlanHead_Id] ON [dbo].[CRMPlanList]([CRMPlanHead_Id])
                CREATE INDEX [IX_CRMPlanList_ID] ON [dbo].[ProductOrderlists]([CRMPlanList_ID])
                ALTER TABLE [dbo].[CRMPlanList] ADD CONSTRAINT [FK_dbo.CRMPlanList_dbo.CRMPlanHead_CRMPlanHead_Id] FOREIGN KEY ([CRMPlanHead_Id]) REFERENCES [dbo].[CRMPlanHead] ([ID]) ON DELETE CASCADE
                ALTER TABLE [dbo].[ProductOrderlists] ADD CONSTRAINT [FK_dbo.ProductOrderlists_dbo.CRMPlanList_CRMPlanList_ID] FOREIGN KEY ([CRMPlanList_ID]) REFERENCES [dbo].[CRMPlanList] ([ID])
                INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
                VALUES (N'202201130201170_Change220113_01', N'NanXingData_WMS.Migrations.Configuration',  0x1F8B0800000000000400ED7DDD72E3B892E6FD46EC3B387CB53B71A65CB6BBEA747754CD845A96CBEEB26CB7E4AEEA33370A9884649EA2483549B9ED99D827DB8B7DA47D8505F84F22F14B9072791515516101C497F84924128944E2FFFEEFFFF3E1DF9FD6FEC1238E622F0C3E1E1EBF797B7880032774BD60F5F1709B2CFFF5C7C37FFFB7FFFEDF3E4CDCF5D3C197E2BB53FA1D2919C41F0F1F9264F3F3D151EC3CE0358ADFAC3D270AE37099BC71C2F51172C3A393B76F7F3A3A3E3EC204E290601D1C7C986D83C45BE3F407F9390E03076F922DF2A7A18BFD384F2739F314F5E01AAD71BC410EFE78788D823F48E5CE5082165FA7F33767283C3C18F91E225599637F79788082204C50422AFAF3EF319E275118ACE61B9280FCBBE70D26DF2D911FE3BC013F579FABB6E5ED096DCB5155B08072B67112AE35018F4FF3CE396A1737EAE2C3B2F348F74D483727CFB4D569177E3C1C7DFA32F251B4BE0A5787076D7A3F8FFD887E0B76F29B5AD1BF1DB43EF85BC91A8483E8BFBF1D8CB77EB28DF0C7006F9308F97F3BB8DDDEFB9EF3193FDF85DF70F031D8FA7EBDAEA4B624AF9140926EA37083A3E4798697790B2ECF0E0F8E9AE58EDA05CB62B53259C32E83E4F4E4F0E09A1047F73E2E59A1D609F3248CF0271CE00825D8BD454982233292972E4E3B93A1DEA2E5E247CFC1D7DB7541923020E9A9C383297ABAC2C12A79F878F88ECC9E73EF09BB45425E8BDF038F4C3D522689B6584608D1C138C3B13308214AA2D5899252114697AE5E114A6886917BEEA3955649E7810C20F6CFD2BEAFA8F6DA23F3701B39B86F5279CBE80F01A99377EFAD7114E1FA8212FDFBCE5B4B0B46D8C93E6B1763E699D2DC11B7D5DE087E8A902B62EA0F4795FC9449D5A91753F977192C4303C15A2BBD97AD7C5A79375D87A2A960833D6E221747304B8B0BDE45E859583D2BDC3B45D1B7BE69CC13142557A1936B220310BB0D636F086293C01DAA5D84D450AD9AE3C025DD9874129D4A529A529AC62B011DF2A71DA648B098D0F15B2B2D22DB9181BA2E29E5889E5C2182D3F976EBA360C1C85B0549F6290AB71BA15A74F2EE9D8511232BD91845624236787D1B633195632B52365B6DCEFD308C74BB7D46366AFDCBE8CB38AD9C7D156691E3765164328CBD3A2365B0BD3AB35767F6EACC5E9DD9AB337B75E6FF2375465935192F16536F15A512EEC2230A49F4ACAB990010BB544CCABAD0513F927F3F0E83043F25045B5FA169D0E27398E2006A1AF4EA15E7D23E954A3D23DAE9515241F6172F40946D54A4BA261DF2D3DD3A49CE3CA2769E746FA6FAA40983A5B78AB5274A566CAFB50B799A749198A57B9B4D84F217E46F454BFB0F6FFB994F0A6B409F8BC06C4AF5850B8C5C6D9EAE8A7ED77CFDFE877EF97A361D6D36BE78BF77ACCA5C125ABE472A352025F19192255AB4FB3C0705894499B34B6CE0B6DD3E84C190F4CEF0261990DCAFE1FD30D49E4DF64DE9F6C7E484768E7C9C6E9BFA6F5C5A47E9E1B82562841B9350A0E4F117C38E8BDDA99DFACF30D9FB3DE2E3FE7B2AA7743218A5D31E285DA3476F95AE76ECE245D7F82BB2B73B3C98613FFD267EF0369953D89B5AFEA2A14A9C47E17A16FA4D88FA278B3B14AD301541A1F8BB82E5BBA83759FD8DD41B5A74AFDEF06955EACDE28FED031A40F5B84CF07A081527A533881230DF6091B799CD05641C6E8344B6A913E310A203680E97C12361C0307A6ED47888DEB9B9FED6F692D3F6B7F2BD471C3D9B6814BF844F4330372533086F1342432DFABF7828FCCF87ADC856644B3DCA6C5333EC781B511F9A6CDD396AED75283B7BB0D4B6C91A938539709ECFF02AC20310DCEB842F52278429FDD0F701654EE7DD602D7A3F18A5BF0F6096A929CE0D2F71500B94B848476BAAFC52B1B38DFB3EABCB89D5DDE107DCDF647B16BBFB9B72AB2ED9DF14FB20D52AE76B4FAAAFF8042C062BCE7CB5203D5C6D85AAEA0B3F643669E2AF3B6DD58076E96DD81880EF7ADBD6F3694BBDB3C8C6ED42B871B332C3E9762A1051391D68D366C745301882CA948C6DE4219FB6AA77CF20F126D40A0F2868E856E834CEA8FBEAB071E8573EA27DB564ECA3B8F7C557BAA3B7B165721A1BF933B2755A233246B711F92BBF25FBE3E1C1DC4154DE493D67AEF15FAEC1EE9A30864931BAC2996CE67F255D798F82088BF7A4436CA2EC38DB65C77EC100A2AFBE403D103D096B3B57FD8212E7A17F2F5B99C1C68EE0949A6B6C919132921D65205845D8A5BC24126E56C6E793F78825879D569AA46A13B2E343397EC0FFF450E00CB13C4C66B7E934EC9FCD1B5AA9DCDE656FC39C6E5F986313D52D59636BD5DF66ACBDA354DBBA69EE2B535F3B7E1B48E202D8A9314D00BFE36D27E18FA1DDA4EAC6385B31E45BE3FC3BA526890B08B7CAFC5236B6CCE99019ED95C977FB4D329FD6260A630B373234ED6E842AACA3EAE3D851D434E97AB28D7E3F6499B9A5A92E2E646BA9156D642BDE6A59A1118B77F25668DC4B956BF9A51B253A12EDDA4E63A4DAB51532DE704A6F946AF1A2A32E3BFB41226312B1C9DE4EB41689A9C50A11D2967BB97DCA0AA9E72D0A7C426BA859B491DF2EB4A2BFBB28F8A7DC09C8EA098ED6714837ED95A37F8B55DDCE6721A52A6B7E1A9243EC553D3EAD7A77F5BFCF1DD67A79B3498C8C9EB9D09099A02D1DFB4BCD4E36C884C38C6FEA4233C6BE2FB4CD58310455A4641798ECD0FB1A46DFE28770D37FCB4A4A3D35CCE209BB453382C8C823373E18AD366793DBD1EC6E3AB9BED35D64AA92BB5C5BE818EBAF2E592973396076AB357E8E774358620A901EBE9B51DD10428EB741A2C3D81F6D844C58A0FB983095D369730D53E2CA89F9DDE8FC1C940DD5BC58E41F5562A09DC7CC78E6834E933BA7AF37AFD342AF6E4A4B0F0C7A99593D518DF153372775CF7550D42906871219E4BA11EEA63F2AD1C12EE1C34EC13E94C824D8C71BC9554D3B1DE705264ABB8BD726C536611CD78FDB942CA62EDEA0285963E1F58C9E9633B44D1EC26815892E5ECA62F72A11FA8B68A14EA5C7437E2BEFD5DD56EE5120F674B732E51C477267C60E1D1A6A7E839EAD754D6C11AD477DA03D75C8EE9830490F9294AB78541AC27177F5A37D6EC9D54FCCF61678A3EFC99B16DA5BABF8B424A715EF7B39609B87517219B85DF58E5EE29D00D62B1491BE949D01F2A7186541CEECA2598BE283DACCAAA5B34A7D3D53D735232D76625E19668A433555ADCCEF31CFB12283CDF3DB55499339DD92E575DAE6E454F5E44C5A682F678CE54C3F07F99335F244F602D513245DFF01F93ADE537B03FA7149F79790CC0C1468C3905176B1E890D48EBFDC8317E058F696849D53CB49B0F2BDF861105A8D8027BD1D3FFCF65BFF9712D61B143CDB9A439283A5E5D273B02C72919576D5484D9E7AF7A0B908D7C3348B1EDC0C4268A4608619E41CCF0E9962011B8B4D58761CFCBD2879706B3B53D520DFE81BCED8D62424D5158A93AB70E5052685C711368C204C15B26E4AB3A96A082BA94DB551B52237814F9729B02A1962F94555994606A3A936737535788A015727CD617BA696CCF44C3D4FB767EEBC8457932C8BAD4A3D9DA94B2353B7325FC91EAD8AB1CE1DABE667ED01ABE77246ADF149A76D46C9367A1B8DBCD87EAB21A0754B96A8CE47052AF25C20557523216D5C43314BF952DEBBDDB7E48AC2AE3DAB615168346372C9A7375FD242FBD9C2A7B5938D795FBA1DDF1127FC8B7B8927CD5AE4DC5573B2A9A5B35772EA99F6EC5E0A4B787B5D829677334FD1BC8B349D43D352FB09F6C226581A4976889B08A9D6D6BBB563707931C5C156282EF20F187191A6B3AE77F54C7B1ABF92E8E2D4A529D78C2446DE077A02232DB497172F4C5E5CAED10AFF1E890C7D766672CEE583D01AC88264E93453ED98B155E88B87FF4A27B4B1A5259D8FF0F16426AE8A0F2AF1524F67C44B235357D4A5C5E0E349A5CAB4D534B0A6F67446F122C0D1199B2B8491E02D4C2F7A92372BB517BD2F4CF40EAEDBF0B71F4A76BBF684078D7A466CDDB4CEE93177BDEC9EC5F9B48A7EEAFF2A74416971E5F5BE0B296935D6E13EA98D228C74C34899059F1A7DFA32D4939E45370E122F6798976B2FE39B4D15334D5337A255CCFB029096CDB380EAD34A6EC25F301294F399AEF224B3DD6A1C7EC0565CF07C44E784864E1A6E57A6338A5747F003A69AF057DD54AD6A5C35B5ADA2E07E3592C8809BEE77683555AE90778D5913273BD6B0F01046835F35D7878DADE03C924B249662F148EE220D103A76C880333287B316990CD66A40132B6BF54629A0891D52030518897A0A732A54264812BCF1AA16FDE2ABDAEEAB9DC96EC1982F747507A9FF84B1B203ADD1029DC878914E3B4D7F8926C5F60B349F96AD95B21C686D570556120903E9295E58B1B303D09CB68CC71377621B9B4F320D5BDF7442CBEDE7019F16EDA3414C26BADA1FADD845B88DB149413AEA8DBD7E796340B2A90E087F39DF665BE1D1AF2DCD237996BCE462C34C90B5E82B12BD196E4649BA23CEA32209B6C5E9178B6A7EB3FBE2E617DC8D71EB33933D7CCA6CDCDA66ACC8AB693317AC65EB13EB7EA0869606C864C3B7477412DF393B98C9F0B4F05E90F369D57AB85F59CE3B15EE7C18D48B0CB22B7E78B38523A58CA74B2E8BF4A74A5A703F4DF8B4BE5E0CE13CF6F562B0938D0B133DE7C5CD46ADE5159A859C15D868069EE147CFC169BFC697C1527BFBDD2EBF9F8F7C5A6EDA576371542A3BB18BD1F355887ABF0A9735884C7FDA3BB3FEA38C97F4061137F7E9F88AF612161B3584A476CBB9BA2573B57DDAA15EB6EF7A46D8B1721FA7C19E7FF4BDFB6C50FB875D6ACAE2FC1C5D6C43FAE68BAE1C2F0BEE05B86088693C73A925C35AE474E1499D1D3AD203418B6464C768031C3D5A22827C2C79B8C31EA13FB7D61E490CB78945B4FBF029D8AE6DA12D1FE4710A95A5E055B8D2957FA4C85EF2F16991EEB1728434255B318275851F6D3CC8AA499C109EE238462B911CB2F3100A2135726427E056C2A2534A6B497C473B9488F2E77CBB8B9023EA3E1352CAF37A73EF50EE4D742777516E97337C738F17D91278A4F671A667287E1CE33F59438854825475E28E675F81C0CB069612ECF8BD9104BB4EA3E5C8A9653D341435EC0AD58393773F5889354A2839411269EDE468A1A58F56DA8568E85B11A79C88FDA08016E94DFCE5DA6CE29372BB9DF84B9D89BF5C2CA335E3F4C3FD1892122A137FB9B3895F34B0FBE430203DA4CC59CAE6A61EFB3FFAAE11FB9372BB65FF471DF67F5C3C22DA50C58F4DD9FF7167EC5F347007ECFF3828FB3F9A2C4D8F8B75BCB2BD70AACF33277DAC4E7392D142BB9C611E335DE433C07387DB3BFA61D2CDE75CF13A8030DAA91D2212BD49E3413F77EAC5943DE657FA2FF9556577C976F36B7DB6A3658662BBAA9F843E7F76DE3EB89DDD9CD9B08F4C0217C6919C8CDFCC3E7F9ADD7671B7578B3091E075370F4A7532E2F559EA22AC44682E3617DB21F2DB789EA0C0158726951B8C95688D7D4FFCFE8A9D01BA999D4D66DDEE7CA935E76232FE3C1D5DF74EE81639DFA6A8D37D15B506DD5CDDCC04547EB042E5EAE64E38387664DEA7D9E86CD27B8F7D9D5C7EBAB82B056248162FF98CDBA27C89D029751B79956953ADC8388C13BD12595FE895F9EAB9BA45EE1E3CE75B508B9EA9D89ED17C22E41C4BFC89EEB12F11F0F2E8414AA47E099FAEEE07A2F5D56FFA47E43B2CC95A17CF30D1CFDAB6495921C2AC0D0F0E791985070D2C2D4297F118054E75C0A354BD9BDBC96C7427148E96749860B34D4C94ACCFC83B1B6089C8C8985470B475BD44B80BB253C3948E49056FBDFF105F3EB5B498A7644C2A389B4C47B3CF9D8EB7946A389BCC27B32F93E3DE75CF9CD0C950844E8722F4C35084DE0D45E8FD5084FE3E14A11FFB5F6A724A3F0D46893AEF0D454A241E2C93120908CBA44422C232299190B04C4A24262C2F1A224161999448545826251216964989A4855D52272269619994485AD8B1FA149444C2C22E2591ACB04B49242AEC5212490ABB944482C22E25919CB04B492426EC52124909AB944E4542C28492C63154E86E5337457D9FBA7AD99D1E43E1C8433E3D94D03E8C2A4B0E772415CE3B5D5B323BF9B7753835D429D3A02777FB23ADFD91D6FE48ABC7232D3B545EF191167473E6ADFACD9981CE6CF6871BDFC3E186D4806D8719F6F6EBBDFD7A6FBFDEDBAF3922D2F4849528FE67893F17457A57DEDB92D65E8EAEE8C2A8B7AF2DCAED744F9BD561349D18EC6A6B653B2F369A1BC4A2EF8E5B032884511F511ADCCF24B64159707FC35730F748FFF41F1C73334C9C737974705BAD5188A83D444C752B349CFA35E2AE17FA373EF5C1B310C58502D1A72B7AEFE1348655FF7D2C8EF46E858824E0D90B0EF1AEBE18FC637E3B9A4DB59782ACD84E2FC4A108D17828FACB4155B2B3FEAB3B0709E547E46F3B096E653BE9D8EF340DD5D4614C44CA231EE0D0342334C09969466808F78A8C9275EF0AF5A702B08F83CC2EACFF8062ADEC5E1FE4D3921C565859A77C1A06661CF61F0F31E5D7080E2A275BAF03D7934572B114F5AE9738A52D2A4BD4FBCB7AC87523DC7F6CE67B14F4DE5B13B4F62CC42992CCB4EDFABE9BD7B692E2998ABC290AD04A48CC4EFC236FBDF1F19A101C80D60A07AEF09CCB0E9980DEA8110B453B84C88FC0139D649890D1789678FE40507FF5CC1ECC6B94DEAFAF025AD4486AB22255915845AC684766A068283AE53312BD121AA3087AE84F5CE8FCD8A0CC89419953FD32E37C8444DB0B2B3D777E3C08279C9F0C43E6B40732EA2236DC5E79289C61273DB1D694B0F5C27B01CBA735E3459196DA74856F9359E1BF2DD990547D61C744A7FEE806F608CBCC7192A454351FDEA817DEB31F9FD6372C8A1C2FBF71ACC24632939C1D2AF869E351C363182C6083BE0A178EE23874BCB4678BA56B36A5674E575E9C2CF2BF2F30725BBC3009DC83ECE50BCEF7D50B19592FD057366A9F92FE200CE86D08CB915A7D3CFC17A6B5720A2DDDA44621AD708BC2F1619B796F8233ECE3041F642161E9AA1D3BC8653B9EF49DDB4C21FC8E23CA70C81F87414C66901724ECE4F002C7DB205FAD1DADE28AB38B56AF24D4CE39C364CF422786DA58A9D4A05EEC120A087754126D75A2ACCF3E1CD59851CCA3B993FB4DE4E2C8278D89174EB42E598BC747C25210BF320574B8564C8DCFBBD0EC78FBE6CD3143CA8807956A3500272A8D85063FA6C5E03A0DC78FF4993A9667240C02161270636AF2D46643980AC085529EB7CE8BC2AA0DC78AC27150A9065378D7EC98D6E481086AA2FBE9F3A5B8B44C5CE60595984797B409D7B253A4B3F894F6CDC06254DA61BA4C9C01EE4EAA9E4D6E47B3BBE9E4FA6E31BF1B9D9F7339B6FD21C49CD537AC62C867480619E0BDAC6EFDF01BAF652A43E984AC2AABC55CBCC6AB1077F10645C93ABD21B41BE6C11BC2F9E9FFC77CC6A97D04320DCDD194610D4C805D404C5BEC02B467002904355949D820DAC29DC917EABD162F6E02DF0B307F396C7C053149FA41AFBB4D5E6500EE2A5AD30F7F817D31008381CD56A1FB7B6ED0DB097F4D71B08D17E9FF7C1154FF08E2AE344753043530012601312DB108D49E0138046AF27720826EC3BF28676703C2D58A6B1F817A779AAFAB6AD74107E611A8414328CB409355C87EF1F05F69D95DB3096D86944DD28FD4D944683BA823023C92D5470CA8D1CA8C4EB69CF2AA54FB066AA34A8DB878400BC1B5DDBC85775E226F62FD23A88D59BE4E231B8803B43242CFE939EE82FE45E613BFA9ED2FC1F6161FE96CDC5864A0DD45F5FA9172DCC60D20EAB8CD57A15D16DE99BCA36FA85F854E9AB4A8C69F37D8F0E7102FD5BFD45C303944386C0532AC25C612377700EE1277854A051A083B65B35184D1D84771BC287E09D98CFD9CC766E597067C065001F8ACAC707F6CC66FEE406CC6EF094536DB2D775D84DB18AB7156F3531E57A55F1970540B7D37DC043771204E827B40555865A5772EA9168D054C26421A5F8BE494A1886AE273788AB7DC5A9652605B071452605FA872570AB0633BA81267B19F2A5B44253C0520EF86A1F84D1CCCD069CA4A3B3FB04BCF01C4BBDBDA37764F5C3AED6E4D990568CD005C023458852A2D36106F64CE86A44C424AE0A83088872EF617D42915706F25CDC93D5CE3DCFFB13DDE14728E931C6CF4E9CBC847D1FA2A5C1D1E54CE8DF9A0377219CE6190F2B89697C13284C11A1F68E12DCEFD90861690A0169F49B0C78BC5D45B4569975D78A40BA367001AFC4A861C064B6F154368458E0CA1EE7CC9A2D473D5903257381E52962B41021C43183CE01B35D47411E2C1A5991AB52B3D6684F52BBF9220D7DD1D18C07AA60427776E6020F274592D3269CE56204B9794CE0537533A4F97942E4F4299F2658E0421372633E5F374D9D8E6E6767638F30C49F9FC0086299EA74B4A174662A678912129DF54B4189466B6AC2E953D8CAD4E95A780921A6B418C3447A14DD96E076C4F96A588915B76B84079BE025ABEA30791F23CE92C2B6F1EC69C158CFD4482798E2EB66116D48B01ABE54950E0B559654D4E9F48C72E24FEAB2C158CE59A8B9166A960A44FBCC3188FECA3E82C46F67C350B90A54BD788FA9BC4C0E250CF565EB7C09E6D66CB568632901FBB389459328C2A741C0B52E5C9508A98432C469123932D8DC025AC8069644B256FF3A23620819B1FC8F09AB71259B866BE4CE2342F99B152A799DF42AB69FBA0B2D6B8307450FB9AD5DCF8778B1A7B3BD9EDA2B27D2DA591D9E3A85F276221419DF5A8D9190A1D25BEB5027497C63597460BD52EBAD4DA29D58035E0F9DD082AECC6DD085FB6E0F7A2C2E50CA895E2EB196C1F020A913A2CD077F2CD493746E4DF0F9030A4E2C5022EE7C8AF16707A81B3053220345077337EEC40CF8A7DDD9BE62E9EB77BAD19FC1D9E180AE81178A767D00B75876CA807B80EDB80B1AFE5B25D6F39B4B5E423000D8637A7FA0D6EBA17032D16F81F03A6F1B60772ADC6E086580001349AB727D66F76C3EB156835DF2BB65163D02FB65661701BCC47009A0C6FA40DA469DD8713129A5C1FCFA6C882BC3CEB9209341BF021FA6F716E07E1B618705784AADB7458346A71D343B106019B6AF45B5C774D041ACCF55C6C5416F25D94D5950B003416B68BE937B6E1A508B496EFC5D8A82DE8C758AB2E6C89E243F4D962C663116AB6D8ADB15971AE6363BD0378B62F0914D0113C13987E57705CEF80FE5071D26BB444E2A6576B8EC8BCA802C9E92178C36DD64780DF18A78F641E664C83043E66AD3EE25A1A5530814EE29A41CDFAA8E5FDC4E91F918F14D30E8E9754AB0DA0DD5486D57F7FB01E3C029611386480A30B7B65283446018DD335DC1300536559D637324F1540E795F58AAAEE3C707FD45D29B89B25D90A0CF95A186C95AC2DBF4510A2D22FA0CCFB7034771EF01AE5091F8EC8270E21BE457EEA3410171953B4D978C12AAE4AE62907F30D72A875EF5FE787074F6B3F883F1E3E24C9E6E7A3A338858EDFAC3D270AE37099BC71C2F51172C3A393B76F7F3A3A3E3E5A6718474EA337DB5E0C25A5248CD00AB772E909BA8BCFBD28A66FECA07B4425D0D85D339FD5BC2038B6DA8210EBE8C00E5561BF2DCAD0BFB3725098300156D595E7A475F4E676DA505C1B6F6169529EBE41812220B8D738F4B7EB80EFFBC22F9D45D5BCDEAE9B20B564752C9AB43EC3B1D3C4AA256B62D1BE06B0B2640D2C226F6928A506509EA659A31946EEB98F5640ADAA2C754CE7010501F6B3D3C37615994CCDBA161289A96991A15D4FFA03AC6396A1CB29A9B2C8720AA8B0F3B1A222DE611DA94CD49E094C13EBE99A2DFC14A5F7CF9926E6E92CDA87A3968868CBA3234620B5D686B68C53958075FF2B0B425000A726078500FD88C2DADBCB75905AB23A566ADF66D9B296AC8E457756ED4A15691AAD4B83EC371A96A6A82390DD5D94542A581DAA95A589795B3EA9C3605659EA9844BD826BD9C8D0C2836BD8C8D068330EDC7CA7DC686F95AC87358D572C529AA8350E096681CA5475A4D936001A57A56AD6899D43B5641DACDCD961D19611CD1CCD19FE290AB79BF6BADDCC514724526F8CA2365A95AA8E9486D96DE11469DAF230F59B65BA8DC9D4E090FCC18F067FE469EA289771EED0DB10F831E8E59BA2BC84A5357742B6BBC0C2A0DACB2C0F66BFD8EE175B3EE67EB1DD2FB6FBC5F6B52CB63B5A24A1EB345DD748054C85255209853FA679C9367B3432D4C792DA38F153F29946D8AFC3D5D335388E9A495BF5CA92D431726FAEFCF18326583BEFE5705B7EDDAA3387C1382A5CC52BD98FAE959183D8A648D6C5FA923DC0C0A2E519AF4D3E095DA935B9868FA5C239A2D23D71CF6C3ADA6C7C462BAEA76BA0A55EFE0C5699AA8DC4D86BEBE91AFAC0865E5D4641C2A804F50C033CB682AD2C03CCDB8730E081E67906A8F43092039A651960FE1ADE7320D31C3DC467563FAD256B6A93ECE9432D5943D7453E4ED5CF96A25B256BD60B3AB5696468ACCE0F61D29A6879D2D0C69AEAD5E9264E91AA8D74022231CFC629209D8248A72F6FF5E1DC49315A7D202CF5D5072EDDF7EAB3F8639B5EE783D7A02257C38098E0757B1D2AD2345118115FA56A48920D6E1D9C67299AF2237F4B91111F79BA3ADAEF81D7C2C95234FA2678245C44B64C409DDA7926ADBCB9FEB6E2B534CBD339FDF5BD471C3DB3CB4233471DF197F0A9CD5E79921E06C35C65A2160E24C86BC91A581E0AFFF361DBDAED55A9DABBC71976BCB69F472B4B534FB80E01AB583347C322B9C6D10A07CEF3195E45B805CA64EE575693955582F40388F48301D23B10E99D01D27B10E9BD01D2DF41A4BF6BAE928D47E35A6BA4F041393EAA13ADE9524F670CBDD6D2F0FB69666963B29E5D8D8C17A37BA95CBED4D3C0A4880A7A9802463FDA589D30D1B82EDAFA1894AFA74B05804616EC4823BB0C009C4017654AD69BC8433EAD41FB4CB09E33A4A6686F0DB761452685DB07F979928E3528BDA5D13404811737F818DD35DE5B075075CB44759C6BFC97CB283065A2D6E8B03865A246BBC802C26AC655AA3AD2AF44AEDDA320C22DDEABA70FAD436516C38099EBF5743319590B18C913938298927C1ABFA0C47960761745E27E8F7219106DDCCDE3C934C5772D431DEF13D901B2E6D12A75B77B9EF103FEA787020710818D1C8D3DCFEC3665CE3673D4D30DB506606706E56BEBBEE503B580EECB7DBC76D77A257CC1CA48A104A0D43549B0703F2AE4260AE396ECCF93B430D865AD4CD4C261A57E99A88EE3018AABA7ADB8325ABD68D9E03E80CBC75F0002425B326C191D69ABA923C58CF61A6B6AAFF7D0EA77AFBFFADDB3ABDFBDEEEA770FAD7EF7FAAB9FC75BB13CB3152B4AD7CC9659A84CD49A2209B3572F1335F6FDAC8EEFE8EAF884EC3DB8716964A8E33D6F51E09372203F31991AF5041D183706DE8B2E0AFEC99E7A54A92F6D3D6BC48FB26929E1606ADA4AB828FD5B4BDAECD5CEFB7EF786379B84C52913357A2B9F1FC04EBE9535F4FE30840630D41FB9F4AC608C7DBFD5BC7ABA091AE08DC564AAE37E0DA36FF143B86955B2966C800554B19DF76264592DB65B5711C68752905CA2C2FC65B67DE1147EA59C8F103FC72C4899A88EC32AD6BA5AF5A678AEA1BDD897C91ABA2FBAA7AF2B382DDDB54A7D31DCC78B4EA8C778208A02CF71CAF5C76EDDD924C64F2D66A5091A9AB7EBA0A8756656A4A9A320D78D707BDD2A13D571B0BB25EA7E13A648534749B08F37AC93602D596767C22EEF459A8E7FC59A852913B574EB98B52055A93A35DAA028A1B3A05DA92A5D63FCB7C94318ADA2961F602D591DEB2FB2323A6D25A14CD4D927072DDD274BD16895E3B0E71965A2063F7A6BD2AB2DFFF33251A745318B5326F6BA1C701992A8A47F856D0152A5BE9885258B46D459A38150549419B85C3F1B2FD622A36B8E9987517219B8EDA5A5963CF426E416D187A218936099FA62F88C17344B8FCF4014053EE3947BA97C365923AFA5DFE6493A9C0149A05B8104E2D62640F77E5BFB2813358ECBE863672D6B5F91A673AC4523260311791A193AAD5BF95EFCC0E2353234FADD827BFD6FBF3501E86F1DC789F50605CF00133573348C39CBA5E760E07E4923C3086FF2D4764B6EE5A9A35E846BA88EB5648D3EC4BE0F60D592359C4FA14DC0487F13602942067D709086C663B637CD1C1DB7A1287970DBFA5795AA8E7487BEE16CFCD93B3DED3C75D42B142757E1CA0B58D05696067F4418BC195F4F57472B9E88AC23F19E8DDCD90ACE8F98AFB78673701456716EC97ED6F1CB5B324981A95B4FD7E0420E079A70DFEF1B17E4BE7ABA061A0D4BD0EAA922EDC5701F2FAABD1EEF81280A9CC729F752F5C7EFE2FA74FECE40E7F3401046E5089053F0A50E6A7A719485A9256B2CB434C27F6B7DCD925E1993F19EFFD0E331104581C538E55E2A875DAED10AFF1EB5360D55AA4E5D1EBD15598A18B046C6D0AAAF4DF38DBEE18587F4C5C37FA5B2A80DD6C87831332A7F3FA4EB94826114E614AFE04B9D54DF859894C4F6D71B5A1198C2008B8BF733CC05CDB63B473D5D1F6D71E5B5BD1B1A39068880F86AE7E9A1A6AF4EB43BAF91A18EC7B9D760749761F4E90B1CF1AF91A1DF8380A3792B4B438BB21215F232BED9B4EFBD14692F4640881E1AD214FC3C2415D9CF2FDB8F5C4847F3061861E69165114A08F9C285FABE7099FD030AE550CFD09F13E9E32A900C68647EAF0EF42FCBB39CE91703AFF097E8356DCFBB390214A6E8A5294CFCB7E8F4A52180A3280BC192FD48425B32AC14E1EDEA3432B4F858F9E2D00E956BCE1B6BFA8A3504A4A854C345FB53A821655A5B9186D625CDE5A87A740E5AE3AA1C7DC599A34CD6B234D4C020A6619067DBB661AE9131FC159D9CFCD7F6F95E3DFDC54DB5EC4A80ADF906A2694C3A4EF97E665EED71CAC6B689FF66251F6B77FE4E3BE49FEC154B1BBC032229F20DA76C4FD2FA82D54B8B341D1478C75E4FD74183A4EB85B65CFD2EF82E7BCD2D6D5B6CE5B12D19A00217CA21FA61C6EC65B5317387A09EAEE388FB7C1522C60F374FD4AD156164CAC7B3F68E92CD354006A64E3B4F6BCF9AE088F189CE13756BC78A07B3F7EFDC92A7B684A71817FB56A6192E1F546F176AF3FDC09C33FE1070CD1FC6A8FF10A0FEE30509B97374B10D69E08DCED28D8BA420D604657B9267F45E36AB8AD79235B1DA26B1327168CB5A5A82910C55EA9036BA18F9988D4251A5EA21FDB90580D2440D8BC93661608A342D9B61D07E86B7485347593EB0C69B22EDC5C8071B2F2D9BBDB03CE0CBCA84143B1465A23A0E7D398C14BBC28F4CA0BD468E56CDA6388ED18AAD5C99AE8536725885A696AC87B5664F3D6AC91A5BDA0439DFEE22D40EA65F4F7F31336273EF10B670BB0778E70129CC0D7E51AECA7D8F17ECB250A56A28EFA40C60C42A53F59062FC67DB525CA6EA2161B7BDD054A97A484E90442C5296AA87B464DE1FAF52F590E89D5216294B7D595363B9B634350020D5A90116E577EF129C1A4B83A9B15C2CA335C38645AA1E1234C99606936C0932F492CBD0BB649E47BFFBB34D3C2055E6018BF2BBF711649E4703E6795C3C22BF6D152953F59020E67934609E4790791E0DA4E1E362DD7E47B34C7C394CE8D0605D9D39104251613FB81C77ABC784C2D019113F4CDABBCD3C49E700BA7D77344BD1D804312B246F75DC59B834377FD3737E65214E1A1F4C813FC4C5B9DAF5754BABBED6F2A92E69B271D15CA337A06F67374080EA22511D6712B82C4E99A871A87133FBFC6976DB3AD42812350E655FDD2B45BF8DC90E2C70994BA9F57475B42C467713A948D3F0B79B9D4D666DF7BF3251A3361793F1E7E9A83537AA549D5B07CEB7296A3FA95A246AD4E8E6EA66D6AA4E96A4B12BBFB96BF74D9EA471A769363A9BB4EE3365491A736A72F9E9E2AE35A5F2340DFEDBA254F8B5B8AF4CD591625EDBB89027698C4F18B7B9374DD1181D1CAC9287D6F0E4691A7DEBB96D903C49C3E3EBC173BE05CC2DDA5AB246BF8CE69336D315691A7D83EEB1CF0ABE5AB23AD62FE1D3D53D00564FD7E86F1F3AC3AA5275BCCA6738D9468C5F7991AA8344D89779A8AD48D4915DB602925CC66314386DBB6795AA21E16F27B3D15D5B1456A93A6E529B6DC2EA08B56475ACCFC83B6B0BF9224D1785AD523D5DC3AD68EB7A495B032F133571D84AD5923538CAFB0FC67DB948D34501D4C45ABA86BBC9643A9A7D6EB99BE4693A28F3C9ECCBA4FD7E5B99AA8DD47EBFAD4CD5466ABFDF56A66A23B5DF6F2B53B591DAEFB795A9DA48EDF7DBCA546DA4F6FB6D65AA36D28F20D28F06483F81483F9970E65B9835DF9A6071D8DC84CF8F61463F36E1F46398D58F4D78FD1866F663136E3F86D9FDD884DF8F61863F36E1F86398E58F4D78FE1866FA6313AE3F86D9FED884EF4F60BE3F31E1FB1398EF4F8CE43B47C09BF0FD09CCF727267C7F02F3FD8909DF9FC07C7F62C2F72730DF9F98F0FD09CCF727267C7F02F3FD8909DF9FC07C7F62C2F7A730DF9F827CBFF3D7932C9C988BC094CCA7A2E25C335AFAF063DBB057A5EA1821C2795B33CE9286379EDA327ADA370FEFCDA862B4BD195552A3BD19B51703DDDE0CA656A3976706DB9B3F9491F6E60F35A4576BFEB06932261AD059E2B32A5F91FA629474D24F97A32BB21C7455D079400ACA39BF285731CB4A8CA6AD55B69EAEA1E6E5F48F413070A5DCD568D12BDE56AEEC709154C68B5F963BB7BA3DD14768317B8C3C4DC30FCD52181C5BE167369643BE74BFB4033C23A3FD88CCC6A747F44C3797A97A4834EE318B94A56AF44C7A69B6D537799A4EEF740FF3C3DE7DD60D9AA91FD86757B2EA1FF3DBD16CDA5D52C1382A728A5792DBB72842F4BA5CAB6FCB548D5122651ED9D7146BC97AF68C71FBA1A932514357C264DA3CE2B6165FA66A23B5B5F832551BA9ADC597A9DA486D2DBE4C7D31F3E20EFB38C8AC3616C2B60AC0146688B8783F8B396B9AD335CBF9F42A1D1B90A096ACB13450F688D8ABE5F5749D2522703DE09A5D3D5D1D4D2FF21A0F65895AE162D204F5F2B6DE4CECFECEDD04AD996798B2240DEEDBAEEFDB2A4591A631CEE99499A200ADDA60AD2C754C6FBDF1319DA56DC446863ADE0A076EDBA65AA4A9A304D42B9099B155AA3A12F911B4AF2D14692F47387BF3071CAC7EF52C055715C2A9086809403F223A3579B032B196AC8E5505FC00239668C70F7250048055A95A4877285AE1F68EA74AD6B0B3A30888035BA5AA239D1F034065A206CE098473A28F730AE19C6AE38CF3113A61BAA848D6E9238005CA449D3E82704EF4714E219C532ECEAE845BB8BDF25038C30E3DD9E82CDB44682AA24D5CBE1FC93683C208CDF4C3086D34C29CF230B6C03B4FDB97F6CED357EC919127C90949EB1E854F84A6C03392F2FDF0CC37DCBA859226A89707EC00DA3600FCB4F1A815220C16AC718DC91C9E7B46711C3A5E1A9C9CF3B0D4227BB34BE9F5A8E25BF88928DED3636EDB6A5CC35ACCC36DE4401A9812C3709F7DA1FD52D2D5AC52AE6518568962E8D5E8C311384AEA0399553B7BBB57E561B7E253F0F536DE03C4ED2EAB21751C44FD1E9356A8DB10F21EF5EB7108B3D77AD4C6B0F92DFCEE8FEA28D6B13A0E630A65611C1B557A79035948DC711824C80B70D4FEA414E9794AF93B2E12E890A1159E862EF6E3AADCDC79C06B943625DE20872AE1E48B732F8AE93137BA4731CE3E393C20757FF45C1C7D3C9C3FC7095EBFA11FBC99FFE9175E67C5075314784B1C2777E1371C7C3C3C79FBF6C7C38391EFA198FA4BFACBC383A7B51FC43F3BDB3809D72808C2246DFAC7C38724D9FC7C7414A714E3376BCF217A54B84CDE38E1FA08B9E1D1C9DBE3D3A3E3E323ECAE8FDAC573582594B73F152871ECFAF5A1AEA931F9008F3E7D1991615F3381C83E7CC60C6B15033CC3CB1A7F1CB5C6BB5DF003C053B4061F0F5307A674BA7DC264DC69B4A7DB34506850BD097C7870BDF57DFAE437B5E7F931B3E8B7E1F3F8A0344C5D4625784491F380A2C383297ACA6EA27E3C7CF7B60E9C44AC92D2C6A5B3637D8663A70FDCBB346649AD573431228C2EDD2E00B412338CDCF3343085310EE98F20C07E16C1B7AA91CDAECA65AA5DE4BCDE997D5E807CF2EEBD19DFA4FBE30C9806DCCBB4573DA032062C1F466782C89A6A383C9F22E4AAB3725D1B97C9A9DCD19A8D08FDDD8AAA9AEBB888E7B407E226728B139D6E2C57BC2966954DA6E9B18E55C87982A2A47CBAAF07EC2A10B6556CA234F5546BAA8EF553E7390EDCDCDE97E1DA839DC6AB7665FFC71A3DFD4F83214B700D0CAAE1F15BED2ACEB6411F0D4FCA97D3BB4DD6D2596DD1125B06C2237DDB59B27E9FBC7BA78B4DA4F81845325CED2E4C6D8962D0637D319509E7733F0CA36E3D5A3CFA60751A5EC669CDFA5E69171995FD7ABB5F6FF7EBED7EBDE50ED97EBDDDAFB7AF68BD555E2DC78BC5D45B45A948B9F062B2603D9B2C9625C625E023047C4F6DA5F829F9CC9ECFC917D9062DD110363B496985ADD74B007DFA561F3A35EED644C1BD17A0E89991574A58B7D925F92F388A6502FBF44482AECE2A61B0F456F12BD1A5B2D6C806DA8C8508F097ECDC5800FDC35B032652120DD664C36C4A97870B8CDCE107FDDE5BF533EEB3E968B3F1656AEAF15BFDF53E3B6AE90F5866F13481A67DE1392848A4EB6107EC7E6B7EFB10063DC29FE14DD21FFAAFE17D2FE0CF3634C454B5B361FA9F231FA72AA2F5B6A65554385231C1268C9584CC8A2D14E296D4BB5323D8E27A90E56EA86E0BF5037CDA1158773DBB226AEE6B5CCF167F6CE9CB04B647A908EBD3076C1FEB4216F8A70F31937B5283FB3AA5B1FA3D7D50CF7647068F8475C8BEAD51BD1E5A7E73FD8D77B4AE786EEB7B8F387AB6B1A0FC123EF5C09314B50F9624B83D09FD5FCADBE7B6D7BE6C8739C38EB711778874BFC15150AEC38671CC5ACD276B1CAD70E03C9FE15584EDE3EF976FBBCB3717F807CB86E81CF65D5FF57DDF17F0DFED6F28AB9DFDA2DAF8152A4ADB77EFE7CBC0C54F1F0FFF2B2DFDF3C1E51F8B26C0DF0ED255E2E783B707FF4B7B5970A235D5C88A0865560DBD3976DD3BAD6F2533179C6987F884F66BB197D5DB4534CD0B89A6A93F5697F92BCA42B9DA8B966970781DF4003A250345E3955EA6112CEC9EC1C97462FDE152D23CF4611B56724BAD1F67B15FACD673ECA3D8B6B452D81E68AB714E6357E012756E8D7CEA0D4EFE8A53B76E1A199CFACE93EC135DF86BFC976B419B27836E0386AE48363617BF7AC1EA1E051196A9D5765447A323EBCC241CD897427539FF409677CC1C662AA80720084F4B50923645D02EAB6D95EF220DE4A2C21ED2085561DF61B0E806648FE4665165ECF6ED27B2D7979ACEF52BACBE2F357037183FE07F7A28707A90ED93D96DCAFDD6F9ADA197A9ECA80DF70A548F5EB0E64CF5BD420EA02E0574556E7A12FE3A74ED4D7641DDEEB93401952DB2AA389ACB8E12AC2757FF0D5099DD58B7B52C87E8B292C9858BBEACDDCA14477DC858B663D087BC5758C30DBCECEEA58BB841551516717D54AFB7C5368B35C6D80E8D344B32BF1399BDC4E0829A740FA68FB9A9475FB58AFCBC45814FA07B62D98D8AA7ADBE2AE0A2E09F2A47803D58BA3225FF35DABAAC2B6C2F6BCF7CB349AC6CBD738E969B454CECF60A1B1F6DD4B097C14DCF9EC6D8F725FB07FDBD49852C772D3480FF1A46DFE2877063BDDE25B0856A2B8BA6B3C9ED6876379D5CDF99482407884C2A974959A9D25948C24C4A72287E8E7B40AD6BEF722BBBE29EC00BC8861CF922DC1F755907DDC749849C44046ACD117E7E373A3F7F39DC726C7F5C0D2063FCD4C5E3C3739DF4DD2C55F655628A229EAD394FB0A0D8DD12CD5CBDF3543013ECE34DDD35D54EFBBDC0C67AEDE2B50D18A2C8C6759393C16517176F5094AC71C04E7385CD7955BAB927EF2621D1367908A355B4110D9D76208DBFC84AE8D414832D59D23DA77116F3DEFC28260BD1AC2AD595669AE3D4CF8EEC80522EDBA0E7DE3A21EE11DDC67A04CCA1F201337331A1AE18E1CDABF148905A68DEEBCFFC791825A994E9B2ECD9B8A4036CB150443ACAC07E9997EBC1F00EC4947BBDDC64607D9EAC91277666685963D4AC132D8161ADB601FDB8E60DA6CFF9643C5C2C36F3191C403D78018EE5019F0C0C719360E57BF1431FD08DCB23B68C16BFFD66DD3566BD41C1B336A32A9996964BCFC1F2DB59FAB5AE214F9E6C9F7C5C84EB5E2A4D6D377DE08E9A1B225BCB4D3F8B58219EC7484B7EA939A445C9835B297FC6314CD0379C31988D2B7457284EAEC29517D8001B47D852EC07AA07EAAB1259A91E14899BC0A732FE95A81297B7644EAA4C4A6D66526124B59B481BD71227151175F538292BA5E137AECC4A40CCF1EF9691FAD049078D20904551DF8F061733BD14DD83AB411A32DBB6F63928EB4C71B0DD738EA0CA6BB4C2BF4762ADDD6090AFD1A3B722CDEE01BA1F95D28AC96638E30A4BFB8B87FF2A9FADD0235F2BDA835696C5DDDFCFC15E195A7934BE12562B83FFBD8E31299A64DD7FAF005E5C79B657D612BA21732C828FC826CFE0CA45AD681761647CE5C3CA358FD1A72F3D45A12C86AD0F0FF95EA29E5EC6379BEA0292BDF0B8B4B2C01395DFAD0C493BFF46C38D4B093594BBC529E164868DCE8143EAB2DF5036D48A7799A11B6DEF7F25A7065DE77F2B2EECFACE173DBAB0D73BD5824C92FB5BEB636E14FDAD0D90FB71888E4CEF5B6A495342F495C8525B52AF5C63F44555AD68A7A8121BE915AAF7361573AA79BD1226A0CDE94321375BB73A2E57B43117E136C686AB6651B66B1D287F3454CFD6E9BADA5DDD9846EC9E6D25963D23C19E3C4B43A418D6F72B1287D895016BCFC3EC0EC2EB988C557BECCE4799D1CC9A39CFE2D8A673F1958CEBD78B1E8CFE5F2FFADA3C5F74955D43F24AF6785F5AE3F8153DB6963D7B37AEDD1BB0758D123D5F85C8B63B46565DC290941F67D62F1397F07DF0FB7D3A583A91E1D5ABDCC3BC774B86DF1286E7191A74912C57D2EEEB8F395FFD6159656980FF6318B5E51C5D6C431A20E3B5C8297A0B59419D34BBDE2CB11219C02AD89E4C516553DD00576AD432C1443E96869030C4FD73DB5BF0B1709BF4887E1F3E05D51BCCB6D1970FFAD7AF9425CAEB790B9BB4C48A418A3E2147B0AEF0A3567041D53A4E711CA31533D78DC26F10B89123B785EA5FC4A6C06B6988700360A22E38DFEE22247981C1DEEDEECDBD43D9CB2888FFE61E2F32B97CA4F671B692297E1CE33F03FD4954D529EB3E5B97B2CBDA67B0311160BEC9E953D5320B40D8AD161A984D7ED0DEC010582748A20E8A2F8558767B3A9E42D02B9E05043B849255428FFF976B43FE5FEAF0FF72B18C0821D58FA1C9A2C2FFCB7EF8BFA8BD32B729E35A9A574B3DBED5E39047DFE8D9AECDFDA30E873C2E1E91AFF6E81FFDD894431EFBE190A2F6B639E4D116873C76976C8F8BB5F86953A9C855E73B87869F32603A8FE1203953786EAFBAA71F264128EA367D1B08FD6117516BCDD288ECE5E6AF99CEAF4C46737EAD3F9AB44C8FA35935E95A38A8FA110D6E6737B2A0D38AD76F5D1BC1ABBFDECC3E7F9ADD0AE7BBFE515EE30D284B0E6EADD0FC2667F4001BD5EC2376107F1B930D4EE04A02D9189847B210DE763BF56676369955EE7076467F7C31197F9E8EAEEDA2DE925DE3140596AB7A7375331341FEA07FE9EEE64EDCA1FA22E3D36C7436B1DBF0AF93CB4F177705E6D20F91B6A6F0DB16E5B2B503C86DE455760023847118279D00B24EEC04F1D5733B22DC3D78CEB7A07605D4AC2F46F38998F90CF819DD635F26780D6EF7FC123E5DDDF701FCD56F1E4841DAB49A47F50C27DB4868C650C3214C5E096E539876180F4BABCA653C46815399394DAB77733B998DEEC4C2D4E4BD81CD36B1A1E67C46DE99EDC523C3B451BBD1D6F512B1AEAF5FBD14D446ED6EBDFFA8B9F05A5ACD534C1BB59B4DA6A3D967F17E55DB463D9BCC27B32F936311ACBE6A98A39EF4827ADA0BEA0FBDA0BEEB05F57D2FA87FEF05F547CB623C87FDA91F58EABCD00BAE708275C0154EB10EB8C249D6015738CD3AE00A275A07B9289C6A1D708593AD03AE70BA75C015CE3773DC13E17CEB802B9C6F06A1D67358E174338715CE367358E164338715CE357358E154338715CE347358E144338715CE3363D853E134B3E6607C5BBE3765E683304F9FF9A4F6546D237959B25753793817EE0E4CDE61B26424EFC5BADDDFD9C0DE6EBEB79BBF0EBBB93EE4F76837870286D3BD92A99B671FF6DBBD39F4F59843E5B62E7DFED89BBAF6A6AEBDA9AB3F5397B5230CA2769E25FEBC87183FA4E197A32BB2F0986C4EB2B2A3E9C4607B522BAB2A26D59E65281A0477559778B1737A47FD155DBFA24DB11EBE61D34BD41F95683A2FE955D01EDEC46DBCB063FB92D1C6A70E1D16EE5C52201AB1D9767FA657B4ADF7A8FD8766A577D77714F1485DC8FD637E3B9A4D8DDCC15184E865467D415795545542D49891C03ED6DF92B4675619FB96DF959B61326B1EB16D2B7D866ADB489FA15A3F11CB60BB1D88A9C7E3C23E0E3203D16B0901736D7FE1F5E93DC81E2249A4231DD97855C00903D7935F83347D29DD32E812D90E048B7A793FA2FE46A025C8095A4B5E0ED2C7BCDEAEEF25CA86BEA9C54985C2140568C5621BDDD4F5D61B1FD3A7272DE1AD70E02286DF8DA002EA7C0AC80D2330F223F098F03056A3287AF30732B0BF7AAF29306D6A27B0210BABA02C62796D302750D413EC1D8A565872D35CFF900245A248BA2A10E7C79D114E3A239C764518E7E37662B983CF8FFB6087F3935E504FBBA3AA0BA8707BE5A170861D7A42F13AE4D34C1E9049D1DC2209B4AA3FB6DBC69B523D478DC4DE1F5E30C749E205AF256CCA372C8E5D667009A3B1E3B6058A9F361EB51184C14266A7EAE2AE933E4265FC2E58F934CB91FC5B4AC4841F0C9F7F913CFDA22606F22AEB51CE4AF5F67E9BF1C3C2F000809F160FD7E98ED5401DC6127E692FED65CF03190F555ABCE7B12A69E8F5595EEC7B1EAD511C878E97922994C6D9949E0D5D7971B2C8FFBEC0A8ADCD4C02F780F26AF97DFA4DDE8A39F6976F1AE9D3AD9F781BDF734815C8A27CD81ECA9BE00CFB38C107594C2BAABAC60E72D9DE23CD702535A135876A92A5376BF22F0C01C24C98BED5E5217F1C067142D69D206139CF0B1C6F837CA00F5ADF2AEA02B469256A3BE70C6FE883D941023454855CAD7A8B4B2806CB5149A1D5DBB2DEF870546320315FE5DEB029C7FAA4E6F1C289D67033BA8DE9DB376F8E9961AD10997A347081DC3E394679083B720CDB2C0DBE4945015C81E1F8863E49236985BD415663A19AD5B90E9B26F7C23466A368877598D7E438D4983AEE9A71D29A64AF8EC5861C9497E6F25099FF1D0A22A81D2F5620B195DD9D5C3A9BDC8E6677D3C9F5DD627E373A3FE77252F5616380EBC96DF588CF3419A93A4E9ED20B73D4EAA8323C4EC86A6C5A5C01742487948B37284AD6A983FF6E861F6F880A93FE7FCC1F7A9ADD1CF52C454B50A46568693992AD714FB107100355D394A67FF9FAEE4E863CDDC22EB2A7FAF80B47B6D1AD8F549E32C81EA8A85D9D7E99D60BAF001BFB7E7805EC780E29D81030109FA44F922FD2FFF9A2217BB7BC3E4C798A966848CB30A20144B234DCC07BEBFD0C77D5B4EF403464B6E305F4187D4DE14B3F6A6A797992FEA00F36E07915871A7125428DA7D07739E0A9157A310FB791D3F6473018F79ED684FAC1065B893CFD3BE71DEEE10D87DC0BE29EDC0782377AECB88123F6EA78477D2C07661DEED9D1109C93B14CA6894AC4CE6E19A7763EC754015488BF37B6E11D40BE74AE91889BDD6E5F76C535836D6234B966A7FB98ECE0564DD864DF3606AD481A8471EA87CC6C25FA649DBC9903F00EF7209D438E7F723E38F7BC68A1B33BDE194CECE8B2CE6EE54EF1B67BFACA3BA91C5FEA145F36C7AD4A5537AC17A4DA40695A3F82A3ACE6100C00F524875459B19D71007DC6F92A74D2A405A79F6A6357FFBC3180CD0C2D238B266B59E289468507620B751E6C0CCB4E99A37CEF7C51FC123207F33C7AC91DB51C2DF628C942803D3207E7E1FA7EB803EE5B3E73EC9627D277DFD5F8217B22BE3D7479EA77C107C023F72F8307F261D8B97458F045A9E9F029B082F62A6459340CC5115A6B5439243B3EB955E208C5ADC80BE685C13615DA8CB073979DD46703F244B7EDB2A1C845DF9BBB863A6BD12A0D34CE99633B29939012382A7C5743179F7B514C4370A17BD45E2CF352739CE4DF8F3E7D19F9285AD347B10F2A5FF97CF41AB973E701AFD1C743F79E6E173397FBC6070C5B30A4F238B297C13284A9353EE0106C7CA3457371EE8734FA8D8472F1999C7EF1A5A416E3C562EAADA274082FBC3809A367A012E057501DA0EF64350883A5B78A21AA450E44A9CC94C1D72F3DB024EAB92099FA076AA4320F781EA92C57402AFB40420AF045650802DF406481CFD488A7EB258F6A9A292097E66B34B274E81536B3FC4AD6D0F2434915EA2EA10CE57A2644B09E2FA193BB8C3224F274083DCF9235205B2AD9BA67E960B5B32C0970BE7A32C0793A049C6749804BDF3806BACC81C0CB4C097C7EE2CA80E7E910749E25E3D6DC818465D03C03E4C93C4F829D7B1331D0793A849C6749808B132106B9C880A08B3C097653B1662834B3213ACD2F642DA9EC806C63AA3CB03D55B60291D4FC0C9248737804D24C851ECBB6B9606F6559BC9ECA721529E406362E993C5F442BFF4481606EC50189E5793C4279B654C8957156628E02C77E028BBEF65712CAE7E8621BA631485992B53C88562D5B42045680B98AAF8AC29B3E338F5D484FA9B220F02A5785C272CDA590667129A4B92A141E7D48ADABB2B814D25C1985F45174003E4B07B1B32CA966537BA61B5269EAD9B02E53FF42595F0307BC992DD6D91406BE8AF8CB6A336516A8D094B9320A65E05F80449507D2A8B26544F2C09B00892207245064CA56927AB84360396964836B4AE30BE932DF08D3052DF7CD0FE065BFF98D8C6623F20E40B2990F526C7E225B6A1AF16080E5A6990F2E39CD4F94343E9E42D9C8E5A9958AFA5FDDDB0AD65C056A37CD5753BD1BEE151C95504028FD00A654331481FBE5465C8383DAD7ECE6991F02A161EF03F6FD84B270430F95AF6FE6EBE5C15DFA51B3990A5D20BE820F7484C69DFDAECD6994E71A1C5214B90DC1B86BE05BE6FC9E51B8956EB36110566DBF5307817631DD38867F875AC2398A97AFB91DD5B2C6305DC531AFEC98A398FBC1402F89EF1037CF2518DB505A73BED5A751BA61F1490BC2061D8366D6EFC1424DE4DE93858E5DEA2D830C436C99ECF29BAC9C41C39AB73D819609AE83426741B52A82AB56A34CCB2C9596E2D99CF49BD6B8A008B48C7F81B151C9869D28AD22680662CB3063069B8F0CC455FD1A1E2495B8D7F49AC2A2615CCB2404A83A99748779B31A97CDF8ADE3DF49B3D048400BAD15856D971D1B5CC48895341872316E549DAD3458DD1D3417B8D403B45676F5A7736359BDBF2A082BDADD9ACA1F58D97D95CEF27588A6DE01D72780B6429FF12BDE34A1A795860DE44029B6BD8D74BB0DE60F2EF499DDD11DA8B98C9B3AD458B12F7BB3DAED4385ACD2BCF302A66CEDACA02C091D04E83795E38F0DB457C573BB5171E8DC26ADBDE83CA64BB719361FF038E6345FE69BCC349F392229DBCF3DF90031C0E2969ADF72AEE5345DE482CB54B9715053D6193C8319BCB9AC07A960B0058E85E615EF3E498CF73CB276CBBC293BCBEFA19A5BF707E46E5D419FB78E3B57C54E1134A988E75ABABD95791F8E326B699E407E26618456781ABAD88FD3D40F47B36D40236767BFCE70ECAD2A880F0433C04EC3CDAEFC869E5316DE7EAD1A159FB402DC4E71825C94A05194784BE42424DBC1719C9ABCBFD068E11F0F27EB7BEC5E0637DB64B34D4893F1FADE6FB87251AF4111FD0F474C9D3FDC6CE8AFD8461348353D1A6CFC26F865EBD193BCBCDEE7409C5D0E047547CC23B7D3B14C6804F7D57389741D068A4079F7955E947778BDF1E909F24D30478FD8A46E84F7AEF00A39545978F45CFA4C0D0F443E10CD6EFF70E6A15584D6718E5195273F090FBBEBA77FFB7F35A6E4A7B0340300 , N'6.2.0-61023')

         */
    }
}
