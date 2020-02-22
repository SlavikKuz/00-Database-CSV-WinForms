using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class shippingAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coutry",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShippingAddress",
                columns: table => new
                {
                    ShoppingAdressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    ClientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddress", x => x.ShoppingAdressId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ShippingAddressId",
                table: "Invoices",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ShippingAddress_ShippingAddressId",
                table: "Invoices",
                column: "ShippingAddressId",
                principalTable: "ShippingAddress",
                principalColumn: "ShoppingAdressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ShippingAddress_ShippingAddressId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "ShippingAddress");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ShippingAddressId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Coutry",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
