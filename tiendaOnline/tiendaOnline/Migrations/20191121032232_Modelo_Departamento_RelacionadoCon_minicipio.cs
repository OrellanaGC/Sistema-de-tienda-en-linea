using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class Modelo_Departamento_RelacionadoCon_minicipio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "Municipio",
                newName: "DepartamentoID");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreDepartamento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_DepartamentoID",
                table: "Municipio",
                column: "DepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Departamento_DepartamentoID",
                table: "Municipio",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Departamento_DepartamentoID",
                table: "Municipio");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Municipio_DepartamentoID",
                table: "Municipio");

            migrationBuilder.RenameColumn(
                name: "DepartamentoID",
                table: "Municipio",
                newName: "Departamento");
        }
    }
}
