using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OneMain",
                table: "AboutUss");

            migrationBuilder.DropColumn(
                name: "OneText",
                table: "AboutUss");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 6, 21, 46, 2, 721, DateTimeKind.Local).AddTicks(4924));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OneMain",
                table: "AboutUss",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OneText",
                table: "AboutUss",
                type: "nvarchar(800)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 5, 21, 4, 34, 220, DateTimeKind.Local).AddTicks(550));
        }
    }
}
