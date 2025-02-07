using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G02_05_DI_Recap.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntoAnno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Anno",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anno",
                table: "Libros");
        }
    }
}
