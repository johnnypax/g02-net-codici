using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G02_07_EF_CF_OTM.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntiCodici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Libros",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Codice",
                table: "Autores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Isbn",
                table: "Libros",
                column: "Isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_Codice",
                table: "Autores",
                column: "Codice",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Libros_Isbn",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Autores_Codice",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "Codice",
                table: "Autores");
        }
    }
}
