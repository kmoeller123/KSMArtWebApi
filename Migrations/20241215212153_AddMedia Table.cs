using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KSMArtWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaID",
                table: "Art Object",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Art Object_Media_MediaID",
                table: "Art Object");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Art Object_MediaID",
                table: "Art Object");

            migrationBuilder.DropColumn(
                name: "MediaID",
                table: "Art Object");
        }
    }
}
