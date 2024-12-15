using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KSMArtWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediaID",
                table: "Art Object",
                newName: "Media");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Media",
                table: "Art Object",
                newName: "MediaID");
        }
    }
}
