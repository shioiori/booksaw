using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace booksaw.infrastructure.Migrations
{
    public partial class alterBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "import_price",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "sold_price",
                table: "books",
                newName: "price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "books",
                newName: "sold_price");

            migrationBuilder.AddColumn<decimal>(
                name: "import_price",
                table: "books",
                type: "decimal(65,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
