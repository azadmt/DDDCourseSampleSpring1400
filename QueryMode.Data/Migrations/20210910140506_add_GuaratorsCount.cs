using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryModel.Data.Migrations
{
    public partial class add_GuaratorsCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfGuarantors",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfGuarantors",
                table: "Loans");
        }
    }
}
