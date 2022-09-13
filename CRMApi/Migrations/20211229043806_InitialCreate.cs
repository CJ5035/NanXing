using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "CRMPlanHead",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRMApplyNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ClientNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApplicantId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApplicantName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApplicantPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ApplicantDept = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApplicantJob = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApplyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrderSource = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(4000)", maxLength: 4000, nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Reserve1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reserve2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reserve3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRMPlanHead", x => x.ID);
                });

           

            migrationBuilder.CreateTable(
                name: "CRMPlanList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRMApplyNo_Xuhao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ItemNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Spec = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    InventoryCount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrderCountONkg = table.Column<int>(type: "int", nullable: false),
                    BoxNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BoxName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Biaozhun = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ProductRecipe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OrderSource = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApplyNoState = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmergencyDegree = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Reserve1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reserve2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reserve3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reserve4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reserve5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reserve6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reserve7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CRMPlanHead_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRMPlanList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CRMPlanList_CRMPlanHead_CRMPlanHead_Id",
                        column: x => x.CRMPlanHead_Id,
                        principalTable: "CRMPlanHead",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_CRMPlanList_CRMPlanHead_Id",
                table: "CRMPlanList",
                column: "CRMPlanHead_Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
