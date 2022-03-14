using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class userPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 10, 23, 32, 18, 768, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1023",
                columns: new[] { "LockoutEnd", "PasswordHash" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 23, 32, 18, 768, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 4, 0, 0, 0)), "TumYemAdmin123_" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 10, 23, 30, 22, 410, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1023",
                columns: new[] { "LockoutEnd", "PasswordHash" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 23, 30, 22, 410, DateTimeKind.Unspecified).AddTicks(7426), new TimeSpan(0, 4, 0, 0, 0)), null });
        }
    }
}
