using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "InvoiceInfos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponName = table.Column<string>(nullable: true),
                    CouponValue = table.Column<decimal>(nullable: false),
                    CouponStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponId);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponName", "CouponStatus", "CouponValue" },
                values: new object[,]
                {
                    { 1, "ten", "Active", 10m },
                    { 2, "fifteen", "Expired", 15m },
                    { 5, "five", "Active", 5m }
                });

            migrationBuilder.UpdateData(
                table: "Tubes",
                keyColumn: "TubeId",
                keyValue: 1,
                column: "Discount",
                value: 0.05m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "InvoiceInfos");

            migrationBuilder.UpdateData(
                table: "Tubes",
                keyColumn: "TubeId",
                keyValue: 1,
                column: "Discount",
                value: 10m);
        }
    }
}
