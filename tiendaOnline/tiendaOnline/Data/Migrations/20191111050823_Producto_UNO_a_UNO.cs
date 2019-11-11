using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class Producto_UNO_a_UNO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_DetalleProducto_DetalleProductoID",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_DetalleProductoID",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "DetalleProductoID",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "Producto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DetalleProductoID",
                table: "DetalleProducto",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProducto",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "DetalleProducto",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "DetalleProducto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_ProductoId",
                table: "DetalleProducto",
                column: "ProductoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProducto_Producto_ProductoId",
                table: "DetalleProducto",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProducto_Producto_ProductoId",
                table: "DetalleProducto");

            migrationBuilder.DropIndex(
                name: "IX_DetalleProducto_ProductoId",
                table: "DetalleProducto");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "DetalleProducto");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producto",
                newName: "ProductoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetalleProducto",
                newName: "DetalleProductoID");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProducto",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "DetalleProductoID",
                table: "Producto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "DetalleProducto",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Producto_DetalleProductoID",
                table: "Producto",
                column: "DetalleProductoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_DetalleProducto_DetalleProductoID",
                table: "Producto",
                column: "DetalleProductoID",
                principalTable: "DetalleProducto",
                principalColumn: "DetalleProductoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
