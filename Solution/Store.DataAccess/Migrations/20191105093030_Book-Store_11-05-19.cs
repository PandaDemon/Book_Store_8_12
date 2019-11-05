using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccess.Migrations
{
    public partial class BookStore_110519 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEdidtionId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.RenameColumn(
                name: "PrintingEdidtionId",
                table: "AuthorInPrintingEditions",
                newName: "PrintingEditionId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEdidtionId",
                table: "AuthorInPrintingEditions",
                newName: "IX_AuthorInPrintingEditions_PrintingEditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions",
                column: "PrintingEditionId",
                principalTable: "PrintingEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions");

            migrationBuilder.RenameColumn(
                name: "PrintingEditionId",
                table: "AuthorInPrintingEditions",
                newName: "PrintingEdidtionId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorInPrintingEditions_PrintingEditionId",
                table: "AuthorInPrintingEditions",
                newName: "IX_AuthorInPrintingEditions_PrintingEdidtionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInPrintingEditions_PrintingEditions_PrintingEdidtionId",
                table: "AuthorInPrintingEditions",
                column: "PrintingEdidtionId",
                principalTable: "PrintingEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
