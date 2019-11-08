using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoDePagoID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DetalleProducto",
                columns: table => new
                {
                    DetalleProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Talla = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    PesoKg = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProducto", x => x.DetalleProductoID);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreProducto = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    DetalleProductoID = table.Column<int>(nullable: false),
                    SubcategoriaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Producto_DetalleProducto_DetalleProductoID",
                        column: x => x.DetalleProductoID,
                        principalTable: "DetalleProducto",
                        principalColumn: "DetalleProductoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Subcategoria_SubcategoriaID",
                        column: x => x.SubcategoriaID,
                        principalTable: "Subcategoria",
                        principalColumn: "SubcategoriaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TipoDePagoID",
                table: "AspNetUsers",
                column: "TipoDePagoID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_DetalleProductoID",
                table: "Producto",
                column: "DetalleProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_SubcategoriaID",
                table: "Producto",
                column: "SubcategoriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TipoDePago_TipoDePagoID",
                table: "AspNetUsers",
                column: "TipoDePagoID",
                principalTable: "TipoDePago",
                principalColumn: "TipoDePagoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TipoDePago_TipoDePagoID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "DetalleProducto");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TipoDePagoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoDePagoID",
                table: "AspNetUsers");
        }
    }
}
