using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class probandouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tiendaOnlineUserID",
                table: "Direccion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_tiendaOnlineUserID",
                table: "Direccion",
                column: "tiendaOnlineUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_AspNetUsers_tiendaOnlineUserID",
                table: "Direccion",
                column: "tiendaOnlineUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_AspNetUsers_tiendaOnlineUserID",
                table: "Direccion");

            migrationBuilder.DropIndex(
                name: "IX_Direccion_tiendaOnlineUserID",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "tiendaOnlineUserID",
                table: "Direccion");
        }
    }
}
