using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_exam.Migrations
{
    public partial class allmodelscomplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PActivitySpan",
                table: "Activities",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PActivitySpan",
                table: "Activities");
        }
    }
}
