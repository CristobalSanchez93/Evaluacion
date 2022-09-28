using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Consultas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    Art_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.Art_ID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cli_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Razon_Social = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CUIT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Deshabilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cli_ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Usua_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usua_ID);
                });

            migrationBuilder.CreateTable(
                name: "Factura_Cabecera",
                columns: table => new
                {
                    Compra_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cli_ID = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura_Cabecera", x => x.Compra_ID);
                    table.ForeignKey(
                        name: "FK_Factura_Cabecera_Cliente_Cli_ID",
                        column: x => x.Cli_ID,
                        principalTable: "Cliente",
                        principalColumn: "Cli_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura_Detalle",
                columns: table => new
                {
                    DT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compra_ID = table.Column<int>(type: "int", nullable: false),
                    Fecha_Alta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ART_ID = table.Column<int>(type: "int", nullable: false),
                    Cant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura_Detalle", x => x.DT_ID);
                    table.ForeignKey(
                        name: "FK_Factura_Detalle_Articulo_ART_ID",
                        column: x => x.ART_ID,
                        principalTable: "Articulo",
                        principalColumn: "Art_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_Detalle_Factura_Cabecera_Compra_ID",
                        column: x => x.Compra_ID,
                        principalTable: "Factura_Cabecera",
                        principalColumn: "Compra_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Cabecera_Cli_ID",
                table: "Factura_Cabecera",
                column: "Cli_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Detalle_ART_ID",
                table: "Factura_Detalle",
                column: "ART_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Detalle_Compra_ID",
                table: "Factura_Detalle",
                column: "Compra_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura_Detalle");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Factura_Cabecera");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
