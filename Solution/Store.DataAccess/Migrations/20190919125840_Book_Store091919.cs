using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccess.Migrations
{
    public partial class Book_Store091919 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "CreateDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "PrintingEditions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Payments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Currencies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Authors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AuthorInPrintingEditions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AuthorInPrintingEditions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "PrintingEditions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuthorInPrintingEditions");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Orders",
                newName: "OrderDate");
        }
    }
}
