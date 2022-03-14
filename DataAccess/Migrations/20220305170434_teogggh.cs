using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class teogggh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoMain",
                table: "AboutUss");

            migrationBuilder.DropColumn(
                name: "TwoText",
                table: "AboutUss");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 5, 21, 4, 34, 220, DateTimeKind.Local).AddTicks(550));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TwoMain",
                table: "AboutUss",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwoText",
                table: "AboutUss",
                type: "nvarchar(800)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 5, 21, 0, 35, 515, DateTimeKind.Local).AddTicks(7370));
        }
    }
}
