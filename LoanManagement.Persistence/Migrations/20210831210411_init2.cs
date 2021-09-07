using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Persistence.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoanAmount_Currency",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LoanAmount_Value",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanAmount_Currency",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanAmount_Value",
                table: "Loans");
        }
    }
}
