using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiTienda.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNulosYRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Usuario_usuarioID",
                table: "Orden");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Orden_ordenID",
                table: "OrdenItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Producto_productoID",
                table: "OrdenItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_productoCategoria",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "usuarioNombre",
                table: "Usuario",
                newName: "UsuarioNombre");

            migrationBuilder.RenameColumn(
                name: "usuarioEmail",
                table: "Usuario",
                newName: "UsuarioEmail");

            migrationBuilder.RenameColumn(
                name: "usuarioContraseña",
                table: "Usuario",
                newName: "UsuarioContraseña");

            migrationBuilder.RenameColumn(
                name: "usuarioID",
                table: "Usuario",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "ususarioTipo",
                table: "Usuario",
                newName: "UsuarioTipo");

            migrationBuilder.RenameColumn(
                name: "productoStock",
                table: "Producto",
                newName: "ProductoStock");

            migrationBuilder.RenameColumn(
                name: "productoPrecio",
                table: "Producto",
                newName: "ProductoPrecio");

            migrationBuilder.RenameColumn(
                name: "productoNombre",
                table: "Producto",
                newName: "ProductoNombre");

            migrationBuilder.RenameColumn(
                name: "productoImagen",
                table: "Producto",
                newName: "ProductoImagen");

            migrationBuilder.RenameColumn(
                name: "productoDescripcion",
                table: "Producto",
                newName: "ProductoDescripcion");

            migrationBuilder.RenameColumn(
                name: "productoCategoria",
                table: "Producto",
                newName: "ProductoCategoria");

            migrationBuilder.RenameColumn(
                name: "productoID",
                table: "Producto",
                newName: "ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_productoCategoria",
                table: "Producto",
                newName: "IX_Producto_ProductoCategoria");

            migrationBuilder.RenameColumn(
                name: "productoID",
                table: "OrdenItem",
                newName: "ProductoID");

            migrationBuilder.RenameColumn(
                name: "precio",
                table: "OrdenItem",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "ordenID",
                table: "OrdenItem",
                newName: "OrdenID");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "OrdenItem",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "ordenItemID",
                table: "OrdenItem",
                newName: "OrdenItemID");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenItem_productoID",
                table: "OrdenItem",
                newName: "IX_OrdenItem_ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenItem_ordenID",
                table: "OrdenItem",
                newName: "IX_OrdenItem_OrdenID");

            migrationBuilder.RenameColumn(
                name: "usuarioID",
                table: "Orden",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "ordenTotal",
                table: "Orden",
                newName: "OrdenTotal");

            migrationBuilder.RenameColumn(
                name: "ordenFecha",
                table: "Orden",
                newName: "OrdenFecha");

            migrationBuilder.RenameColumn(
                name: "ordenID",
                table: "Orden",
                newName: "OrdenID");

            migrationBuilder.RenameIndex(
                name: "IX_Orden_usuarioID",
                table: "Orden",
                newName: "IX_Orden_UsuarioID");

            migrationBuilder.RenameColumn(
                name: "categoriaNombre",
                table: "Categoria",
                newName: "CategoriaNombre");

            migrationBuilder.RenameColumn(
                name: "categoriaID",
                table: "Categoria",
                newName: "CategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Usuario_UsuarioID",
                table: "Orden",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Orden_OrdenID",
                table: "OrdenItem",
                column: "OrdenID",
                principalTable: "Orden",
                principalColumn: "OrdenID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Producto_ProductoID",
                table: "OrdenItem",
                column: "ProductoID",
                principalTable: "Producto",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_ProductoCategoria",
                table: "Producto",
                column: "ProductoCategoria",
                principalTable: "Categoria",
                principalColumn: "CategoriaID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Usuario_UsuarioID",
                table: "Orden");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Orden_OrdenID",
                table: "OrdenItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Producto_ProductoID",
                table: "OrdenItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_ProductoCategoria",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "UsuarioNombre",
                table: "Usuario",
                newName: "usuarioNombre");

            migrationBuilder.RenameColumn(
                name: "UsuarioEmail",
                table: "Usuario",
                newName: "usuarioEmail");

            migrationBuilder.RenameColumn(
                name: "UsuarioContraseña",
                table: "Usuario",
                newName: "usuarioContraseña");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Usuario",
                newName: "usuarioID");

            migrationBuilder.RenameColumn(
                name: "UsuarioTipo",
                table: "Usuario",
                newName: "ususarioTipo");

            migrationBuilder.RenameColumn(
                name: "ProductoStock",
                table: "Producto",
                newName: "productoStock");

            migrationBuilder.RenameColumn(
                name: "ProductoPrecio",
                table: "Producto",
                newName: "productoPrecio");

            migrationBuilder.RenameColumn(
                name: "ProductoNombre",
                table: "Producto",
                newName: "productoNombre");

            migrationBuilder.RenameColumn(
                name: "ProductoImagen",
                table: "Producto",
                newName: "productoImagen");

            migrationBuilder.RenameColumn(
                name: "ProductoDescripcion",
                table: "Producto",
                newName: "productoDescripcion");

            migrationBuilder.RenameColumn(
                name: "ProductoCategoria",
                table: "Producto",
                newName: "productoCategoria");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "Producto",
                newName: "productoID");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_ProductoCategoria",
                table: "Producto",
                newName: "IX_Producto_productoCategoria");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "OrdenItem",
                newName: "productoID");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "OrdenItem",
                newName: "precio");

            migrationBuilder.RenameColumn(
                name: "OrdenID",
                table: "OrdenItem",
                newName: "ordenID");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "OrdenItem",
                newName: "cantidad");

            migrationBuilder.RenameColumn(
                name: "OrdenItemID",
                table: "OrdenItem",
                newName: "ordenItemID");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenItem_ProductoID",
                table: "OrdenItem",
                newName: "IX_OrdenItem_productoID");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenItem_OrdenID",
                table: "OrdenItem",
                newName: "IX_OrdenItem_ordenID");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Orden",
                newName: "usuarioID");

            migrationBuilder.RenameColumn(
                name: "OrdenTotal",
                table: "Orden",
                newName: "ordenTotal");

            migrationBuilder.RenameColumn(
                name: "OrdenFecha",
                table: "Orden",
                newName: "ordenFecha");

            migrationBuilder.RenameColumn(
                name: "OrdenID",
                table: "Orden",
                newName: "ordenID");

            migrationBuilder.RenameIndex(
                name: "IX_Orden_UsuarioID",
                table: "Orden",
                newName: "IX_Orden_usuarioID");

            migrationBuilder.RenameColumn(
                name: "CategoriaNombre",
                table: "Categoria",
                newName: "categoriaNombre");

            migrationBuilder.RenameColumn(
                name: "CategoriaID",
                table: "Categoria",
                newName: "categoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Usuario_usuarioID",
                table: "Orden",
                column: "usuarioID",
                principalTable: "Usuario",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Orden_ordenID",
                table: "OrdenItem",
                column: "ordenID",
                principalTable: "Orden",
                principalColumn: "ordenID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Producto_productoID",
                table: "OrdenItem",
                column: "productoID",
                principalTable: "Producto",
                principalColumn: "productoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_productoCategoria",
                table: "Producto",
                column: "productoCategoria",
                principalTable: "Categoria",
                principalColumn: "categoriaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
