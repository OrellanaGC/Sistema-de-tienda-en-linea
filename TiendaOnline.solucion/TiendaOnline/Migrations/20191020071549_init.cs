using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaOnline.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOMBRE_CATEGORIA = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.ID_CATEGORIA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "CUPON",
                columns: table => new
                {
                    ID_CUPON = table.Column<int>(nullable: false),
                    CODIGO_CUPON = table.Column<string>(type: "text", nullable: true),
                    MONTO_CUPON = table.Column<decimal>(type: "decimal(2, 2)", nullable: true),
                    ESTADO_CUPON = table.Column<bool>(nullable: true),
                    FECHADECREACION = table.Column<DateTime>(type: "datetime", nullable: true),
                    FECHADEVENCIMIENTO = table.Column<DateTime>(type: "datetime", nullable: true),
                    DESCRIPCIONDELCUPON = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUPON", x => x.ID_CUPON)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DETALLEDEPRODUCTO",
                columns: table => new
                {
                    ID_DETALLE = table.Column<int>(nullable: false),
                    ESCRIPCIONDEPRODUCTO = table.Column<string>(type: "text", nullable: false),
                    TALLA = table.Column<string>(type: "text", nullable: true),
                    COLOR = table.Column<string>(type: "text", nullable: true),
                    PESOKG = table.Column<decimal>(type: "decimal(2, 2)", nullable: true),
                    MODELO = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETALLEDEPRODUCTO", x => x.ID_DETALLE)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "ESTADODEORDEN",
                columns: table => new
                {
                    ID_ESTADODEORDEN = table.Column<int>(nullable: false),
                    ESTADO_DEORDEN = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADODEORDEN", x => x.ID_ESTADODEORDEN)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "MUNICIPIO",
                columns: table => new
                {
                    ID_MUNICIPIO = table.Column<int>(nullable: false),
                    NOMBRE_MUNICIPIO = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUNICIPIO", x => x.ID_MUNICIPIO)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PAYPAL",
                columns: table => new
                {
                    ID_PAYPAL = table.Column<int>(nullable: false),
                    CORREO_PAYPAL = table.Column<string>(type: "text", nullable: true),
                    PSSWD_PAYPAL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYPAL", x => x.ID_PAYPAL)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "TIPODEDESCUENTO",
                columns: table => new
                {
                    ID_TIPODEDESCUENTO = table.Column<int>(nullable: false),
                    NOMBREDELDESCUENTO = table.Column<string>(type: "text", nullable: true),
                    MONTODEDESCUENTO = table.Column<decimal>(type: "decimal(2, 2)", nullable: true),
                    PORCENTAJEDEDESCUENTO = table.Column<decimal>(type: "decimal(2, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPODEDESCUENTO", x => x.ID_TIPODEDESCUENTO)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "SUBCATEGORIA",
                columns: table => new
                {
                    ID_SUBCATEGORIA = table.Column<int>(nullable: false),
                    ID_CATEGORIA = table.Column<int>(nullable: false),
                    NOMBRE_SUBCATEGORIA = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBCATEGORIA", x => x.ID_SUBCATEGORIA)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_SUBCATEG_PERTENECE_CATEGORI",
                        column: x => x.ID_CATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID_CATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTAMENTO",
                columns: table => new
                {
                    ID_DEPARTAMENTO = table.Column<int>(nullable: false),
                    ID_MUNICIPIO = table.Column<int>(nullable: false),
                    NOMBRE_DEPARTAMENTO = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTAMENTO", x => x.ID_DEPARTAMENTO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DEPARTAM_TIENE_MUNICIPI",
                        column: x => x.ID_MUNICIPIO,
                        principalTable: "MUNICIPIO",
                        principalColumn: "ID_MUNICIPIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDEN",
                columns: table => new
                {
                    ID_ORDEN = table.Column<int>(nullable: false),
                    ID_ESTADODEORDEN = table.Column<int>(nullable: true),
                    ID_USUARIO = table.Column<int>(nullable: true),
                    ID_CUPON = table.Column<int>(nullable: true),
                    ID_METODODEENVIO = table.Column<int>(nullable: true),
                    FECHADECOMPRA = table.Column<DateTime>(type: "datetime", nullable: true),
                    TOTAL = table.Column<decimal>(type: "decimal(4, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDEN", x => x.ID_ORDEN)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ORDEN_DISMINUID_CUPON",
                        column: x => x.ID_CUPON,
                        principalTable: "CUPON",
                        principalColumn: "ID_CUPON",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDEN_PUEDETENE_ESTADODE",
                        column: x => x.ID_ESTADODEORDEN,
                        principalTable: "ESTADODEORDEN",
                        principalColumn: "ID_ESTADODEORDEN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIRECCION",
                columns: table => new
                {
                    ID_DIRECCION = table.Column<int>(nullable: false),
                    ID_DEPARTAMENTO = table.Column<int>(nullable: false),
                    ID_SUCURSAL = table.Column<int>(nullable: true),
                    CODIGOPOSTAL = table.Column<int>(nullable: true),
                    DIRECCIONDETALLADA = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIRECCION", x => x.ID_DIRECCION)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DIRECCIO_POSEE_DEPARTAM",
                        column: x => x.ID_DEPARTAMENTO,
                        principalTable: "DEPARTAMENTO",
                        principalColumn: "ID_DEPARTAMENTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    ID_PRODUCTO = table.Column<int>(nullable: false),
                    ID_DETALLE = table.Column<int>(nullable: false),
                    ID_TIPODEDESCUENTO = table.Column<int>(nullable: true),
                    ID_SUBCATEGORIA = table.Column<int>(nullable: false),
                    ID_VENDEDOR = table.Column<int>(nullable: true),
                    ID_EMPRESA = table.Column<int>(nullable: true),
                    NOMBRE_PRODUCTO = table.Column<string>(type: "text", nullable: false),
                    PRECIOUNITARIO = table.Column<decimal>(type: "decimal(4, 2)", nullable: false),
                    IMG_PRODUCTO = table.Column<byte[]>(type: "image", nullable: false),
                    EXISTENCIA = table.Column<int>(nullable: false),
                    CODIGODEPRODUCTO = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.ID_PRODUCTO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_DESCRITO_DETALLED",
                        column: x => x.ID_DETALLE,
                        principalTable: "DETALLEDEPRODUCTO",
                        principalColumn: "ID_DETALLE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_ES_SUBCATEG",
                        column: x => x.ID_SUBCATEGORIA,
                        principalTable: "SUBCATEGORIA",
                        principalColumn: "ID_SUBCATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_DESCUENTO_TIPODEDE",
                        column: x => x.ID_TIPODEDESCUENTO,
                        principalTable: "TIPODEDESCUENTO",
                        principalColumn: "ID_TIPODEDESCUENTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LINEADEORDEN",
                columns: table => new
                {
                    ID_LINEADEORDEN = table.Column<int>(nullable: false),
                    ID_ORDEN = table.Column<int>(nullable: true),
                    ID_PRODUCTO = table.Column<int>(nullable: true),
                    CANTIDADDEPRODUCTO = table.Column<int>(nullable: true),
                    SUBTOTAL = table.Column<decimal>(type: "decimal(4, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LINEADEORDEN", x => x.ID_LINEADEORDEN)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_LINEADEO_SECOMPONE_ORDEN",
                        column: x => x.ID_ORDEN,
                        principalTable: "ORDEN",
                        principalColumn: "ID_ORDEN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LINEADEO_TENDRA_PRODUCTO",
                        column: x => x.ID_PRODUCTO,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PRODUCTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REGISTRODEPRODUCTOS",
                columns: table => new
                {
                    ID_REGISTRO = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ID_PRODUCTO = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTRODEPRODUCTOS", x => x.ID_REGISTRO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_REGISTRO_VENDE_PRODUCTO",
                        column: x => x.ID_PRODUCTO,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PRODUCTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    TELEFONO_ATENCIONALCLIENTE = table.Column<int>(nullable: true),
                    CORREO_ATENCIONALCLIENTE = table.Column<string>(type: "text", nullable: true),
                    ID_EMPRESA = table.Column<int>(nullable: false),
                    ID_VENDEDOR = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.ID_EMPRESA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "METODODEENVIO",
                columns: table => new
                {
                    ID_METODODEENVIO = table.Column<int>(nullable: false),
                    ID_EMPRESA = table.Column<int>(nullable: true),
                    NOMBRE_METODODEENVIO = table.Column<string>(type: "text", nullable: true),
                    MAXDEDIASDEENVIO = table.Column<int>(nullable: true),
                    MINDEDIASDEENVIO = table.Column<int>(nullable: true),
                    MONTOPORENVIO = table.Column<decimal>(type: "decimal(2, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_METODODEENVIO", x => x.ID_METODODEENVIO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_METODODE_BRINDA_EMPRESA",
                        column: x => x.ID_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUCURSAL",
                columns: table => new
                {
                    ID_SUCURSAL = table.Column<int>(nullable: false),
                    ID_EMPRESA = table.Column<int>(nullable: true),
                    ID_DIRECCION = table.Column<int>(nullable: true),
                    NOMBRE_SUCURSAL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUCURSAL", x => x.ID_SUCURSAL)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_SUCURSAL_UBICACION_DIRECCIO",
                        column: x => x.ID_DIRECCION,
                        principalTable: "DIRECCION",
                        principalColumn: "ID_DIRECCION",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUCURSAL_SEDISTRIB_EMPRESA",
                        column: x => x.ID_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TARJETA",
                columns: table => new
                {
                    ID_TARJETA = table.Column<int>(nullable: false),
                    ID_VENDEDOR = table.Column<int>(nullable: true),
                    CODIGO_TARJETA = table.Column<int>(nullable: true),
                    FECHADEVENCIMIENTO_TARJETA = table.Column<DateTime>(type: "datetime", nullable: true),
                    TIPODETARJETA = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TARJETA", x => x.ID_TARJETA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "TIPODEPAGO",
                columns: table => new
                {
                    ID_TIPODEPAGO = table.Column<int>(nullable: false),
                    ID_TARJETA = table.Column<int>(nullable: true),
                    ID_PAYPAL = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPODEPAGO", x => x.ID_TIPODEPAGO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_TIPODEPA_SEREALIZA_PAYPAL",
                        column: x => x.ID_PAYPAL,
                        principalTable: "PAYPAL",
                        principalColumn: "ID_PAYPAL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TIPODEPA_COMPRACON_TARJETA",
                        column: x => x.ID_TARJETA,
                        principalTable: "TARJETA",
                        principalColumn: "ID_TARJETA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIPODEVENDEDOR",
                columns: table => new
                {
                    ID_TIPODEVENDEDOR = table.Column<int>(nullable: false),
                    ID_USUARIO = table.Column<int>(nullable: true),
                    ID_VENDEDOR = table.Column<int>(nullable: true),
                    TIPODEVENDEDOR = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPODEVENDEDOR", x => x.ID_TIPODEVENDEDOR)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(nullable: false),
                    ID_TIPODEPAGO = table.Column<int>(nullable: true),
                    ID_DIRECCION = table.Column<int>(nullable: true),
                    ID_ROL = table.Column<int>(nullable: false),
                    ID_VENDEDOR = table.Column<int>(nullable: true),
                    ID_TIPODEVENDEDOR = table.Column<int>(nullable: true),
                    NOMBRE_USUARIO = table.Column<string>(type: "text", nullable: true),
                    APELLIDO_USUARIO = table.Column<string>(type: "text", nullable: true),
                    TELEFONO_USUARIO = table.Column<int>(nullable: true),
                    CORREO_USUARIO = table.Column<string>(type: "text", nullable: true),
                    PSSWD_USUARIO = table.Column<string>(type: "text", nullable: true),
                    NAMEUSER = table.Column<string>(type: "text", nullable: true),
                    FECHADENACIMIENTO = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID_USUARIO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_USUARIO_VIVE_DIRECCIO",
                        column: x => x.ID_DIRECCION,
                        principalTable: "DIRECCION",
                        principalColumn: "ID_DIRECCION",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_REALIZAPA_TIPODEPA",
                        column: x => x.ID_TIPODEPAGO,
                        principalTable: "TIPODEPAGO",
                        principalColumn: "ID_TIPODEPAGO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_PUEDE_SER_TIPODEVE",
                        column: x => x.ID_TIPODEVENDEDOR,
                        principalTable: "TIPODEVENDEDOR",
                        principalColumn: "ID_TIPODEVENDEDOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DETALLEDEVENDEDOR",
                columns: table => new
                {
                    ID_VENDEDOR = table.Column<int>(nullable: false),
                    ID_USUARIO = table.Column<int>(nullable: true),
                    ID_REGISTRO = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    ID_TARJETA = table.Column<int>(nullable: true),
                    ID_DIRECCION = table.Column<int>(nullable: true),
                    TAR_ID_TARJETA = table.Column<int>(nullable: true),
                    ID_EMPRESA = table.Column<int>(nullable: true),
                    DIR_ID_DIRECCION = table.Column<int>(nullable: true),
                    NOMBRECOMERCIAL = table.Column<string>(type: "text", nullable: true),
                    CORREOCOMERCIAL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETALLEDEVENDEDOR", x => x.ID_VENDEDOR)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_DETALLED_DIRECCION_DIRECCIO",
                        column: x => x.DIR_ID_DIRECCION,
                        principalTable: "DIRECCION",
                        principalColumn: "ID_DIRECCION",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETALLED_UBICACION_DIRECCIO",
                        column: x => x.ID_DIRECCION,
                        principalTable: "DIRECCION",
                        principalColumn: "ID_DIRECCION",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETALLED_POSEEDATO_EMPRESA",
                        column: x => x.ID_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETALLED_REGISTRA_REGISTRO",
                        column: x => x.ID_REGISTRO,
                        principalTable: "REGISTRODEPRODUCTOS",
                        principalColumn: "ID_REGISTRO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETALLED_PAGOYGANA_TARJETA",
                        column: x => x.ID_TARJETA,
                        principalTable: "TARJETA",
                        principalColumn: "ID_TARJETA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETALLED_PUEDEREPR_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETALLED_TARJETACO_TARJETA",
                        column: x => x.TAR_ID_TARJETA,
                        principalTable: "TARJETA",
                        principalColumn: "ID_TARJETA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROL",
                columns: table => new
                {
                    ID_ROL = table.Column<int>(nullable: false),
                    ID_USUARIO = table.Column<int>(nullable: false),
                    NOMBRE_ROL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROL", x => x.ID_ROL)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ROL_ESELUSUAR_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "TIENE_FK",
                table: "DEPARTAMENTO",
                column: "ID_MUNICIPIO");

            migrationBuilder.CreateIndex(
                name: "DIRECCIONDELVENDEDOR_FK",
                table: "DETALLEDEVENDEDOR",
                column: "DIR_ID_DIRECCION");

            migrationBuilder.CreateIndex(
                name: "UBICACIONDELNEGOCIO_FK",
                table: "DETALLEDEVENDEDOR",
                column: "ID_DIRECCION");

            migrationBuilder.CreateIndex(
                name: "POSEEDATOSDE2_FK",
                table: "DETALLEDEVENDEDOR",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "REGISTRA_FK",
                table: "DETALLEDEVENDEDOR",
                column: "ID_REGISTRO");

            migrationBuilder.CreateIndex(
                name: "PAGOYGANANCIASPOR_FK",
                table: "DETALLEDEVENDEDOR",
                column: "ID_TARJETA");

            migrationBuilder.CreateIndex(
                name: "PUEDEREPRESENTAR_FK",
                table: "DETALLEDEVENDEDOR",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "TARJETACOMERCIAL_FK",
                table: "DETALLEDEVENDEDOR",
                column: "TAR_ID_TARJETA");

            migrationBuilder.CreateIndex(
                name: "POSEE_FK",
                table: "DIRECCION",
                column: "ID_DEPARTAMENTO");

            migrationBuilder.CreateIndex(
                name: "UBICACIONDE_SUCURSAL_FK",
                table: "DIRECCION",
                column: "ID_SUCURSAL");

            migrationBuilder.CreateIndex(
                name: "POSEEDATOSDE_FK",
                table: "EMPRESA",
                column: "ID_VENDEDOR");

            migrationBuilder.CreateIndex(
                name: "SECOMPONEPOR_FK",
                table: "LINEADEORDEN",
                column: "ID_ORDEN");

            migrationBuilder.CreateIndex(
                name: "TENDRA_FK",
                table: "LINEADEORDEN",
                column: "ID_PRODUCTO");

            migrationBuilder.CreateIndex(
                name: "BRINDA_FK",
                table: "METODODEENVIO",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "DISMINUIDAPOR_FK",
                table: "ORDEN",
                column: "ID_CUPON");

            migrationBuilder.CreateIndex(
                name: "PUEDETENER_FK",
                table: "ORDEN",
                column: "ID_ESTADODEORDEN");

            migrationBuilder.CreateIndex(
                name: "ENVIOS_FK",
                table: "ORDEN",
                column: "ID_METODODEENVIO");

            migrationBuilder.CreateIndex(
                name: "SOLICITA_FK",
                table: "ORDEN",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "DESCRITO_FK",
                table: "PRODUCTO",
                column: "ID_DETALLE");

            migrationBuilder.CreateIndex(
                name: "HACEPUBLICIDAD_FK",
                table: "PRODUCTO",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "ES_FK",
                table: "PRODUCTO",
                column: "ID_SUBCATEGORIA");

            migrationBuilder.CreateIndex(
                name: "DESCUENTO_FK",
                table: "PRODUCTO",
                column: "ID_TIPODEDESCUENTO");

            migrationBuilder.CreateIndex(
                name: "VENDIDOPOR_FK",
                table: "PRODUCTO",
                column: "ID_VENDEDOR");

            migrationBuilder.CreateIndex(
                name: "VENDE_FK",
                table: "REGISTRODEPRODUCTOS",
                column: "ID_PRODUCTO");

            migrationBuilder.CreateIndex(
                name: "PUEDESER2_FK",
                table: "ROL",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "PERTENECE_FK",
                table: "SUBCATEGORIA",
                column: "ID_CATEGORIA");

            migrationBuilder.CreateIndex(
                name: "UBICACIONDE_SUCURSAL2_FK",
                table: "SUCURSAL",
                column: "ID_DIRECCION");

            migrationBuilder.CreateIndex(
                name: "SEDISTRIBUYE_FK",
                table: "SUCURSAL",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "TARJETACOMERCIAL2_FK",
                table: "TARJETA",
                column: "ID_VENDEDOR");

            migrationBuilder.CreateIndex(
                name: "SEREALIZACON_FK",
                table: "TIPODEPAGO",
                column: "ID_PAYPAL");

            migrationBuilder.CreateIndex(
                name: "COMPRACON_FK",
                table: "TIPODEPAGO",
                column: "ID_TARJETA");

            migrationBuilder.CreateIndex(
                name: "PUEDE_SER2_FK",
                table: "TIPODEVENDEDOR",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "SEDETALLA_FK",
                table: "TIPODEVENDEDOR",
                column: "ID_VENDEDOR");

            migrationBuilder.CreateIndex(
                name: "VIVE_FK",
                table: "USUARIO",
                column: "ID_DIRECCION");

            migrationBuilder.CreateIndex(
                name: "PUEDESER_FK",
                table: "USUARIO",
                column: "ID_ROL");

            migrationBuilder.CreateIndex(
                name: "REALIZAPAGO_FK",
                table: "USUARIO",
                column: "ID_TIPODEPAGO");

            migrationBuilder.CreateIndex(
                name: "PUEDE_SER_FK",
                table: "USUARIO",
                column: "ID_TIPODEVENDEDOR");

            migrationBuilder.CreateIndex(
                name: "PUEDEREPRESENTAR2_FK",
                table: "USUARIO",
                column: "ID_VENDEDOR");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDEN_SOLICITA_USUARIO",
                table: "ORDEN",
                column: "ID_USUARIO",
                principalTable: "USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDEN_ENVIOS_METODODE",
                table: "ORDEN",
                column: "ID_METODODEENVIO",
                principalTable: "METODODEENVIO",
                principalColumn: "ID_METODODEENVIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DIRECCIO_UBICACION_SUCURSAL",
                table: "DIRECCION",
                column: "ID_SUCURSAL",
                principalTable: "SUCURSAL",
                principalColumn: "ID_SUCURSAL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTO_HACEPUBLI_EMPRESA",
                table: "PRODUCTO",
                column: "ID_EMPRESA",
                principalTable: "EMPRESA",
                principalColumn: "ID_EMPRESA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTO_VENDIDOPO_DETALLED",
                table: "PRODUCTO",
                column: "ID_VENDEDOR",
                principalTable: "DETALLEDEVENDEDOR",
                principalColumn: "ID_VENDEDOR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPRESA_POSEEDATO_DETALLED",
                table: "EMPRESA",
                column: "ID_VENDEDOR",
                principalTable: "DETALLEDEVENDEDOR",
                principalColumn: "ID_VENDEDOR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TARJETA_TARJETACO_DETALLED",
                table: "TARJETA",
                column: "ID_VENDEDOR",
                principalTable: "DETALLEDEVENDEDOR",
                principalColumn: "ID_VENDEDOR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TIPODEVE_PUEDE_SER_USUARIO",
                table: "TIPODEVENDEDOR",
                column: "ID_USUARIO",
                principalTable: "USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TIPODEVE_SEDETALLA_DETALLED",
                table: "TIPODEVENDEDOR",
                column: "ID_VENDEDOR",
                principalTable: "DETALLEDEVENDEDOR",
                principalColumn: "ID_VENDEDOR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIO_PUEDEREPR_DETALLED",
                table: "USUARIO",
                column: "ID_VENDEDOR",
                principalTable: "DETALLEDEVENDEDOR",
                principalColumn: "ID_VENDEDOR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIO_PUEDESER_ROL",
                table: "USUARIO",
                column: "ID_ROL",
                principalTable: "ROL",
                principalColumn: "ID_ROL",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DEPARTAM_TIENE_MUNICIPI",
                table: "DEPARTAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_DETALLED_DIRECCION_DIRECCIO",
                table: "DETALLEDEVENDEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_DETALLED_UBICACION_DIRECCIO",
                table: "DETALLEDEVENDEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_SUCURSAL_UBICACION_DIRECCIO",
                table: "SUCURSAL");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_VIVE_DIRECCIO",
                table: "USUARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_DETALLED_POSEEDATO_EMPRESA",
                table: "DETALLEDEVENDEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTO_HACEPUBLI_EMPRESA",
                table: "PRODUCTO");

            migrationBuilder.DropForeignKey(
                name: "FK_DETALLED_REGISTRA_REGISTRO",
                table: "DETALLEDEVENDEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_DETALLED_PAGOYGANA_TARJETA",
                table: "DETALLEDEVENDEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_DETALLED_TARJETACO_TARJETA",
                table: "DETALLEDEVENDEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_TIPODEPA_COMPRACON_TARJETA",
                table: "TIPODEPAGO");

            migrationBuilder.DropForeignKey(
                name: "FK_DETALLED_PUEDEREPR_USUARIO",
                table: "DETALLEDEVENDEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_ROL_ESELUSUAR_USUARIO",
                table: "ROL");

            migrationBuilder.DropForeignKey(
                name: "FK_TIPODEVE_PUEDE_SER_USUARIO",
                table: "TIPODEVENDEDOR");

            migrationBuilder.DropTable(
                name: "LINEADEORDEN");

            migrationBuilder.DropTable(
                name: "ORDEN");

            migrationBuilder.DropTable(
                name: "CUPON");

            migrationBuilder.DropTable(
                name: "ESTADODEORDEN");

            migrationBuilder.DropTable(
                name: "METODODEENVIO");

            migrationBuilder.DropTable(
                name: "MUNICIPIO");

            migrationBuilder.DropTable(
                name: "DIRECCION");

            migrationBuilder.DropTable(
                name: "DEPARTAMENTO");

            migrationBuilder.DropTable(
                name: "SUCURSAL");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "REGISTRODEPRODUCTOS");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "DETALLEDEPRODUCTO");

            migrationBuilder.DropTable(
                name: "SUBCATEGORIA");

            migrationBuilder.DropTable(
                name: "TIPODEDESCUENTO");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "TARJETA");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "ROL");

            migrationBuilder.DropTable(
                name: "TIPODEPAGO");

            migrationBuilder.DropTable(
                name: "TIPODEVENDEDOR");

            migrationBuilder.DropTable(
                name: "PAYPAL");

            migrationBuilder.DropTable(
                name: "DETALLEDEVENDEDOR");
        }
    }
}
