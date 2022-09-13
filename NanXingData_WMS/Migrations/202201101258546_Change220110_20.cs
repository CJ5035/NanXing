namespace NanXingData_WMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change220110_20 : DbMigration
    {
        //ALTER TABLE [dbo].[CRMPlanList] ADD [deliveryDate] [datetime]
        public override void Up()
        {
            AddColumn("dbo.CRMPlanList", "deliveryDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CRMPlanList", "deliveryDate");
        }
    }
}
