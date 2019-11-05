using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class quitandoRelacionBidireccionalCarritoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarritoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "tiendaOnlineUserID",
                table: "Carrito");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarritoID",
                table: "AspNetUsers",
                column: "CarritoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarritoID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "tiendaOnlineUserID",
                table: "Carrito",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarritoID",
                table: "AspNetUsers",
                column: "CarritoID",
                unique: true);
        }
    }
}
