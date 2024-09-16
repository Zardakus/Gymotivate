using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasDeTreinos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiasSemana",
                columns: table => new
                {
                    DiaSemanaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasSemana", x => x.DiaSemanaId);
                });

            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    TreinosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.TreinosId);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    ExercicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiasSemanaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.ExercicioId);
                    table.ForeignKey(
                        name: "FK_Exercicios_DiasSemana_DiasSemanaId",
                        column: x => x.DiasSemanaId,
                        principalTable: "DiasSemana",
                        principalColumn: "DiaSemanaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreinoExercicio",
                columns: table => new
                {
                    TreinoExercicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreinoId = table.Column<int>(type: "int", nullable: false),
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    DiaSemanaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreinoExercicio", x => x.TreinoExercicioId);
                    table.ForeignKey(
                        name: "FK_TreinoExercicio_Cadastre_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Cadastre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreinoExercicio_DiasSemana_DiaSemanaId",
                        column: x => x.DiaSemanaId,
                        principalTable: "DiasSemana",
                        principalColumn: "DiaSemanaId");
                    table.ForeignKey(
                        name: "FK_TreinoExercicio_Exercicios_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicios",
                        principalColumn: "ExercicioId");
                    table.ForeignKey(
                        name: "FK_TreinoExercicio_Treinos_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treinos",
                        principalColumn: "TreinosId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_DiasSemanaId",
                table: "Exercicios",
                column: "DiasSemanaId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoExercicio_DiaSemanaId",
                table: "TreinoExercicio",
                column: "DiaSemanaId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoExercicio_ExercicioId",
                table: "TreinoExercicio",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoExercicio_TreinoId",
                table: "TreinoExercicio",
                column: "TreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinoExercicio_UsuarioId",
                table: "TreinoExercicio",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreinoExercicio");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Treinos");

            migrationBuilder.DropTable(
                name: "DiasSemana");
        }
    }
}
