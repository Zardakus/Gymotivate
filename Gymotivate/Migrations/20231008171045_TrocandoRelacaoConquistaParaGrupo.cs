using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class TrocandoRelacaoConquistaParaGrupo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NameConquistas_Conquistas_ConquistasId",
                table: "NameConquistas");

            migrationBuilder.RenameColumn(
                name: "ConquistasId",
                table: "NameConquistas",
                newName: "GrupoConquistasGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_NameConquistas_ConquistasId",
                table: "NameConquistas",
                newName: "IX_NameConquistas_GrupoConquistasGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_NameConquistas_GrupoConquistas_GrupoConquistasGroupId",
                table: "NameConquistas",
                column: "GrupoConquistasGroupId",
                principalTable: "GrupoConquistas",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NameConquistas_GrupoConquistas_GrupoConquistasGroupId",
                table: "NameConquistas");

            migrationBuilder.RenameColumn(
                name: "GrupoConquistasGroupId",
                table: "NameConquistas",
                newName: "ConquistasId");

            migrationBuilder.RenameIndex(
                name: "IX_NameConquistas_GrupoConquistasGroupId",
                table: "NameConquistas",
                newName: "IX_NameConquistas_ConquistasId");

            migrationBuilder.AddForeignKey(
                name: "FK_NameConquistas_Conquistas_ConquistasId",
                table: "NameConquistas",
                column: "ConquistasId",
                principalTable: "Conquistas",
                principalColumn: "ConquistasId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
