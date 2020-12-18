using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rnc = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Nombre = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Direccion = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Lat = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Long = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Telefono = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Correo = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Contador = table.Column<int>(nullable: true),
                    MontoTotal = table.Column<double>(nullable: true),
                    FechaCumpleaños = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    Idfactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad_Art = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Itbis = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Cancelada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.Idfactura);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Produc = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Precio = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Cantidad = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Contador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    IdReporte = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    IdProducto = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    IdServicio = table.Column<string>(type: "Nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.IdReporte);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Servic = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Precio = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Descripcion = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Contador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "vendidos",
                columns: table => new
                {
                    IdVendido = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contador = table.Column<int>(nullable: false),
                    IdPS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendidos", x => x.IdVendido);
                    table.ForeignKey(
                        name: "FK_vendidos_productos_IdPS",
                        column: x => x.IdPS,
                        principalTable: "productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendidos_servicios_IdPS",
                        column: x => x.IdPS,
                        principalTable: "servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vendidos_IdPS",
                table: "vendidos",
                column: "IdPS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "vendidos");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "servicios");
        }
    }
}
