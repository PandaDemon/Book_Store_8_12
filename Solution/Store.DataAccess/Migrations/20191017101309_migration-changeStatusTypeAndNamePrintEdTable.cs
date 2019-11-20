using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintStore.DataAccess.Migrations
{
    public partial class migrationv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PrintingEditions",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
