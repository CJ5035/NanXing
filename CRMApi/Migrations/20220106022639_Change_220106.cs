using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMApi.Migrations
{
    public partial class Change_220106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderSource",
                table: "CRMPlanList",
                newName: "Unit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "CRMPlanList",
                newName: "OrderSource");
        }
    }
}
