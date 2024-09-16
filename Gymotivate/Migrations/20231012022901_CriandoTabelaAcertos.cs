using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaAcertos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamesModel",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcertosPeitos = table.Column<int>(type: "int", nullable: false),
                    AcertosCostas = table.Column<int>(type: "int", nullable: false),
                    AcertosPernas = table.Column<int>(type: "int", nullable: false),
                    AcertosBracos = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesModel", x => x.GamesId);
                    table.ForeignKey(
                        name: "FK_GamesModel_Cadastre_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Cadastre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamesModel_UsuarioId",
                table: "GamesModel",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesModel");
        }
    }
}
