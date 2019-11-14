using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class prodCarrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_ProdCarrito_prodCarritoID",
                table: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_prodCarritoID",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "prodCarritoID",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "CarritoID",
                table: "ProdCarrito",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProdCarrito_CarritoID",
                table: "ProdCarrito",
                column: "CarritoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdCarrito_Carrito_CarritoID",
                table: "ProdCarrito",
                column: "CarritoID",
                principalTable: "Carrito",
                principalColumn: "CarritoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdCarrito_Carrito_CarritoID",
                table: "ProdCarrito");

            migrationBuilder.DropIndex(
                name: "IX_ProdCarrito_CarritoID",
                table: "ProdCarrito");

            migrationBuilder.DropColumn(
                name: "CarritoID",
                table: "ProdCarrito");

            migrationBuilder.AddColumn<int>(
                name: "prodCarritoID",
                table: "Carrito",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_prodCarritoID",
                table: "Carrito",
                column: "prodCarritoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_ProdCarrito_prodCarritoID",
                table: "Carrito",
                column: "prodCarritoID",
                principalTable: "ProdCarrito",
                principalColumn: "ProdCarritoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
