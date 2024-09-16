using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoNomeTabelaAcertos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesModel_Cadastre_UsuarioId",
                table: "GamesModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesModel",
                table: "GamesModel");

            migrationBuilder.RenameTable(
                name: "GamesModel",
                newName: "Acertos");

            migrationBuilder.RenameIndex(
                name: "IX_GamesModel_UsuarioId",
                table: "Acertos",
                newName: "IX_Acertos_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acertos",
                table: "Acertos",
                column: "GamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acertos_Cadastre_UsuarioId",
                table: "Acertos",
                column: "UsuarioId",
                principalTable: "Cadastre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acertos_Cadastre_UsuarioId",
                table: "Acertos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acertos",
                table: "Acertos");

            migrationBuilder.RenameTable(
                name: "Acertos",
                newName: "GamesModel");

            migrationBuilder.RenameIndex(
                name: "IX_Acertos_UsuarioId",
                table: "GamesModel",
                newName: "IX_GamesModel_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesModel",
                table: "GamesModel",
                column: "GamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesModel_Cadastre_UsuarioId",
                table: "GamesModel",
                column: "UsuarioId",
                principalTable: "Cadastre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
