using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contactos.Migrations
{
    public partial class PrimerMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroDocumento = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactosId = table.Column<long>(type: "bigint", nullable: true),
                    TipoTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroTelefono = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefonos_Contactos_ContactosId",
                        column: x => x.ContactosId,
                        principalTable: "Contactos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contactos",
                columns: new[] { "Id", "Apellido", "Nombre", "NroDocumento", "TipoDocumento" },
                values: new object[] { 1L, "Santos", "Mario", 12345678L, "DNI" });

            migrationBuilder.InsertData(
                table: "Contactos",
                columns: new[] { "Id", "Apellido", "Nombre", "NroDocumento", "TipoDocumento" },
                values: new object[] { 2L, "Ravenna", "Emilio", 23456789L, "DNI" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Password", "Usuario1" },
                values: new object[] { 1L, "Password", "Admin" });

            migrationBuilder.InsertData(
                table: "Telefonos",
                columns: new[] { "Id", "ContactosId", "NroTelefono", "TipoTelefono" },
                values: new object[] { 1L, 1L, 1566778899L, "Movil" });

            migrationBuilder.InsertData(
                table: "Telefonos",
                columns: new[] { "Id", "ContactosId", "NroTelefono", "TipoTelefono" },
                values: new object[] { 2L, 1L, 1599887766L, "Movil" });

            migrationBuilder.InsertData(
                table: "Telefonos",
                columns: new[] { "Id", "ContactosId", "NroTelefono", "TipoTelefono" },
                values: new object[] { 3L, 2L, 1599887766L, "Movil" });

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_ContactosId",
                table: "Telefonos",
                column: "ContactosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Contactos");
        }
    }
}
