using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class RetirandoConquistaDoGrupoConq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conquistas_GrupoConquistas_GrupoConquistasModelGroupId",
                table: "Conquistas");

            migrationBuilder.DropIndex(
                name: "IX_Conquistas_GrupoConquistasModelGroupId",
                table: "Conquistas");

            migrationBuilder.DropColumn(
                name: "GrupoConquistasModelGroupId",
                table: "Conquistas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupoConquistasModelGroupId",
                table: "Conquistas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conquistas_GrupoConquistasModelGroupId",
                table: "Conquistas",
                column: "GrupoConquistasModelGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conquistas_GrupoConquistas_GrupoConquistasModelGroupId",
                table: "Conquistas",
                column: "GrupoConquistasModelGroupId",
                principalTable: "GrupoConquistas",
                principalColumn: "GroupId");
        }
    }
}
