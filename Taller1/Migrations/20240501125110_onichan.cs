using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller1.Migrations
{
    /// <inheritdoc />
    public partial class onichan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutoId",
                table: "Motor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motor_AutoId",
                table: "Motor",
                column: "AutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motor_Auto_AutoId",
                table: "Motor",
                column: "AutoId",
                principalTable: "Auto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motor_Auto_AutoId",
                table: "Motor");

            migrationBuilder.DropIndex(
                name: "IX_Motor_AutoId",
                table: "Motor");

            migrationBuilder.DropColumn(
                name: "AutoId",
                table: "Motor");
        }
    }
}
