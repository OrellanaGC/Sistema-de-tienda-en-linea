using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class pago3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paypal",
                columns: table => new
                {
                    PaypalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    correoPaypal = table.Column<string>(nullable: true),
                    psswrdPaypal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paypal", x => x.PaypalID);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    TarjetaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigoTarjeta = table.Column<int>(nullable: false),
                    tipoTarjeta = table.Column<string>(nullable: true),
                    fechaVencimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.TarjetaID);
                });

            migrationBuilder.CreateTable(
                name: "TipoDePago",
                columns: table => new
                {
                    TipoDePagoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaypalID = table.Column<int>(nullable: false),
                    TarjetaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDePago", x => x.TipoDePagoID);
                    table.ForeignKey(
                        name: "FK_TipoDePago_Paypal_PaypalID",
                        column: x => x.PaypalID,
                        principalTable: "Paypal",
                        principalColumn: "PaypalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoDePago_Tarjeta_TarjetaID",
                        column: x => x.TarjetaID,
                        principalTable: "Tarjeta",
                        principalColumn: "TarjetaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoDePago_PaypalID",
                table: "TipoDePago",
                column: "PaypalID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDePago_TarjetaID",
                table: "TipoDePago",
                column: "TarjetaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDePago");

            migrationBuilder.DropTable(
                name: "Paypal");

            migrationBuilder.DropTable(
                name: "Tarjeta");
        }
    }
}
