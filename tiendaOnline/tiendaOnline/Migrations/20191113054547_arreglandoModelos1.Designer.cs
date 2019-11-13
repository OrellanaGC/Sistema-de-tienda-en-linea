﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tiendaOnline.Data;

namespace tiendaOnline.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191113054547_arreglandoModelos1")]
    partial class arreglandoModelos1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("prodCarritoID");

                    b.Property<string>("tiendaOnlineUserID");

                    b.HasKey("CarritoID");

                    b.HasIndex("prodCarritoID");

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

                    b.HasKey("CategoriaID");

                    b.ToTable("Categoria");
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

                    b.Property<int>("codigoPostal");

                    b.Property<int?>("detalleVendedorID");

                    b.Property<string>("direccionDetallada")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("tiendaOnlineUserID");

                    b.HasKey("DireccionID");

                    b.HasIndex("MunicipioID");

                    b.HasIndex("detalleVendedorID");

                    b.HasIndex("tiendaOnlineUserID");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("tiendaOnline.Models.Municipio", b =>
                {
                    b.Property<int>("MunicipioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Departamento");

                    b.Property<string>("nombreMunicipio")
                        .IsRequired();

                    b.HasKey("MunicipioID");

                    b.ToTable("Municipio");
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

                    b.Property<int>("cantidadProducto");

                    b.Property<int?>("productoID");

                    b.HasKey("ProdCarritoID");

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

            modelBuilder.Entity("tiendaOnline.Models.Tarjeta", b =>
                {
                    b.Property<int>("TarjetaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("codigoSeguridad");

                    b.Property<DateTime>("fechaVencimiento");

                    b.Property<int>("numeroTarjeta");

                    b.Property<string>("tiendaOnlineUserID");

                    b.Property<int>("tipoTarjeta");

                    b.Property<string>("titularTarjeta")
                        .IsRequired();

                    b.HasKey("TarjetaID");

                    b.HasIndex("tiendaOnlineUserID");

                    b.ToTable("Tarjeta");
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
                    b.HasOne("tiendaOnline.Models.ProdCarrito", "prodCarrito")
                        .WithMany()
                        .HasForeignKey("prodCarritoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithOne("Carrito")
                        .HasForeignKey("tiendaOnline.Models.Carrito", "tiendaOnlineUserID");
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

                    b.HasOne("tiendaOnline.Models.DetalleVendedor", "detalleVendedor")
                        .WithMany()
                        .HasForeignKey("detalleVendedorID");

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
                        .WithMany()
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
                    b.HasOne("tiendaOnline.Areas.Identity.Data.tiendaOnlineUser", "tiendaOnlineUser")
                        .WithMany()
                        .HasForeignKey("tiendaOnlineUserID");
                });
#pragma warning restore 612, 618
        }
    }
}
