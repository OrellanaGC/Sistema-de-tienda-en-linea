using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaOnline.Migrations
{
    public partial class carrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                });

            migrationBuilder.CreateTable(
                name: "ProdCarrito",
                columns: table => new
                {
                    ProdCarritoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductoIdProducto = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    CarritoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCarrito", x => x.ProdCarritoId);
                    table.ForeignKey(
                        name: "FK_ProdCarrito_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdCarrito_PRODUCTO_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PRODUCTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdCarrito_CarritoId",
                table: "ProdCarrito",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCarrito_ProductoIdProducto",
                table: "ProdCarrito",
                column: "ProductoIdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdCarrito");

            migrationBuilder.DropTable(
                name: "Carrito");
        }
    }
}
