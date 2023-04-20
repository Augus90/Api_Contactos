using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contactos.Migrations
{
    public partial class Modificalolasuniones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Usuarios_UsuarioId",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_UsuarioId",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Contactos");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_UserId",
                table: "Contactos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Usuarios_UserId",
                table: "Contactos",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Usuarios_UserId",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_UserId",
                table: "Contactos");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId",
                table: "Contactos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_UsuarioId",
                table: "Contactos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Usuarios_UsuarioId",
                table: "Contactos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
