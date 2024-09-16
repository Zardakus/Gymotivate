using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class TrocandoRelacaoConquistasName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conquistas_GrupoConquistas_GrupoConquistasGroupId",
                table: "Conquistas");

            migrationBuilder.RenameColumn(
                name: "GrupoConquistasGroupId",
                table: "Conquistas",
                newName: "NameConquistasId");

            migrationBuilder.RenameIndex(
                name: "IX_Conquistas_GrupoConquistasGroupId",
                table: "Conquistas",
                newName: "IX_Conquistas_NameConquistasId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Conquistas_NameConquistas_NameConquistasId",
                table: "Conquistas",
                column: "NameConquistasId",
                principalTable: "NameConquistas",
                principalColumn: "NameConquistasId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conquistas_GrupoConquistas_GrupoConquistasModelGroupId",
                table: "Conquistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Conquistas_NameConquistas_NameConquistasId",
                table: "Conquistas");

            migrationBuilder.DropIndex(
                name: "IX_Conquistas_GrupoConquistasModelGroupId",
                table: "Conquistas");

            migrationBuilder.DropColumn(
                name: "GrupoConquistasModelGroupId",
                table: "Conquistas");

            migrationBuilder.RenameColumn(
                name: "NameConquistasId",
                table: "Conquistas",
                newName: "GrupoConquistasGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Conquistas_NameConquistasId",
                table: "Conquistas",
                newName: "IX_Conquistas_GrupoConquistasGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conquistas_GrupoConquistas_GrupoConquistasGroupId",
                table: "Conquistas",
                column: "GrupoConquistasGroupId",
                principalTable: "GrupoConquistas",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
