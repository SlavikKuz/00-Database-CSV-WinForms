using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class tubeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Tubes");

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                column: "CouponValue",
                value: 0.1m);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                column: "CouponValue",
                value: 0.15m);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 3,
                column: "CouponValue",
                value: 0.05m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Tubes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                column: "CouponValue",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                column: "CouponValue",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 3,
                column: "CouponValue",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Tubes",
                keyColumn: "TubeId",
                keyValue: 2,
                column: "InStock",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tubes",
                keyColumn: "TubeId",
                keyValue: 3,
                column: "InStock",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tubes",
                keyColumn: "TubeId",
                keyValue: 4,
                column: "InStock",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tubes",
                keyColumn: "TubeId",
                keyValue: 5,
                column: "InStock",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tubes",
                keyColumn: "TubeId",
                keyValue: 6,
                column: "InStock",
                value: true);
        }
    }
}
