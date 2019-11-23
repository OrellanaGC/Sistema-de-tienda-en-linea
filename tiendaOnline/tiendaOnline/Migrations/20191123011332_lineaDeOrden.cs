using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class lineaDeOrden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeOrden_Producto_ProductoID",
                table: "LineaDeOrden");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "LineaDeOrden",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeOrden_Producto_ProductoID",
                table: "LineaDeOrden",
                column: "ProductoID",
                principalTable: "Producto",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaDeOrden_Producto_ProductoID",
                table: "LineaDeOrden");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "LineaDeOrden",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaDeOrden_Producto_ProductoID",
                table: "LineaDeOrden",
                column: "ProductoID",
                principalTable: "Producto",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
