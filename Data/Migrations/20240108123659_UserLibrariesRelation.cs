using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserLibrariesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Library_AspNetUsers_ApplicationUserId",
                table: "Library");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Library",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Library_ApplicationUserId",
                table: "Library",
                newName: "IX_Library_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Library_AspNetUsers_UserId",
                table: "Library",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Library_AspNetUsers_UserId",
                table: "Library");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Library",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Library_UserId",
                table: "Library",
                newName: "IX_Library_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Library_AspNetUsers_ApplicationUserId",
                table: "Library",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
