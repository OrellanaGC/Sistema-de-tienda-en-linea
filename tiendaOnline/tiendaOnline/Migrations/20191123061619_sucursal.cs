using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class sucursal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SucursalID",
                table: "Direccion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SucursalID1",
                table: "Direccion",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcionCupon",
                table: "Cupon",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigoCupon",
                table: "Cupon",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    SucursalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.SucursalID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_SucursalID1",
                table: "Direccion",
                column: "SucursalID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_Sucursal_SucursalID1",
                table: "Direccion",
                column: "SucursalID1",
                principalTable: "Sucursal",
                principalColumn: "SucursalID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_Sucursal_SucursalID1",
                table: "Direccion");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropIndex(
                name: "IX_Direccion_SucursalID1",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "SucursalID",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "SucursalID1",
                table: "Direccion");

            migrationBuilder.AlterColumn<string>(
                name: "descripcionCupon",
                table: "Cupon",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "codigoCupon",
                table: "Cupon",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 7);
        }
    }
}
