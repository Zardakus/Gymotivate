using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymotivate.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaConquistasNameEVinculando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConquistaName",
                table: "Conquistas");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Conquistas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Conquistas");

            migrationBuilder.AlterColumn<int>(
                name: "GroupExpTotal",
                table: "GrupoConquistas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ConquistaExp",
                table: "Conquistas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "NameConquistas",
                columns: table => new
                {
                    NameConquistasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConquistasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameConquistas", x => x.NameConquistasId);
                    table.ForeignKey(
                        name: "FK_NameConquistas_Conquistas_ConquistasId",
                        column: x => x.ConquistasId,
                        principalTable: "Conquistas",
                        principalColumn: "ConquistasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NameConquistas_ConquistasId",
                table: "NameConquistas",
                column: "ConquistasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NameConquistas");

            migrationBuilder.AlterColumn<string>(
                name: "GroupExpTotal",
                table: "GrupoConquistas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ConquistaExp",
                table: "Conquistas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ConquistaName",
                table: "Conquistas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Conquistas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Conquistas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
