using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_exam.Migrations
{
    public partial class allmodelsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    PActivityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PActivityName = table.Column<string>(nullable: false),
                    DateNTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.PActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJoinPActivities",
                columns: table => new
                {
                    UserJoinPActivityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserJoinedId = table.Column<int>(nullable: false),
                    PActivityJoinedId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJoinPActivities", x => x.UserJoinPActivityId);
                    table.ForeignKey(
                        name: "FK_UserJoinPActivities_Activities_PActivityJoinedId",
                        column: x => x.PActivityJoinedId,
                        principalTable: "Activities",
                        principalColumn: "PActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJoinPActivities_Users_UserJoinedId",
                        column: x => x.UserJoinedId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatorId",
                table: "Activities",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJoinPActivities_PActivityJoinedId",
                table: "UserJoinPActivities",
                column: "PActivityJoinedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJoinPActivities_UserJoinedId",
                table: "UserJoinPActivities",
                column: "UserJoinedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJoinPActivities");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
