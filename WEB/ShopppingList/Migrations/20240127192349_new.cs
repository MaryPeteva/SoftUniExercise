using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopppingList.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductNotes_NoteId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "NoteId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductNotes_NoteId",
                table: "Products",
                column: "NoteId",
                principalTable: "ProductNotes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductNotes_NoteId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "NoteId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductNotes_NoteId",
                table: "Products",
                column: "NoteId",
                principalTable: "ProductNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
