using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class orden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeOrden_Orden_ordenID",
                table: "LineaDeOrden");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeOrden_ProdCarrito_productoCarritoID",
                table: "LineaDeOrden");

            migrationBuilder.DropIndex(
                name: "IX_LineaDeOrden_productoCarritoID",
                table: "LineaDeOrden");

            migrationBuilder.RenameColumn(
                name: "ordenID",
                table: "LineaDeOrden",
                newName: "OrdenID");

            migrationBuilder.RenameColumn(
                name: "productoCarritoID",
                table: "LineaDeOrden",
                newName: "ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_LineaDeOrden_ordenID",
                table: "LineaDeOrden",
                newName: "IX_LineaDeOrden_OrdenID");

            migrationBuilder.AddColumn<int>(
                name: "lineaOrdenLineaDeOrdenID",
                table: "ProdCarrito",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "LineaDeOrden",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProdCarrito_lineaOrdenLineaDeOrdenID",
                table: "ProdCarrito",
                column: "lineaOrdenLineaDeOrdenID");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeOrden_ProductoID",
                table: "LineaDeOrden",
                column: "ProductoID");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeOrden_Orden_OrdenID",
                table: "LineaDeOrden",
                column: "OrdenID",
                principalTable: "Orden",
                principalColumn: "OrdenID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeOrden_Producto_ProductoID",
                table: "LineaDeOrden",
                column: "ProductoID",
                principalTable: "Producto",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdCarrito_LineaDeOrden_lineaOrdenLineaDeOrdenID",
                table: "ProdCarrito",
                column: "lineaOrdenLineaDeOrdenID",
                principalTable: "LineaDeOrden",
                principalColumn: "LineaDeOrdenID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeOrden_Orden_OrdenID",
                table: "LineaDeOrden");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeOrden_Producto_ProductoID",
                table: "LineaDeOrden");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdCarrito_LineaDeOrden_lineaOrdenLineaDeOrdenID",
                table: "ProdCarrito");

            migrationBuilder.DropIndex(
                name: "IX_ProdCarrito_lineaOrdenLineaDeOrdenID",
                table: "ProdCarrito");

            migrationBuilder.DropIndex(
                name: "IX_LineaDeOrden_ProductoID",
                table: "LineaDeOrden");

            migrationBuilder.DropColumn(
                name: "lineaOrdenLineaDeOrdenID",
                table: "ProdCarrito");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "LineaDeOrden");

            migrationBuilder.RenameColumn(
                name: "OrdenID",
                table: "LineaDeOrden",
                newName: "ordenID");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "LineaDeOrden",
                newName: "productoCarritoID");

            migrationBuilder.RenameIndex(
                name: "IX_LineaDeOrden_OrdenID",
                table: "LineaDeOrden",
                newName: "IX_LineaDeOrden_ordenID");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeOrden_productoCarritoID",
                table: "LineaDeOrden",
                column: "productoCarritoID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeOrden_Orden_ordenID",
                table: "LineaDeOrden",
                column: "ordenID",
                principalTable: "Orden",
                principalColumn: "OrdenID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeOrden_ProdCarrito_productoCarritoID",
                table: "LineaDeOrden",
                column: "productoCarritoID",
                principalTable: "ProdCarrito",
                principalColumn: "ProdCarritoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
