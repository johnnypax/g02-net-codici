using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI_06_EF_MTM.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntoCodice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodiceABarre",
                table: "Prodottos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodiceABarre",
                table: "Prodottos");
        }
    }
}
