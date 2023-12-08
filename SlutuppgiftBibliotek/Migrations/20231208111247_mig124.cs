using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlutuppgiftBibliotek.Migrations
{
    /// <inheritdoc />
    public partial class mig124 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrower");

            migrationBuilder.AddColumn<int>(
                name: "BorrowerId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BorrowerId",
                table: "Books",
                column: "BorrowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Borrowers_BorrowerId",
                table: "Books",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Borrowers_BorrowerId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BorrowerId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowerId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookBorrower",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    BorrowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrower", x => new { x.BooksBookId, x.BorrowersId });
                    table.ForeignKey(
                        name: "FK_BookBorrower_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrower_Borrowers_BorrowersId",
                        column: x => x.BorrowersId,
                        principalTable: "Borrowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrower_BorrowersId",
                table: "BookBorrower",
                column: "BorrowersId");
        }
    }
}
