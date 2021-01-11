using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace chefs_n_dishes.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ChefAge",
                table: "Chefs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ChefAge",
                table: "Chefs",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
