using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class VendedorYTarjetoNulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_DetalleVendedor_detalleVendedorID",
                table: "Tarjeta");

            migrationBuilder.AlterColumn<int>(
                name: "detalleVendedorID",
                table: "Tarjeta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_DetalleVendedor_detalleVendedorID",
                table: "Tarjeta",
                column: "detalleVendedorID",
                principalTable: "DetalleVendedor",
                principalColumn: "DetalleVendedorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_DetalleVendedor_detalleVendedorID",
                table: "Tarjeta");

            migrationBuilder.AlterColumn<int>(
                name: "detalleVendedorID",
                table: "Tarjeta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_DetalleVendedor_detalleVendedorID",
                table: "Tarjeta",
                column: "detalleVendedorID",
                principalTable: "DetalleVendedor",
                principalColumn: "DetalleVendedorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
