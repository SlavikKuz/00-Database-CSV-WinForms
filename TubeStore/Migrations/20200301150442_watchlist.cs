using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class watchlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    WatchlistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TubeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlists", x => x.WatchlistId);
                    table.ForeignKey(
                        name: "FK_Watchlists_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watchlists_Tubes_TubeId",
                        column: x => x.TubeId,
                        principalTable: "Tubes",
                        principalColumn: "TubeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_CustomerId",
                table: "Watchlists",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_TubeId",
                table: "Watchlists",
                column: "TubeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watchlists");
        }
    }
}
