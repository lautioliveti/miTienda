using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiTienda.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    categoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoriaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.categoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioContraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ususarioTipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    productoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoCategoria = table.Column<int>(type: "int", nullable: false),
                    productoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productoPrecio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    productoStock = table.Column<int>(type: "int", nullable: false),
                    productoImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.productoID);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_productoCategoria",
                        column: x => x.productoCategoria,
                        principalTable: "Categoria",
                        principalColumn: "categoriaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    ordenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ordenFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    ordenTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.ordenID);
                    table.ForeignKey(
                        name: "FK_Orden_Usuario_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuario",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenItem",
                columns: table => new
                {
                    ordenItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ordenID = table.Column<int>(type: "int", nullable: false),
                    productoID = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenItem", x => x.ordenItemID);
                    table.ForeignKey(
                        name: "FK_OrdenItem_Orden_ordenID",
                        column: x => x.ordenID,
                        principalTable: "Orden",
                        principalColumn: "ordenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenItem_Producto_productoID",
                        column: x => x.productoID,
                        principalTable: "Producto",
                        principalColumn: "productoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "categoriaID", "categoriaNombre" },
                values: new object[,]
                {
                    { 1, "Tecnologia" },
                    { 2, "Bedroom" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orden_usuarioID",
                table: "Orden",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItem_ordenID",
                table: "OrdenItem",
                column: "ordenID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItem_productoID",
                table: "OrdenItem",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_productoCategoria",
                table: "Producto",
                column: "productoCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenItem");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
