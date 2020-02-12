using Microsoft.EntityFrameworkCore.Migrations;

namespace TubeStore.Migrations
{
    public partial class initializecreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousels",
                columns: table => new
                {
                    CarouselId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousels", x => x.CarouselId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tubes",
                columns: table => new
                {
                    TubeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true),
                    MatchedPair = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    IsTubeOfTheWeek = table.Column<bool>(nullable: false),
                    IsNewArrival = table.Column<bool>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tubes", x => x.TubeId);
                    table.ForeignKey(
                        name: "FK_Tubes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carousels",
                columns: new[] { "CarouselId", "Description", "ImageUrl", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "Premium selected", "/Images/Carousel/carousel_01.jpg", true, "ECC82" },
                    { 2, "Platinum matched quad", "/Images/Carousel/carousel_02.jpg", true, "6P14P" },
                    { 3, "Tested pre-amp set", "/Images/Carousel/carousel_03.jpg", true, "6N6P" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "ParentId" },
                values: new object[] { 1, "Pre Triodes", null });

            migrationBuilder.InsertData(
                table: "Tubes",
                columns: new[] { "TubeId", "Brand", "CategoryId", "Date", "FullDescription", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsNewArrival", "IsTubeOfTheWeek", "MatchedPair", "Price", "Quantity", "ShortDescription", "Type" },
                values: new object[,]
                {
                    { 1, "NEVZ", 1, "10.1963", "The 6N1P has similar ratings to the 6DJ8 and in the past was sometimes rebranded as such, however differences between the two types (the 6N1P requires almost twice the filament current and has only one third the S value) mean they are not directly interchangeable. The S is about 4.35 ma/V, the 6DJ8/ECC88 has a S of 12.5 ma/V and a gain of 33 and a lower internal resistance. However, the 6N1P is typically more linear for a given load. It is therefore inaccurate to say that these two tubes are identical. The correct Russian equivalent to the 6DJ8/ECC88 is the 6N23P, the latter has a S of 12.5 mA/V and a gain of 33.", "/Images/PreTriodes/6N1P/20160808_6N1Pnevz_small.jpg", "/Images/PreTriodes/6N1P/20160808_6N1Pnevz.jpg", false, false, false, true, 12.00m, 62, "NOS, Gray plates, gold grids, mica", "6N1P" },
                    { 2, "NEVZ", 1, "01.1967", "The 6N1P has similar ratings to the 6DJ8 and in the past was sometimes rebranded as such, however differences between the two types (the 6N1P requires almost twice the filament current and has only one third the S value) mean they are not directly interchangeable. The S is about 4.35 ma/V, the 6DJ8/ECC88 has a S of 12.5 ma/V and a gain of 33 and a lower internal resistance. However, the 6N1P is typically more linear for a given load. It is therefore inaccurate to say that these two tubes are identical. The correct Russian equivalent to the 6DJ8/ECC88 is the 6N23P, the latter has a S of 12.5 mA/V and a gain of 33.", "/Images/PreTriodes/6N1P/20170201_6N1Pboxplates_small.jpg", "/Images/PreTriodes/6N1P/20170201_6N1Pboxplates.jpg", true, false, true, true, 115.00m, 12, "NOS, box plates", "6N1P" },
                    { 3, "Foton", 1, "1960s", "The 6N6p tube is a Russian dual triode tube. This tube is often seen as 6N6p, 6N6PI, 6N6pi, 6H6p, 6N6p-i, 6N6n-i ,or 6H6n-i. The Chinese name for the 6H6p tube is 6N6 tube. The 6N6p is a fantastic tube for preamps and driver stages, and is even used as output tubes in the Little Dot MkIII headphone amp. It has been used by the tube DIY underground for many years and is now becoming better known in the mainstream.", "/Images/PreTriodes/6N6P/20170506_6N6Pfoton_small.jpg", "/Images/PreTriodes/6N6P/20170506_6N6Pfoton.jpg", true, false, false, true, 39.99m, 30, "square getter, millitary grade", "6N6P" },
                    { 4, "NEVZ", 1, "08.1974", "The 6N6p tube is a Russian dual triode tube. This tube is often seen as 6N6p, 6N6PI, 6N6pi, 6H6p, 6N6p-i, 6N6n-i ,or 6H6n-i. The Chinese name for the 6H6p tube is 6N6 tube. The 6N6p is a fantastic tube for preamps and driver stages, and is even used as output tubes in the Little Dot MkIII headphone amp. It has been used by the tube DIY underground for many years and is now becoming better known in the mainstream.", "/Images/PreTriodes/6N6P/20170506_6N6Pnevz_small.jpg", "/Images/PreTriodes/6N6P/20170506_6N6Pnevz.jpg", true, true, false, true, 89.99m, 10, "gold pin & grid", "6N6P" },
                    { 5, "Tungsram", 1, "1970s", "The tube is popular in hi-fi vacuum tube audio as a low-noise line amplifier, driver (especially for tone stacks), and phase-inverter in vacuum tube push–pull amplifier circuits. It was widely used, in special-quality versions such as ECC82 and 5814A, in pre-semiconductor digital computer circuitry. ", "/Images/PreTriodes/ECC82/20171220_ECC82tungsram_small.jpg", "/Images/PreTriodes/ECC82/20171220_ECC82tungsram.jpg", true, true, false, false, 49.99m, 11, "Made in hungary", "ECC82" },
                    { 6, "Mullard", 1, "02.1961", "The tube is popular in hi-fi vacuum tube audio as a low-noise line amplifier, driver (especially for tone stacks), and phase-inverter in vacuum tube push–pull amplifier circuits. It was widely used, in special-quality versions such as ECC82 and 5814A, in pre-semiconductor digital computer circuitry. ", "/Images/PreTriodes/ECC82/20171212_ECC82mullard_small.jpg", "/Images/PreTriodes/ECC82/20171212_ECC82mullard.jpg", true, true, false, false, 299.99m, 3, "Made in Great Britain", "ECC82" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tubes_CategoryId",
                table: "Tubes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousels");

            migrationBuilder.DropTable(
                name: "Tubes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
