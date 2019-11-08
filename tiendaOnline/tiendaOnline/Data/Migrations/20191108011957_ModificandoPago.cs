using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class ModificandoPago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tiendaOnlineUserIDId",
                table: "TipoDePago",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tiendaOnlineUserId",
                table: "TipoDePago",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDePago_tiendaOnlineUserIDId",
                table: "TipoDePago",
                column: "tiendaOnlineUserIDId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDePago_tiendaOnlineUserId",
                table: "TipoDePago",
                column: "tiendaOnlineUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDePago_AspNetUsers_tiendaOnlineUserIDId",
                table: "TipoDePago",
                column: "tiendaOnlineUserIDId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDePago_AspNetUsers_tiendaOnlineUserId",
                table: "TipoDePago",
                column: "tiendaOnlineUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDePago_AspNetUsers_tiendaOnlineUserIDId",
                table: "TipoDePago");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoDePago_AspNetUsers_tiendaOnlineUserId",
                table: "TipoDePago");

            migrationBuilder.DropIndex(
                name: "IX_TipoDePago_tiendaOnlineUserIDId",
                table: "TipoDePago");

            migrationBuilder.DropIndex(
                name: "IX_TipoDePago_tiendaOnlineUserId",
                table: "TipoDePago");

            migrationBuilder.DropColumn(
                name: "tiendaOnlineUserIDId",
                table: "TipoDePago");

            migrationBuilder.DropColumn(
                name: "tiendaOnlineUserId",
                table: "TipoDePago");
        }
    }
}
