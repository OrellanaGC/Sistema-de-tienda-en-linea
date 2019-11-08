using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class michelle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TipoDePago_TipoDePagoID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TipoDePagoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoDePagoID",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoDePagoID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TipoDePagoID",
                table: "AspNetUsers",
                column: "TipoDePagoID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TipoDePago_TipoDePagoID",
                table: "AspNetUsers",
                column: "TipoDePagoID",
                principalTable: "TipoDePago",
                principalColumn: "TipoDePagoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
