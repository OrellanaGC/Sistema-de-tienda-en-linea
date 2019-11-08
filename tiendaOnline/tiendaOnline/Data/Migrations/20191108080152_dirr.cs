using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Data.Migrations
{
    public partial class dirr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_AspNetUsers_userID",
                table: "Direccion");

            migrationBuilder.DropIndex(
                name: "IX_Direccion_userID",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "Direccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userID",
                table: "Direccion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_userID",
                table: "Direccion",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_AspNetUsers_userID",
                table: "Direccion",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
