using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrédioComercial.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoDeDateTimeNaModelDashBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInclusao",
                table: "dashBoards",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInclusao",
                table: "dashBoards");
        }
    }
}
