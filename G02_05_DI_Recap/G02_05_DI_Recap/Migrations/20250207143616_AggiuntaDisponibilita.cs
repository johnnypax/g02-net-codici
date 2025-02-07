using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G02_05_DI_Recap.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaDisponibilita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Disponibilita",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibilita",
                table: "Libros");
        }
    }
}
