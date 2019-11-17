using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class modelosParaOrdenETC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cupon",
                columns: table => new
                {
                    CuponID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigoCupon = table.Column<string>(nullable: true),
                    montoCupon = table.Column<double>(nullable: false),
                    estadoCupon = table.Column<bool>(nullable: false),
                    fechaCreacion = table.Column<DateTime>(nullable: false),
                    fechaVencimiento = table.Column<DateTime>(nullable: false),
                    descripcionCupon = table.Column<string>(nullable: true),
                    tiendaOnlineUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupon", x => x.CuponID);
                    table.ForeignKey(
                        name: "FK_Cupon_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetodoEnvio",
                columns: table => new
                {
                    MetodoEnvioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreMetodoEnvio = table.Column<string>(nullable: false),
                    maxDiasEnvio = table.Column<int>(nullable: false),
                    minDiasEnvio = table.Column<int>(nullable: false),
                    montoEnvio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoEnvio", x => x.MetodoEnvioID);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaOrden = table.Column<DateTime>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    estadoDeOrden = table.Column<bool>(nullable: false),
                    tiendaOnlineUserID = table.Column<string>(nullable: true),
                    metodoEnvioID = table.Column<int>(nullable: false),
                    cuponID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenID);
                    table.ForeignKey(
                        name: "FK_Orden_Cupon_cuponID",
                        column: x => x.cuponID,
                        principalTable: "Cupon",
                        principalColumn: "CuponID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_MetodoEnvio_metodoEnvioID",
                        column: x => x.metodoEnvioID,
                        principalTable: "MetodoEnvio",
                        principalColumn: "MetodoEnvioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineaDeOrden",
                columns: table => new
                {
                    LineaDeOrdenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    subtotal = table.Column<double>(nullable: false),
                    productoCarritoID = table.Column<int>(nullable: false),
                    ordenID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaDeOrden", x => x.LineaDeOrdenID);
                    table.ForeignKey(
                        name: "FK_LineaDeOrden_Orden_ordenID",
                        column: x => x.ordenID,
                        principalTable: "Orden",
                        principalColumn: "OrdenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaDeOrden_ProdCarrito_productoCarritoID",
                        column: x => x.productoCarritoID,
                        principalTable: "ProdCarrito",
                        principalColumn: "ProdCarritoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cupon_tiendaOnlineUserID",
                table: "Cupon",
                column: "tiendaOnlineUserID");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeOrden_ordenID",
                table: "LineaDeOrden",
                column: "ordenID");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeOrden_productoCarritoID",
                table: "LineaDeOrden",
                column: "productoCarritoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orden_cuponID",
                table: "Orden",
                column: "cuponID");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_metodoEnvioID",
                table: "Orden",
                column: "metodoEnvioID");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_tiendaOnlineUserID",
                table: "Orden",
                column: "tiendaOnlineUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaDeOrden");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Cupon");

            migrationBuilder.DropTable(
                name: "MetodoEnvio");
        }
    }
}
