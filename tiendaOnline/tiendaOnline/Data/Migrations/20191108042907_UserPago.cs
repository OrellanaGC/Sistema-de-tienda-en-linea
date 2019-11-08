using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class UserPago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "tiendaOnlineUserIDId",
                table: "TipoDePago");

            migrationBuilder.RenameColumn(
                name: "tiendaOnlineUserId",
                table: "TipoDePago",
                newName: "tiendaOnlineUserID");

            migrationBuilder.RenameIndex(
                name: "IX_TipoDePago_tiendaOnlineUserId",
                table: "TipoDePago",
                newName: "IX_TipoDePago_tiendaOnlineUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDePago_AspNetUsers_tiendaOnlineUserID",
                table: "TipoDePago",
                column: "tiendaOnlineUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDePago_AspNetUsers_tiendaOnlineUserID",
                table: "TipoDePago");

            migrationBuilder.RenameColumn(
                name: "tiendaOnlineUserID",
                table: "TipoDePago",
                newName: "tiendaOnlineUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TipoDePago_tiendaOnlineUserID",
                table: "TipoDePago",
                newName: "IX_TipoDePago_tiendaOnlineUserId");

            migrationBuilder.AddColumn<string>(
                name: "tiendaOnlineUserIDId",
                table: "TipoDePago",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDePago_tiendaOnlineUserIDId",
                table: "TipoDePago",
                column: "tiendaOnlineUserIDId");

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
    }
}
