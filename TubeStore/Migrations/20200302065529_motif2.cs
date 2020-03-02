using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class motif2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationUsers_ChatUsers_ChatUserId",
                table: "NotificationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationUsers",
                table: "NotificationUsers");

            migrationBuilder.DropIndex(
                name: "IX_NotificationUsers_ChatUserId",
                table: "NotificationUsers");

            migrationBuilder.DropIndex(
                name: "IX_NotificationUsers_NotificationId",
                table: "NotificationUsers");

            migrationBuilder.DropColumn(
                name: "NotificationUserId",
                table: "NotificationUsers");

            migrationBuilder.DropColumn(
                name: "ChatUserId",
                table: "NotificationUsers");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "NotificationUsers");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "NotificationUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationUsers",
                table: "NotificationUsers",
                columns: new[] { "NotificationId", "CustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUsers_CustomerId",
                table: "NotificationUsers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationUsers_AspNetUsers_CustomerId",
                table: "NotificationUsers",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationUsers_AspNetUsers_CustomerId",
                table: "NotificationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationUsers",
                table: "NotificationUsers");

            migrationBuilder.DropIndex(
                name: "IX_NotificationUsers_CustomerId",
                table: "NotificationUsers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "NotificationUsers");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "NotificationUserId",
                table: "NotificationUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChatUserId",
                table: "NotificationUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "NotificationUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationUsers",
                table: "NotificationUsers",
                column: "NotificationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUsers_ChatUserId",
                table: "NotificationUsers",
                column: "ChatUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUsers_NotificationId",
                table: "NotificationUsers",
                column: "NotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationUsers_ChatUsers_ChatUserId",
                table: "NotificationUsers",
                column: "ChatUserId",
                principalTable: "ChatUsers",
                principalColumn: "ChatUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
