using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class arreglandoModelos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Departamento_DepartamentoID",
                table: "Municipio");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_DetalleVendedor_detalleVendedorID",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Municipio_DepartamentoID",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Municipio");

            migrationBuilder.AlterColumn<string>(
                name: "nombreSubcategoria",
                table: "Subcategoria",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "detalleVendedorID",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Departamento",
                table: "Municipio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "DetalleProducto",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "DetalleProducto",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "DetalleProducto",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_DetalleVendedor_detalleVendedorID",
                table: "Producto",
                column: "detalleVendedorID",
                principalTable: "DetalleVendedor",
                principalColumn: "DetalleVendedorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_DetalleVendedor_detalleVendedorID",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "DetalleProducto");

            migrationBuilder.AlterColumn<string>(
                name: "nombreSubcategoria",
                table: "Subcategoria",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "detalleVendedorID",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Municipio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "DetalleProducto",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "DetalleProducto",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_DetalleVendedor_detalleVendedorID",
                table: "Producto",
                column: "detalleVendedorID",
                principalTable: "DetalleVendedor",
                principalColumn: "DetalleVendedorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
