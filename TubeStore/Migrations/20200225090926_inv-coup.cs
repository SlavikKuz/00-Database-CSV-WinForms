using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class invcoup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponName", "CouponStatus", "CouponValue" },
                values: new object[] { 3, "five", "Active", 5m });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CouponId",
                table: "Invoices",
                column: "CouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Coupons_CouponId",
                table: "Invoices",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "CouponId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Coupons_CouponId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CouponId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponName", "CouponStatus", "CouponValue" },
                values: new object[] { 5, "five", "Active", 5m });
        }
    }
}
