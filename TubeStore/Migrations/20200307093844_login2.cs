using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class login2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                column: "TubeReferenceId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                column: "TubeReferenceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 3,
                column: "TubeReferenceId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                column: "TubeReferenceId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                column: "TubeReferenceId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 3,
                column: "TubeReferenceId",
                value: 0);
        }
    }
}
