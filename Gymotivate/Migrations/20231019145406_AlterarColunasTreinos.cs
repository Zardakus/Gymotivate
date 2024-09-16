using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class AlterarColunasTreinos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treino_Cadastre_UserIdId",
                table: "Treino");

            migrationBuilder.DropForeignKey(
                name: "FK_TreinoDiaSemana_Treino_TreinoId1",
                table: "TreinoDiaSemana");

            migrationBuilder.DropForeignKey(
                name: "FK_TreinoExercicio_Exercicio_ExercicioId1",
                table: "TreinoExercicio");

            migrationBuilder.DropForeignKey(
                name: "FK_TreinoExercicio_TreinoDiaSemana_TreinoDiaSemanaId1",
                table: "TreinoExercicio");

            migrationBuilder.RenameColumn(
                name: "TreinoDiaSemanaId1",
                table: "TreinoExercicio",
                newName: "TreinoDiaSemanaId");

            migrationBuilder.RenameColumn(
                name: "ExercicioId1",
                table: "TreinoExercicio",
                newName: "ExercicioId");

            migrationBuilder.RenameIndex(
                name: "IX_TreinoExercicio_TreinoDiaSemanaId1",
                table: "TreinoExercicio",
                newName: "IX_TreinoExercicio_TreinoDiaSemanaId");

            migrationBuilder.RenameIndex(
                name: "IX_TreinoExercicio_ExercicioId1",
                table: "TreinoExercicio",
                newName: "IX_TreinoExercicio_ExercicioId");

            migrationBuilder.RenameColumn(
                name: "TreinoId1",
                table: "TreinoDiaSemana",
                newName: "TreinoId");

            migrationBuilder.RenameIndex(
                name: "IX_TreinoDiaSemana_TreinoId1",
                table: "TreinoDiaSemana",
                newName: "IX_TreinoDiaSemana_TreinoId");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Treino",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Treino_UserIdId",
                table: "Treino",
                newName: "IX_Treino_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treino_Cadastre_UserId",
                table: "Treino",
                column: "UserId",
                principalTable: "Cadastre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreinoDiaSemana_Treino_TreinoId",
                table: "TreinoDiaSemana",
                column: "TreinoId",
                principalTable: "Treino",
                principalColumn: "TreinoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreinoExercicio_Exercicio_ExercicioId",
                table: "TreinoExercicio",
                column: "ExercicioId",
                principalTable: "Exercicio",
                principalColumn: "ExercicioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreinoExercicio_TreinoDiaSemana_TreinoDiaSemanaId",
                table: "TreinoExercicio",
                column: "TreinoDiaSemanaId",
                principalTable: "TreinoDiaSemana",
                principalColumn: "TreinoDiaSemanaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treino_Cadastre_UserId",
                table: "Treino");

            migrationBuilder.DropForeignKey(
                name: "FK_TreinoDiaSemana_Treino_TreinoId",
                table: "TreinoDiaSemana");

            migrationBuilder.DropForeignKey(
                name: "FK_TreinoExercicio_Exercicio_ExercicioId",
                table: "TreinoExercicio");

            migrationBuilder.DropForeignKey(
                name: "FK_TreinoExercicio_TreinoDiaSemana_TreinoDiaSemanaId",
                table: "TreinoExercicio");

            migrationBuilder.RenameColumn(
                name: "TreinoDiaSemanaId",
                table: "TreinoExercicio",
                newName: "TreinoDiaSemanaId1");

            migrationBuilder.RenameColumn(
                name: "ExercicioId",
                table: "TreinoExercicio",
                newName: "ExercicioId1");

            migrationBuilder.RenameIndex(
                name: "IX_TreinoExercicio_TreinoDiaSemanaId",
                table: "TreinoExercicio",
                newName: "IX_TreinoExercicio_TreinoDiaSemanaId1");

            migrationBuilder.RenameIndex(
                name: "IX_TreinoExercicio_ExercicioId",
                table: "TreinoExercicio",
                newName: "IX_TreinoExercicio_ExercicioId1");

            migrationBuilder.RenameColumn(
                name: "TreinoId",
                table: "TreinoDiaSemana",
                newName: "TreinoId1");

            migrationBuilder.RenameIndex(
                name: "IX_TreinoDiaSemana_TreinoId",
                table: "TreinoDiaSemana",
                newName: "IX_TreinoDiaSemana_TreinoId1");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Treino",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Treino_UserId",
                table: "Treino",
                newName: "IX_Treino_UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treino_Cadastre_UserIdId",
                table: "Treino",
                column: "UserIdId",
                principalTable: "Cadastre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreinoDiaSemana_Treino_TreinoId1",
                table: "TreinoDiaSemana",
                column: "TreinoId1",
                principalTable: "Treino",
                principalColumn: "TreinoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreinoExercicio_Exercicio_ExercicioId1",
                table: "TreinoExercicio",
                column: "ExercicioId1",
                principalTable: "Exercicio",
                principalColumn: "ExercicioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreinoExercicio_TreinoDiaSemana_TreinoDiaSemanaId1",
                table: "TreinoExercicio",
                column: "TreinoDiaSemanaId1",
                principalTable: "TreinoDiaSemana",
                principalColumn: "TreinoDiaSemanaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
