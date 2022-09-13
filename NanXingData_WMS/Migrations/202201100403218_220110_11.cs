namespace NanXingData_WMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _220110_11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CRMPlanHead",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CRMApplyNo = c.String(maxLength: 30),
                        ClientNo = c.String(maxLength: 20),
                        ClientName = c.String(maxLength: 50),
                        ApplicantId = c.String(maxLength: 20),
                        ApplicantName = c.String(maxLength: 20),
                        ApplicantPhone = c.String(maxLength: 15),
                        ApplicantDept = c.String(maxLength: 20),
                        ApplicantJob = c.String(maxLength: 20),
                        ApplyTime = c.DateTime(),
                        OrderDate = c.DateTime(),
                        SaleGroup = c.String(maxLength: 20),
                        OrderSource = c.String(maxLength: 10),
                        Photo = c.Binary(maxLength: 4000),
                        Remark = c.String(maxLength: 255),
                        Reserve1 = c.String(maxLength: 50),
                        Reserve2 = c.String(maxLength: 50),
                        Reserve3 = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CRMPlanList",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CRMApplyNo_Xuhao = c.String(maxLength: 30),
                        ItemNo = c.String(maxLength: 20),
                        ItemName = c.String(maxLength: 100),
                        Spec = c.String(maxLength: 20),
                        OrderCount = c.Int(nullable: false),
                        Unit = c.String(maxLength: 10),
                        InventoryCount = c.String(maxLength: 20),
                        OrderCountONkg = c.Int(nullable: false),
                        BoxNo = c.String(maxLength: 10),
                        BoxName = c.String(maxLength: 10),
                        Biaozhun = c.String(maxLength: 10),
                        ProductRecipe = c.String(maxLength: 255),
                        ApplyNoState = c.String(maxLength: 20),
                        EmergencyDegree = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 255),
                        Reserve1 = c.String(maxLength: 50),
                        Reserve2 = c.String(maxLength: 50),
                        Reserve3 = c.String(maxLength: 50),
                        Reserve4 = c.String(maxLength: 50),
                        Reserve5 = c.String(maxLength: 50),
                        Reserve6 = c.String(maxLength: 50),
                        Reserve7 = c.String(maxLength: 50),
                        CRMPlanHead_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CRMPlanHead", t => t.CRMPlanHead_Id, cascadeDelete: true)
                .Index(t => t.CRMPlanHead_Id);
            
            CreateTable(
                "dbo.Production",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        prosn = c.String(nullable: false, maxLength: 50),
                        prodate = c.DateTime(nullable: false),
                        proname = c.String(nullable: false, maxLength: 50),
                        itemno = c.String(nullable: false, maxLength: 50),
                        ProductOrderlistsID = c.Int(),
                        _class = c.String(name: "class", maxLength: 50),
                        unit = c.String(maxLength: 50),
                        spec = c.String(maxLength: 50),
                        batchNo = c.String(maxLength: 100),
                        boxNo = c.String(maxLength: 50),
                        boxName = c.String(maxLength: 50),
                        ingredients = c.String(maxLength: 50),
                        remark1 = c.String(),
                        protype = c.String(maxLength: 50),
                        color = c.String(maxLength: 50),
                        probiaozhun = c.String(maxLength: 50),
                        yuanliaobatchNo = c.String(maxLength: 100),
                        position = c.String(maxLength: 20),
                        danjuhao = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductOrderlists", t => t.ProductOrderlistsID)
                .Index(t => t.ProductOrderlistsID);
            
            CreateTable(
                "dbo.ProductOrderlists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductOrder_XuHao = c.String(maxLength: 20),
                        Itemno = c.String(maxLength: 30),
                        ItemName = c.String(maxLength: 50),
                        InName = c.String(maxLength: 50),
                        MaterialItem = c.String(maxLength: 50),
                        Spec = c.String(maxLength: 20),
                        Model = c.String(maxLength: 50),
                        Color = c.String(maxLength: 20),
                        Class = c.String(maxLength: 20),
                        Unit = c.String(maxLength: 10),
                        PcCount = c.Decimal(precision: 18, scale: 2),
                        Optdate = c.DateTime(),
                        PlanDate = c.DateTime(),
                        Jingbanren = c.String(maxLength: 10),
                        Remark = c.String(),
                        Clientname = c.String(maxLength: 50),
                        ProPlanOrderheaders_ID = c.Int(),
                        BatchNo = c.String(maxLength: 50),
                        BoxNo = c.String(maxLength: 20),
                        BoxName = c.String(maxLength: 20),
                        Ingredients = c.String(maxLength: 50),
                        Chejianclass = c.String(maxLength: 20),
                        ERPOrderNo = c.String(maxLength: 20),
                        ProductOrder_State = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProPlanOrderheaders", t => t.ProPlanOrderheaders_ID)
                .Index(t => t.ProPlanOrderheaders_ID);
            
            CreateTable(
                "dbo.ProPlanOrderheaders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductOrderNo = c.String(maxLength: 20),
                        Optdate = c.DateTime(),
                        PositionClass = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 200),
                        orderNo = c.String(maxLength: 20),
                        mergeCells = c.String(maxLength: 255),
                        mergeCellsValue = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrderlists", "ProPlanOrderheaders_ID", "dbo.ProPlanOrderheaders");
            DropForeignKey("dbo.Production", "ProductOrderlistsID", "dbo.ProductOrderlists");
            DropForeignKey("dbo.CRMPlanList", "CRMPlanHead_Id", "dbo.CRMPlanHead");
            DropIndex("dbo.ProductOrderlists", new[] { "ProPlanOrderheaders_ID" });
            DropIndex("dbo.Production", new[] { "ProductOrderlistsID" });
            DropIndex("dbo.CRMPlanList", new[] { "CRMPlanHead_Id" });
            DropTable("dbo.ProPlanOrderheaders");
            DropTable("dbo.ProductOrderlists");
            DropTable("dbo.Production");
            DropTable("dbo.CRMPlanList");
            DropTable("dbo.CRMPlanHead");
        }
    }
}
