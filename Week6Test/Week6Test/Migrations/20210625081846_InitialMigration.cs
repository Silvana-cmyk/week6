using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6Test.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CF = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CF);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StipulationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceAmount = table.Column<float>(type: "real", nullable: false),
                    MonthlyInstallment = table.Column<float>(type: "real", nullable: false),
                    ClientCF = table.Column<string>(type: "nchar(16)", nullable: true),
                    policy_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Displacement = table.Column<int>(type: "int", nullable: true),
                    Years = table.Column<int>(type: "int", nullable: true),
                    PercentageCoverage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Policy_Client_ClientCF",
                        column: x => x.ClientCF,
                        principalTable: "Client",
                        principalColumn: "CF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policy_ClientCF",
                table: "Policy",
                column: "ClientCF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
