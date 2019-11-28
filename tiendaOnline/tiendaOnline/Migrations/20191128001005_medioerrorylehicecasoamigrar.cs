using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class medioerrorylehicecasoamigrar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDeDescuento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDeDescuento",
                columns: table => new
                {
                    TipoDeDescuentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductoID = table.Column<int>(nullable: false),
                    montoDeDescuento = table.Column<int>(nullable: false),
                    nombreDelDescuento = table.Column<string>(maxLength: 20, nullable: true),
                    porcentajeDeDescuento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeDescuento", x => x.TipoDeDescuentoID);
                    table.ForeignKey(
                        name: "FK_TipoDeDescuento_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeDescuento_ProductoID",
                table: "TipoDeDescuento",
                column: "ProductoID",
                unique: true);
        }
    }
}
