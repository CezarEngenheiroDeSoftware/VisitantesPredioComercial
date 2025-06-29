using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrédioComercial.Migrations
{
    /// <inheritdoc />
    public partial class InitialProprietarioVariosVisitantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProprietariosId",
                table: "Visitantes",
                type: "int",
                nullable: true);

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

            migrationBuilder.DropIndex(
                name: "IX_Visitantes_ProprietariosId",
                table: "Visitantes");

            migrationBuilder.DropColumn(
                name: "ProprietariosId",
                table: "Visitantes");
        }
    }
}
