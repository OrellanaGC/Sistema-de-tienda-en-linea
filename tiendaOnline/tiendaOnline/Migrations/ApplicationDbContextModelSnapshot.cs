﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tiendaOnline.Data;

namespace tiendaOnline.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("apellidos");

                    b.Property<DateTime>("fecheDeNacimiento");

                    b.Property<string>("nombres");

                    b.Property<int>("sexo");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("tiendaOnline.Models.Carrito", b =>
                {
                    b.Property<int>("CarritoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tiendaOnlineUserID");

                    b.HasKey("CarritoID");

                    b.HasIndex("tiendaOnlineUserID")
                        .IsUnique()
                        .HasFilter("[tiendaOnlineUserID] IS NOT NULL");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("tiendaOnline.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre_categoria")
                        .IsRequired();

                    b.Property<int>("stockMax");

                    b.Property<int>("stockMin");

                    b.HasKey("CategoriaID");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("tiendaOnline.Models.Cupon", b =>
                {
                    b.Property<int>("CuponID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("codigoCupon")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<string>("descripcionCupon")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("estadoCupon");

                    b.Property<DateTime>("fechaCreacion");

                    b.Property<DateTime>("fechaVencimiento");

                    b.Property<double>("montoCupon");

                    b.Property<string>("tiendaOnlineUserID");

                    b.HasKey("CuponID");

                    b.HasIndex("tiendaOnlineUserID");

                    b.ToTable("Cupon");
                });

            modelBuilder.Entity("tiendaOnline.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombreDepartamento")
                        .IsRequired();

                    b.HasKey("DepartamentoID");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("tiendaOnline.Models.DetalleProducto", b =>
                {
                    b.Property<int>("DetalleProductoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasMaxLength(20);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Marca")
                        .HasMaxLength(20);

                    b.Property<string>("Modelo")
                        .HasMaxLength(20);

                    b.Property<double>("PesoKg");

                    b.Property<string>("Talla")
                        .HasMaxLength(10);

                    b.Property<int>("productoID");

                    b.HasKey("DetalleProductoID");

                    b.HasIndex("productoID")
                        .IsUnique();

                    b.ToTable("DetalleProducto");
                });

            modelBuilder.Entity("tiendaOnline.Models.DetalleVendedor", b =>
                {
                    b.Property<int>("DetalleVendedorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("correoComercial")
                        .IsRequired();

                    b.Property<string>("nombreComercial")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("tiendaOnlineUserID");

                    b.Property<int>("tipoVendedor");

                    b.HasKey("DetalleVendedorID");

                    b.HasIndex("tiendaOnlineUserID")
                        .IsUnique()
                        .HasFilter("[tiendaOnlineUserID] IS NOT NULL");

                    b.ToTable("DetalleVendedor");
                });

            modelBuilder.Entity("tiendaOnline.Models.Direccion", b =>
                {
                    b.Property<int>("DireccionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MunicipioID");

                    b.Property<string>("SucursalID");

                    b.Property<int?>("SucursalID1");

                    b.Property<int>("codigoPostal");

                    b.Property<int?>("detalleVendedorID");

                    b.Property<string>("direccionDetallada")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("tiendaOnlineUserID");

                    b.HasKey("DireccionID");

                    b.HasIndex("MunicipioID");

                    b.HasIndex("SucursalID1");

                    b.HasIndex("detalleVendedorID");

                    b.HasIndex("tiendaOnlineUserID");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("tiendaOnline.Models.LineaDeOrden", b =>
                {
                    b.Property<int>("LineaDeOrdenID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ordenID");

                    b.Property<int>("productoCarritoID");

                    b.Property<double>("subtotal");

                    b.HasKey("LineaDeOrdenID");

                    b.HasIndex("ordenID");

                    b.HasIndex("productoCarritoID")
                        .IsUnique();

                    b.ToTable("LineaDeOrden");
                });

            modelBuilder.Entity("tiendaOnline.Models.MetodoEnvio", b =>
                {
                    b.Property<int>("MetodoEnvioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("maxDiasEnvio");

                    b.Property<int>("minDiasEnvio");

                    b.Property<double>("montoEnvio");

                    b.Property<string>("nombreMetodoEnvio")
                        .IsRequired();

                    b.HasKey("MetodoEnvioID");

                    b.ToTable("MetodoEnvio");
                });

            modelBuilder.Entity("tiendaOnline.Models.Municipio", b =>
                {
                    b.Property<int>("MunicipioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartamentoID");

                    b.Property<string>("nombreMunicipio")
                        .IsRequired();

                    b.HasKey("MunicipioID");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Municipio");
                });

            modelBuilder.Entity("tiendaOnline.Models.Orden", b =>
                {
                    b.Property<int>("OrdenID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("cuponID");

                    b.Property<bool>("estadoDeOrden");

                    b.Property<DateTime>("fechaOrden");

                    b.Property<int>("metodoEnvioID");

                    b.Property<string>("tiendaOnlineUserID");

                    b.Property<double>("total");

                    b.HasKey("OrdenID");

                    b.HasIndex("cuponID");

                    b.HasIndex("metodoEnvioID");

                    b.HasIndex("tiendaOnlineUserID");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("tiendaOnline.Models.Paypal", b =>
                {
                    b.Property<int>("PaypalID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("correoPaypal")
                        .IsRequired();

                    b.Property<string>("psswrdPaypal")
                        .IsRequired();

                    b.Property<string>("tiendaOnlineUserID");

                    b.HasKey("PaypalID");

                    b.HasIndex("tiendaOnlineUserID");

                    b.ToTable("Paypal");
                });

            modelBuilder.Entity("tiendaOnline.Models.ProdCarrito", b =>
                {
                    b.Property<int>("ProdCarritoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarritoID");

                    b.Property<bool>("IsSelected");

                    b.Property<int>("cantidadProducto");

                    b.Property<int?>("productoID");

                    b.HasKey("ProdCarritoID");

                    b.HasIndex("CarritoID");

                    b.HasIndex("productoID");

                    b.ToTable("ProdCarrito");
                });

            modelBuilder.Entity("tiendaOnline.Models.Producto", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Existencia");

                    b.Property<string>("Imagen")
                        .IsRequired();

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("PrecioUnitario");

                    b.Property<int>("SubcategoriaID");

                    b.Property<int?>("detalleVendedorID");

                    b.HasKey("ProductoID");

                    b.HasIndex("SubcategoriaID");

                    b.HasIndex("detalleVendedorID");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("tiendaOnline.Models.Subcategoria", b =>
                {
                    b.Property<int>("SubcategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaID");

                    b.Property<string>("nombreSubcategoria")
                        .IsRequired();

                    b.HasKey("SubcategoriaID");

                    b.HasIndex("CategoriaID");

                    b.ToTable("Subcategoria");
                });

            modelBuilder.Entity("tiendaOnline.Models.Sucursal", b =>
                {
                    b.Property<int>("SucursalID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("SucursalID");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("tiendaOnline.Models.Tarjeta", b =>
                {
                    b.Property<int>("TarjetaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("codigoSeguridad");

                    b.Property<int?>("detalleVendedorID");

                    b.Property<DateTime>("fechaVencimiento");

                    b.Property<int>("numeroTarjeta");

                    b.Property<string>("tiendaOnlineUserID");

                    b.Property<int>("tipoTarjeta");

                    b.Property<string>("titularTarjeta")
                        .IsRequired();

                    b.HasKey("TarjetaID");

                    b.HasIndex("detalleVendedorID");

                    b.HasIndex("tiendaOnlineUserID");

                    b.ToTable("Tarjeta");
                });

            modelBuilder.Entity("tiendaOnline.Models.TipoDeDescuento", b =>
                {
                    b.Property<int>("TipoDeDescuentoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductoID");

                    b.Property<int>("montoDeDescuento");

                    b.Property<string>("nombreDelDescuento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("porcentajeDeDescuento");

                    b.HasKey("TipoDeDescuentoID");

                    b.HasIndex("ProductoID")
                        .IsUnique();

                    b.ToTable("TipoDeDescuento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tiendaOnline.Models.Carrito", b =>
                {
                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithOne("Carrito")
                        .HasForeignKey("tiendaOnline.Models.Carrito", "tiendaOnlineUserID");
                });

            modelBuilder.Entity("tiendaOnline.Models.Cupon", b =>
                {
                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("tiendaOnlineUserID");
                });

            modelBuilder.Entity("tiendaOnline.Models.DetalleProducto", b =>
                {
                    b.HasOne("tiendaOnline.Models.Producto", "producto")
                        .WithOne("DetalleProducto")
                        .HasForeignKey("tiendaOnline.Models.DetalleProducto", "productoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tiendaOnline.Models.DetalleVendedor", b =>
                {
                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithOne("detalleVendedor")
                        .HasForeignKey("tiendaOnline.Models.DetalleVendedor", "tiendaOnlineUserID");
                });

            modelBuilder.Entity("tiendaOnline.Models.Direccion", b =>
                {
                    b.HasOne("tiendaOnline.Models.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tiendaOnline.Models.Sucursal", "Sucursal")
                        .WithMany()
                        .HasForeignKey("SucursalID1");

                    b.HasOne("tiendaOnline.Models.DetalleVendedor", "detalleVendedor")
                        .WithMany()
                        .HasForeignKey("detalleVendedorID");

                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("tiendaOnlineUserID");
                });

            modelBuilder.Entity("tiendaOnline.Models.LineaDeOrden", b =>
                {
                    b.HasOne("tiendaOnline.Models.Orden", "orden")
                        .WithMany()
                        .HasForeignKey("ordenID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tiendaOnline.Models.ProdCarrito", "productoCarrito")
                        .WithOne("lineaOrden")
                        .HasForeignKey("tiendaOnline.Models.LineaDeOrden", "productoCarritoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tiendaOnline.Models.Municipio", b =>
                {
                    b.HasOne("tiendaOnline.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tiendaOnline.Models.Orden", b =>
                {
                    b.HasOne("tiendaOnline.Models.Cupon", "cupon")
                        .WithMany()
                        .HasForeignKey("cuponID");

                    b.HasOne("tiendaOnline.Models.MetodoEnvio", "metodoEnvio")
                        .WithMany()
                        .HasForeignKey("metodoEnvioID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("tiendaOnlineUserID");
                });

            modelBuilder.Entity("tiendaOnline.Models.Paypal", b =>
                {
                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("tiendaOnlineUserID");
                });

            modelBuilder.Entity("tiendaOnline.Models.ProdCarrito", b =>
                {
                    b.HasOne("tiendaOnline.Models.Carrito")
                        .WithMany("prodCarrito")
                        .HasForeignKey("CarritoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tiendaOnline.Models.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoID");
                });

            modelBuilder.Entity("tiendaOnline.Models.Producto", b =>
                {
                    b.HasOne("tiendaOnline.Models.Subcategoria", "Subcategoria")
                        .WithMany()
                        .HasForeignKey("SubcategoriaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tiendaOnline.Models.DetalleVendedor", "detalleVendedor")
                        .WithMany("productos")
                        .HasForeignKey("detalleVendedorID");
                });

            modelBuilder.Entity("tiendaOnline.Models.Subcategoria", b =>
                {
                    b.HasOne("tiendaOnline.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tiendaOnline.Models.Tarjeta", b =>
                {
                    b.HasOne("tiendaOnline.Models.DetalleVendedor", "detalleVendedor")
                        .WithMany()
                        .HasForeignKey("detalleVendedorID");

                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("tiendaOnlineUserID");
                });

            modelBuilder.Entity("tiendaOnline.Models.TipoDeDescuento", b =>
                {
                    b.HasOne("tiendaOnline.Models.Producto", "producto")
                        .WithOne("TipoDeDescuento")
                        .HasForeignKey("tiendaOnline.Models.TipoDeDescuento", "ProductoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
