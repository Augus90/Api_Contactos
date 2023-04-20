using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contactos.Migrations
{
    public partial class Agregolistadecontactos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
