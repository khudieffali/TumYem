using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IconUrl = table.Column<string>(type: "varchar(800)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderLeft = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HeaderRight = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    BackgroundPhoto = table.Column<string>(type: "varchar(800)", nullable: false),
                    İsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(800)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDay = table.Column<bool>(type: "bit", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "IconUrl", "Name" },
                values: new object[] { 1, "https://www.pngfind.com/pngs/m/103-1032042_png-file-svg-chicken-icon-png-white-transparent.png", "Toyuq Yemi" });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "ID", "BackgroundPhoto", "HeaderLeft", "HeaderRight", "Summary", "İsShow" },
                values: new object[] { 1, "https://organicfeeds.com/wp-content/uploads/2020/05/How-Much-You-Should-Feed-Chickens-Per-Day.jpg", "TUM", "YEM", "Bütün məhsullarımıza baxmaq üçün məhsullar düyməsinə toxunaraq keçib baxa bilərsiniz", true });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Discount", "InStock", "IsDay", "IsDeleted", "IsFeatured", "ModifiedOn", "Name", "PhotoUrl", "Price", "PublishDate", "SKU" },
                values: new object[] { 1, 1, "Coxlu istifade ucun nezerde tutulub ve keyfiyyeti Iso9001 standartlarina uygundur", 0m, 5, false, false, false, null, "Kənd ənənə yemi", "http://gilanfeed.com/media/product_photo/large/37.jpg", 10m, new DateTime(2022, 3, 5, 2, 24, 52, 738, DateTimeKind.Local).AddTicks(7559), "548" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
