using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintStore.DataAccess.Migrations
{
    public partial class migrationv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorInPrintingEditions",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorInPrintingEditions",
                table: "AuthorInPrintingEditions",
                column: "PrintingEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId",
                table: "AuthorInPrintingEditions",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorInPrintingEditions",
                table: "AuthorInPrintingEditions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInPrintingEditions_AuthorId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorInPrintingEditions",
                table: "AuthorInPrintingEditions",
                columns: new[] { "AuthorId", "PrintingEditionId" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions",
                column: "PrintingEditionId");
        }
    }
}
