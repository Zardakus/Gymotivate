using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class DiasSemana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "DiasSemana");
            migrationBuilder.DropTable(
        name: "Exercicios");
            migrationBuilder.DropTable(
        name: "TreinoExercicio");
            migrationBuilder.DropTable(
        name: "Treinos");
        }
    }
}
