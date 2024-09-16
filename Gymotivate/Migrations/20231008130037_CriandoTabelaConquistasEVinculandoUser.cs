using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaConquistasEVinculandoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conquistas",
                columns: table => new
                {
                    ConquistasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ConquistaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConquistaExp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    GrupoConquistasGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistas", x => x.ConquistasId);
                    table.ForeignKey(
                        name: "FK_Conquistas_Cadastre_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Cadastre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conquistas_GrupoConquistas_GrupoConquistasGroupId",
                        column: x => x.GrupoConquistasGroupId,
                        principalTable: "GrupoConquistas",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conquistas_GrupoConquistasGroupId",
                table: "Conquistas",
                column: "GrupoConquistasGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistas_UsuarioId",
                table: "Conquistas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conquistas");
        }
    }
}
