using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KSMArtWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Art Object_Media_MediaID",
                table: "Art Object");

            migrationBuilder.DropIndex(
                name: "IX_Art Object_MediaID",
                table: "Art Object");

            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "Art Object",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Art Object",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Art Object",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Art Object");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Art Object");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Art Object");

            migrationBuilder.CreateIndex(
                name: "IX_Art Object_MediaID",
                table: "Art Object",
                column: "MediaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Art Object_Media_MediaID",
                table: "Art Object",
                column: "MediaID",
                principalTable: "Media",
                principalColumn: "Id");
        }
    }
}
