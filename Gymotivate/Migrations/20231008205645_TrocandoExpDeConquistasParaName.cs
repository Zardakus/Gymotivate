using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class TrocandoExpDeConquistasParaName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConquistaExp",
                table: "Conquistas");

            migrationBuilder.AddColumn<int>(
                name: "ConquistaExp",
                table: "NameConquistas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConquistaExp",
                table: "NameConquistas");

            migrationBuilder.AddColumn<int>(
                name: "ConquistaExp",
                table: "Conquistas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
