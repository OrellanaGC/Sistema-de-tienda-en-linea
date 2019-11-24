using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tiendaOnline.Migrations
{
    public partial class version : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    nombres = table.Column<string>(nullable: true),
                    apellidos = table.Column<string>(nullable: true),
                    fecheDeNacimiento = table.Column<DateTime>(nullable: false),
                    sexo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_categoria = table.Column<string>(nullable: false),
                    stockMax = table.Column<int>(nullable: false),
                    stockMin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaID);
                });

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

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreEmpresa = table.Column<string>(nullable: true),
                    correoComercial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaID);
                });

            migrationBuilder.CreateTable(
                name: "MetodoEnvio",
                columns: table => new
                {
                    MetodoEnvioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreMetodoEnvio = table.Column<string>(nullable: false),
                    maxDiasEnvio = table.Column<int>(nullable: false),
                    minDiasEnvio = table.Column<int>(nullable: false),
                    montoEnvio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoEnvio", x => x.MetodoEnvioID);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    SucursalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreSucursal = table.Column<string>(nullable: true),
                    horarioDeAtencion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.SucursalID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tiendaOnlineUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoID);
                    table.ForeignKey(
                        name: "FK_Carrito_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cupon",
                columns: table => new
                {
                    CuponID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigoCupon = table.Column<string>(nullable: true),
                    montoCupon = table.Column<double>(nullable: false),
                    estadoCupon = table.Column<bool>(nullable: false),
                    fechaCreacion = table.Column<DateTime>(nullable: false),
                    fechaVencimiento = table.Column<DateTime>(nullable: false),
                    descripcionCupon = table.Column<string>(nullable: true),
                    tiendaOnlineUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupon", x => x.CuponID);
                    table.ForeignKey(
                        name: "FK_Cupon_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVendedor",
                columns: table => new
                {
                    DetalleVendedorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreComercial = table.Column<string>(maxLength: 30, nullable: false),
                    correoComercial = table.Column<string>(nullable: false),
                    tipoVendedor = table.Column<int>(nullable: false),
                    tiendaOnlineUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVendedor", x => x.DetalleVendedorID);
                    table.ForeignKey(
                        name: "FK_DetalleVendedor_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paypal",
                columns: table => new
                {
                    PaypalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    correoPaypal = table.Column<string>(nullable: false),
                    psswrdPaypal = table.Column<string>(nullable: false),
                    tiendaOnlineUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paypal", x => x.PaypalID);
                    table.ForeignKey(
                        name: "FK_Paypal_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subcategoria",
                columns: table => new
                {
                    SubcategoriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreSubcategoria = table.Column<string>(nullable: false),
                    CategoriaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategoria", x => x.SubcategoriaID);
                    table.ForeignKey(
                        name: "FK_Subcategoria_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    MunicipioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreMunicipio = table.Column<string>(nullable: false),
                    DepartamentoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.MunicipioID);
                    table.ForeignKey(
                        name: "FK_Municipio_Departamento_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fechaOrden = table.Column<DateTime>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    estadoDeOrden = table.Column<bool>(nullable: false),
                    tiendaOnlineUserID = table.Column<string>(nullable: true),
                    metodoEnvioID = table.Column<int>(nullable: false),
                    cuponID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenID);
                    table.ForeignKey(
                        name: "FK_Orden_Cupon_cuponID",
                        column: x => x.cuponID,
                        principalTable: "Cupon",
                        principalColumn: "CuponID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_MetodoEnvio_metodoEnvioID",
                        column: x => x.metodoEnvioID,
                        principalTable: "MetodoEnvio",
                        principalColumn: "MetodoEnvioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    TarjetaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numeroTarjeta = table.Column<int>(nullable: false),
                    codigoSeguridad = table.Column<int>(nullable: false),
                    tipoTarjeta = table.Column<int>(nullable: false),
                    titularTarjeta = table.Column<string>(nullable: false),
                    fechaVencimiento = table.Column<DateTime>(nullable: false),
                    tiendaOnlineUserID = table.Column<string>(nullable: true),
                    detalleVendedorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.TarjetaID);
                    table.ForeignKey(
                        name: "FK_Tarjeta_DetalleVendedor_detalleVendedorID",
                        column: x => x.detalleVendedorID,
                        principalTable: "DetalleVendedor",
                        principalColumn: "DetalleVendedorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarjeta_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreProducto = table.Column<string>(maxLength: 50, nullable: false),
                    PrecioUnitario = table.Column<double>(nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Imagen = table.Column<string>(nullable: false),
                    SubcategoriaID = table.Column<int>(nullable: false),
                    detalleVendedorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Producto_Subcategoria_SubcategoriaID",
                        column: x => x.SubcategoriaID,
                        principalTable: "Subcategoria",
                        principalColumn: "SubcategoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_DetalleVendedor_detalleVendedorID",
                        column: x => x.detalleVendedorID,
                        principalTable: "DetalleVendedor",
                        principalColumn: "DetalleVendedorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    DireccionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    direccionDetallada = table.Column<string>(maxLength: 50, nullable: false),
                    codigoPostal = table.Column<int>(nullable: false),
                    MunicipioID = table.Column<int>(nullable: false),
                    tiendaOnlineUserID = table.Column<string>(nullable: true),
                    detalleVendedorID = table.Column<int>(nullable: true),
                    sucursalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.DireccionID);
                    table.ForeignKey(
                        name: "FK_Direccion_Municipio_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipio",
                        principalColumn: "MunicipioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Direccion_DetalleVendedor_detalleVendedorID",
                        column: x => x.detalleVendedorID,
                        principalTable: "DetalleVendedor",
                        principalColumn: "DetalleVendedorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Direccion_Sucursal_sucursalID",
                        column: x => x.sucursalID,
                        principalTable: "Sucursal",
                        principalColumn: "SucursalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Direccion_AspNetUsers_tiendaOnlineUserID",
                        column: x => x.tiendaOnlineUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleProducto",
                columns: table => new
                {
                    DetalleProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: false),
                    Talla = table.Column<string>(maxLength: 10, nullable: true),
                    Color = table.Column<string>(maxLength: 20, nullable: true),
                    PesoKg = table.Column<double>(nullable: false),
                    Marca = table.Column<string>(maxLength: 20, nullable: true),
                    Modelo = table.Column<string>(maxLength: 20, nullable: true),
                    productoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProducto", x => x.DetalleProductoID);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Producto_productoID",
                        column: x => x.productoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineaDeOrden",
                columns: table => new
                {
                    LineaDeOrdenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    subtotal = table.Column<double>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ProductoID = table.Column<int>(nullable: true),
                    OrdenID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaDeOrden", x => x.LineaDeOrdenID);
                    table.ForeignKey(
                        name: "FK_LineaDeOrden_Orden_OrdenID",
                        column: x => x.OrdenID,
                        principalTable: "Orden",
                        principalColumn: "OrdenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaDeOrden_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdCarrito",
                columns: table => new
                {
                    ProdCarritoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cantidadProducto = table.Column<int>(nullable: false),
                    IsSelected = table.Column<bool>(nullable: false),
                    CarritoID = table.Column<int>(nullable: false),
                    productoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCarrito", x => x.ProdCarritoID);
                    table.ForeignKey(
                        name: "FK_ProdCarrito_Carrito_CarritoID",
                        column: x => x.CarritoID,
                        principalTable: "Carrito",
                        principalColumn: "CarritoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdCarrito_Producto_productoID",
                        column: x => x.productoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeDescuento",
                columns: table => new
                {
                    TipoDeDescuentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombreDelDescuento = table.Column<string>(maxLength: 20, nullable: false),
                    montoDeDescuento = table.Column<int>(nullable: false),
                    porcentajeDeDescuento = table.Column<int>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeDescuento", x => x.TipoDeDescuentoID);
                    table.ForeignKey(
                        name: "FK_TipoDeDescuento_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_tiendaOnlineUserID",
                table: "Carrito",
                column: "tiendaOnlineUserID",
                unique: true,
                filter: "[tiendaOnlineUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cupon_tiendaOnlineUserID",
                table: "Cupon",
                column: "tiendaOnlineUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_productoID",
                table: "DetalleProducto",
                column: "productoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVendedor_tiendaOnlineUserID",
                table: "DetalleVendedor",
                column: "tiendaOnlineUserID",
                unique: true,
                filter: "[tiendaOnlineUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_MunicipioID",
                table: "Direccion",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_detalleVendedorID",
                table: "Direccion",
                column: "detalleVendedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_sucursalID",
                table: "Direccion",
                column: "sucursalID");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_tiendaOnlineUserID",
                table: "Direccion",
                column: "tiendaOnlineUserID");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeOrden_OrdenID",
                table: "LineaDeOrden",
                column: "OrdenID");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeOrden_ProductoID",
                table: "LineaDeOrden",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_DepartamentoID",
                table: "Municipio",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_cuponID",
                table: "Orden",
                column: "cuponID");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_metodoEnvioID",
                table: "Orden",
                column: "metodoEnvioID");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_tiendaOnlineUserID",
                table: "Orden",
                column: "tiendaOnlineUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Paypal_tiendaOnlineUserID",
                table: "Paypal",
                column: "tiendaOnlineUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCarrito_CarritoID",
                table: "ProdCarrito",
                column: "CarritoID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCarrito_productoID",
                table: "ProdCarrito",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_SubcategoriaID",
                table: "Producto",
                column: "SubcategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_detalleVendedorID",
                table: "Producto",
                column: "detalleVendedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategoria_CategoriaID",
                table: "Subcategoria",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_detalleVendedorID",
                table: "Tarjeta",
                column: "detalleVendedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_tiendaOnlineUserID",
                table: "Tarjeta",
                column: "tiendaOnlineUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeDescuento_ProductoID",
                table: "TipoDeDescuento",
                column: "ProductoID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetalleProducto");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "LineaDeOrden");

            migrationBuilder.DropTable(
                name: "Paypal");

            migrationBuilder.DropTable(
                name: "ProdCarrito");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "TipoDeDescuento");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Cupon");

            migrationBuilder.DropTable(
                name: "MetodoEnvio");

            migrationBuilder.DropTable(
                name: "Subcategoria");

            migrationBuilder.DropTable(
                name: "DetalleVendedor");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
