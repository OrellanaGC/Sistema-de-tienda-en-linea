using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class TipoDeDescuentox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeDescuento_Producto_ProductoID",
                table: "TipoDeDescuento");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeDescuento_DetalleVendedor_detalleVendedorID",
                table: "TipoDeDescuento");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeDescuento_ProductoID",
                table: "TipoDeDescuento");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeDescuento_detalleVendedorID",
                table: "TipoDeDescuento");

            migrationBuilder.DropColumn(
                name: "detalleVendedorID",
                table: "TipoDeDescuento");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "TipoDeDescuento",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeDescuento_ProductoID",
                table: "TipoDeDescuento",
                column: "ProductoID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeDescuento_Producto_ProductoID",
                table: "TipoDeDescuento",
                column: "ProductoID",
                principalTable: "Producto",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDeDescuento_Producto_ProductoID",
                table: "TipoDeDescuento");

            migrationBuilder.DropIndex(
                name: "IX_TipoDeDescuento_ProductoID",
                table: "TipoDeDescuento");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "TipoDeDescuento",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "detalleVendedorID",
                table: "TipoDeDescuento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeDescuento_ProductoID",
                table: "TipoDeDescuento",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeDescuento_detalleVendedorID",
                table: "TipoDeDescuento",
                column: "detalleVendedorID");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeDescuento_Producto_ProductoID",
                table: "TipoDeDescuento",
                column: "ProductoID",
                principalTable: "Producto",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDeDescuento_DetalleVendedor_detalleVendedorID",
                table: "TipoDeDescuento",
                column: "detalleVendedorID",
                principalTable: "DetalleVendedor",
                principalColumn: "DetalleVendedorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
