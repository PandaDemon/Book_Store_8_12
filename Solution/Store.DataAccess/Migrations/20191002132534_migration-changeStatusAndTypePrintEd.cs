using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintStore.DataAccess.Migrations
{
    public partial class migrationv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PrintingEditions",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PrintingEditions",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
