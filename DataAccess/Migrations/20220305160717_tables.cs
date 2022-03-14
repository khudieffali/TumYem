using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUss",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(800)", nullable: false),
                    CompanyPhoto = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    OneMain = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    OneText = table.Column<string>(type: "nvarchar(800)", nullable: false),
                    TwoMain = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TwoText = table.Column<string>(type: "nvarchar(800)", nullable: true),
                    ThreeMain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreeText = table.Column<string>(type: "nvarchar(800)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUss", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogPhoto = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeaderText = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CountText = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StaticFooters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftDescription = table.Column<string>(type: "nvarchar(600)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticFooters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WhatWeDos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftText = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatWeDos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WhyWeUss",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Header = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", nullable: false),
                    LeftStaff = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    StaffBottomText = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    RightService = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    ServiceBottomText = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyWeUss", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 5, 20, 7, 17, 526, DateTimeKind.Local).AddTicks(4613));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUss");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropTable(
                name: "StaticFooters");

            migrationBuilder.DropTable(
                name: "WhatWeDos");

            migrationBuilder.DropTable(
                name: "WhyWeUss");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 3, 5, 20, 3, 25, 306, DateTimeKind.Local).AddTicks(2368));
        }
    }
}
