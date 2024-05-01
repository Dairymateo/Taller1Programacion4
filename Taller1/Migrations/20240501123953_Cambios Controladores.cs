using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller1.Migrations
{
    /// <inheritdoc />
    public partial class CambiosControladores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propietario_Auto_AutoId",
                table: "Propietario");

            migrationBuilder.DropIndex(
                name: "IX_Propietario_AutoId",
                table: "Propietario");

            migrationBuilder.DropColumn(
                name: "AutoId",
                table: "Propietario");

            migrationBuilder.AddColumn<int>(
                name: "PropietarioId",
                table: "Auto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auto_PropietarioId",
                table: "Auto",
                column: "PropietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auto_Propietario_PropietarioId",
                table: "Auto",
                column: "PropietarioId",
                principalTable: "Propietario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auto_Propietario_PropietarioId",
                table: "Auto");

            migrationBuilder.DropIndex(
                name: "IX_Auto_PropietarioId",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "PropietarioId",
                table: "Auto");

            migrationBuilder.AddColumn<int>(
                name: "AutoId",
                table: "Propietario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Propietario_AutoId",
                table: "Propietario",
                column: "AutoId",
                unique: true,
                filter: "[AutoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Propietario_Auto_AutoId",
                table: "Propietario",
                column: "AutoId",
                principalTable: "Auto",
                principalColumn: "Id");
        }
    }
}
