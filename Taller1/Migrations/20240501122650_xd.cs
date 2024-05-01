using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller1.Migrations
{
    /// <inheritdoc />
    public partial class xd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auto_Propietario_propietarioId",
                table: "Auto");

            migrationBuilder.DropIndex(
                name: "IX_Auto_propietarioId",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "propietarioId",
                table: "Auto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha",
                table: "Propietario",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateOnly>(
                name: "fecha",
                table: "Propietario",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "propietarioId",
                table: "Auto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auto_propietarioId",
                table: "Auto",
                column: "propietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auto_Propietario_propietarioId",
                table: "Auto",
                column: "propietarioId",
                principalTable: "Propietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
