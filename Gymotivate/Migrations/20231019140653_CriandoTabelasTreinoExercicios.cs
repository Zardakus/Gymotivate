using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasTreinoExercicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    ExercicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.ExercicioId);
                });

            migrationBuilder.CreateTable(
                name: "Treino",
                columns: table => new
                {
                    TreinoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treino", x => x.TreinoId);
                    table.ForeignKey(
                        name: "FK_Treino_Cadastre_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "Cadastre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreinoDiaSemana",
                columns: table => new
                {
                    TreinoDiaSemanaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreinoId1 = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreinoDiaSemana", x => x.TreinoDiaSemanaId);
                    table.ForeignKey(
                        name: "FK_TreinoDiaSemana_Treino_TreinoId1",
                        column: x => x.TreinoId1,
                        principalTable: "Treino",
                        principalColumn: "TreinoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreinoExercicio",
                columns: table => new
                {
                    TreinoExercicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreinoDiaSemanaId1 = table.Column<int>(type: "int", nullable: false),
                    ExercicioId1 = table.Column<int>(type: "int", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreinoExercicio", x => x.TreinoExercicioId);
                    table.ForeignKey(
                        name: "FK_TreinoExercicio_Exercicio_ExercicioId1",
                        column: x => x.ExercicioId1,
                        principalTable: "Exercicio",
                        principalColumn: "ExercicioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreinoExercicio_TreinoDiaSemana_TreinoDiaSemanaId1",
                        column: x => x.TreinoDiaSemanaId1,
                        principalTable: "TreinoDiaSemana",
                        principalColumn: "TreinoDiaSemanaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treino_UserIdId",
                table: "Treino",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoDiaSemana_TreinoId1",
                table: "TreinoDiaSemana",
                column: "TreinoId1");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoExercicio_ExercicioId1",
                table: "TreinoExercicio",
                column: "ExercicioId1");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoExercicio_TreinoDiaSemanaId1",
                table: "TreinoExercicio",
                column: "TreinoDiaSemanaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreinoExercicio");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "TreinoDiaSemana");

            migrationBuilder.DropTable(
                name: "Treino");
        }
    }
}
