using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class vers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_MetodoEnvio_metodoEnvioID",
                table: "Orden");

            migrationBuilder.AlterColumn<int>(
                name: "metodoEnvioID",
                table: "Orden",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_MetodoEnvio_metodoEnvioID",
                table: "Orden",
                column: "metodoEnvioID",
                principalTable: "MetodoEnvio",
                principalColumn: "MetodoEnvioID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orden_MetodoEnvio_metodoEnvioID",
                table: "Orden");

            migrationBuilder.AlterColumn<int>(
                name: "metodoEnvioID",
                table: "Orden",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_MetodoEnvio_metodoEnvioID",
                table: "Orden",
                column: "metodoEnvioID",
                principalTable: "MetodoEnvio",
                principalColumn: "MetodoEnvioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
