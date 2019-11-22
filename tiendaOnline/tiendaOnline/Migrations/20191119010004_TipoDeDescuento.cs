using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class TipoDeDescuento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDeDescuento",
                columns: table => new
                {
                    TipoDeDescuentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreDelDescuento = table.Column<string>(maxLength: 20, nullable: false),
                    montoDeDescuento = table.Column<int>(nullable: false),
                    porcentajeDeDescuento = table.Column<int>(nullable: false),
                    ProductoID = table.Column<int>(nullable: true),
                    detalleVendedorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeDescuento", x => x.TipoDeDescuentoID);
                    table.ForeignKey(
                        name: "FK_TipoDeDescuento_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoDeDescuento_DetalleVendedor_detalleVendedorID",
                        column: x => x.detalleVendedorID,
                        principalTable: "DetalleVendedor",
                        principalColumn: "DetalleVendedorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeDescuento_ProductoID",
                table: "TipoDeDescuento",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeDescuento_detalleVendedorID",
                table: "TipoDeDescuento",
                column: "detalleVendedorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDeDescuento");
        }
    }
}
