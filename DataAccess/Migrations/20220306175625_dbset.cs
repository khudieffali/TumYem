using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUsTexts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneMain = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    OneText = table.Column<string>(type: "nvarchar(800)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsTexts", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 6, 21, 56, 25, 108, DateTimeKind.Local).AddTicks(201));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUsTexts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 6, 21, 46, 2, 721, DateTimeKind.Local).AddTicks(4924));
        }
    }
}
