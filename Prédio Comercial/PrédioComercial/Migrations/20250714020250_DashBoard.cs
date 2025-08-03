using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrédioComercial.Migrations
{
    /// <inheritdoc />
    public partial class DashBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dashBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProprietariosId = table.Column<int>(type: "int", nullable: true),
                    VisitantesId = table.Column<int>(type: "int", nullable: true),
                    UsuariosId = table.Column<int>(type: "int", nullable: true),
                    OcorrenciasId = table.Column<int>(type: "int", nullable: true),
                    Acessosid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dashBoards_Acessos_Acessosid",
                        column: x => x.Acessosid,
                        principalTable: "Acessos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_dashBoards_Ocorrencias_OcorrenciasId",
                        column: x => x.OcorrenciasId,
                        principalTable: "Ocorrencias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dashBoards_Proprietarios_ProprietariosId",
                        column: x => x.ProprietariosId,
                        principalTable: "Proprietarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dashBoards_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dashBoards_Visitantes_VisitantesId",
                        column: x => x.VisitantesId,
                        principalTable: "Visitantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dashBoards_Acessosid",
                table: "dashBoards",
                column: "Acessosid");

            migrationBuilder.CreateIndex(
                name: "IX_dashBoards_OcorrenciasId",
                table: "dashBoards",
                column: "OcorrenciasId");

            migrationBuilder.CreateIndex(
                name: "IX_dashBoards_ProprietariosId",
                table: "dashBoards",
                column: "ProprietariosId");

            migrationBuilder.CreateIndex(
                name: "IX_dashBoards_UsuariosId",
                table: "dashBoards",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_dashBoards_VisitantesId",
                table: "dashBoards",
                column: "VisitantesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dashBoards");
        }
    }
}
