using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryModel.Data.Migrations
{
    public partial class remove_GuaratorsCount_rename_Paydate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfGuarantors",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "PayDate",
                table: "Loans",
                newName: "LoanPayDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanPayDate",
                table: "Loans",
                newName: "PayDate");

            migrationBuilder.AddColumn<int>(
                name: "CountOfGuarantors",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
