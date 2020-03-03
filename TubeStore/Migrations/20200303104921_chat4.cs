using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class chat4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_ChatGroup_ChatGroupId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_AspNetUsers_CustomerId",
                table: "ChatMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatGroup",
                table: "ChatGroup");

            migrationBuilder.RenameTable(
                name: "ChatMessage",
                newName: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "ChatGroup",
                newName: "ChatGroups");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_CustomerId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_ChatGroupId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ChatGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "ChatMessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatGroups",
                table: "ChatGroups",
                column: "ChatGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_ChatGroups_ChatGroupId",
                table: "ChatMessages",
                column: "ChatGroupId",
                principalTable: "ChatGroups",
                principalColumn: "ChatGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_CustomerId",
                table: "ChatMessages",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatGroups_ChatGroupId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_CustomerId",
                table: "ChatMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatGroups",
                table: "ChatGroups");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "ChatMessage");

            migrationBuilder.RenameTable(
                name: "ChatGroups",
                newName: "ChatGroup");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_CustomerId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ChatGroupId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_ChatGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage",
                column: "ChatMessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatGroup",
                table: "ChatGroup",
                column: "ChatGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_ChatGroup_ChatGroupId",
                table: "ChatMessage",
                column: "ChatGroupId",
                principalTable: "ChatGroup",
                principalColumn: "ChatGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_AspNetUsers_CustomerId",
                table: "ChatMessage",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
