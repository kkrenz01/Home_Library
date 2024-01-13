using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Library_LibraryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LibraryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Library",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Library_ApplicationUserId",
                table: "Library",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Library_AspNetUsers_ApplicationUserId",
                table: "Library",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Library_AspNetUsers_ApplicationUserId",
                table: "Library");

            migrationBuilder.DropIndex(
                name: "IX_Library_ApplicationUserId",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Library");

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LibraryId",
                table: "AspNetUsers",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Library_LibraryId",
                table: "AspNetUsers",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "Id");
        }
    }
}
