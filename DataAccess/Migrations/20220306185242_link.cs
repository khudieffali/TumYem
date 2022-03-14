using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailLink",
                table: "StaticFooters",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "StaticFooters",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "StaticFooters",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberLink",
                table: "StaticFooters",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "StaticFooters",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 6, 22, 52, 41, 880, DateTimeKind.Local).AddTicks(5934));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailLink",
                table: "StaticFooters");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "StaticFooters");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "StaticFooters");

            migrationBuilder.DropColumn(
                name: "PhoneNumberLink",
                table: "StaticFooters");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "StaticFooters");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 6, 22, 14, 45, 20, DateTimeKind.Local).AddTicks(7338));
        }
    }
}
