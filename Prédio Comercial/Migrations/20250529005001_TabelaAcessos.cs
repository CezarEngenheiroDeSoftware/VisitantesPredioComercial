using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrédioComercial.Migrations
{
    /// <inheritdoc />
    public partial class TabelaAcessos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acessos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitanteId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false),
                    SalaComercial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSalaComercial = table.Column<int>(type: "int", nullable: false),
                    EntrouComOQue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Acessos_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acessos_Visitantes_VisitanteId",
                        column: x => x.VisitanteId,
                        principalTable: "Visitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_UsuariosId",
                table: "Acessos",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_VisitanteId",
                table: "Acessos",
                column: "VisitanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acessos");
        }
    }
}
