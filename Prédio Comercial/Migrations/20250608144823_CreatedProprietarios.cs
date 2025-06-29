using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrédioComercial.Migrations
{
    /// <inheritdoc />
    public partial class CreatedProprietarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProprietariosId",
                table: "Visitantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sala = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitantesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitantes_ProprietariosId",
                table: "Visitantes",
                column: "ProprietariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitantes_Proprietarios_ProprietariosId",
                table: "Visitantes",
                column: "ProprietariosId",
                principalTable: "Proprietarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitantes_Proprietarios_ProprietariosId",
                table: "Visitantes");

            migrationBuilder.DropTable(
                name: "Proprietarios");

            migrationBuilder.DropIndex(
                name: "IX_Visitantes_ProprietariosId",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "ProprietariosId",
                table: "Visitantes");
        }
    }
}
