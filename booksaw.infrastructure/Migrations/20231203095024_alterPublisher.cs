using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace booksaw.infrastructure.Migrations
{
    public partial class alterPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "publishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "publishers");

        }
    }
}
