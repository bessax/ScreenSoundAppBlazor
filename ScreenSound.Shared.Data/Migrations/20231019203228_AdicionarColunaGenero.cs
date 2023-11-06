using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarColunaGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Musicas");
        }
    }
}
