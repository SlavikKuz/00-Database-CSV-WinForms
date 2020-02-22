using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class cliet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ShippingAddresses");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "ShippingAddresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ShippingAddresses");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "ShippingAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
