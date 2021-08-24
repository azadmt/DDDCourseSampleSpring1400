using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagement.Persistence.Ef.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HomeAddress_Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAddress_Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
