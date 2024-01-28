using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopppingList.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductNotes_NoteId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_NoteId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotes_ProductId",
                table: "ProductNotes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductNotes_Products_ProductId",
                table: "ProductNotes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductNotes_Products_ProductId",
                table: "ProductNotes");

            migrationBuilder.DropIndex(
                name: "IX_ProductNotes_ProductId",
                table: "ProductNotes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductNotes");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NoteId",
                table: "Products",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductNotes_NoteId",
                table: "Products",
                column: "NoteId",
                principalTable: "ProductNotes",
                principalColumn: "Id");
        }
    }
}
