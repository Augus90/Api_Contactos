using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contactos.Migrations
{
    public partial class Agregouserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Contactos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contactos");
        }
    }
}
