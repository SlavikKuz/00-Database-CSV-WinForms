using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ShippingAddress_ShippingAddressId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAddress",
                table: "ShippingAddress");

            migrationBuilder.RenameTable(
                name: "ShippingAddress",
                newName: "ShippingAddresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses",
                column: "ShoppingAdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ShippingAddresses_ShippingAddressId",
                table: "Invoices",
                column: "ShippingAddressId",
                principalTable: "ShippingAddresses",
                principalColumn: "ShoppingAdressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ShippingAddresses_ShippingAddressId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses");

            migrationBuilder.RenameTable(
                name: "ShippingAddresses",
                newName: "ShippingAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAddress",
                table: "ShippingAddress",
                column: "ShoppingAdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ShippingAddress_ShippingAddressId",
                table: "Invoices",
                column: "ShippingAddressId",
                principalTable: "ShippingAddress",
                principalColumn: "ShoppingAdressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
