using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Areas.Identity.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext<tiendaOnlineUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<tiendaOnline.Models.Carrito> Carrito { get; set; }
        public DbSet<tiendaOnline.Models.Categoria> Categoria { get; set; }
        public DbSet<tiendaOnline.Models.Subcategoria> Subcategoria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<tiendaOnline.Models.Paypal> Paypal { get; set; }
        public DbSet<tiendaOnline.Models.Tarjeta> Tarjeta { get; set; }                 
        public DbSet<tiendaOnline.Models.Municipio> Municipio { get; set; }
        public DbSet<tiendaOnline.Models.Direccion> Direccion { get; set; }
        public DbSet<tiendaOnline.Models.Producto> Producto { get; set; }
        public DbSet<tiendaOnline.Models.DetalleProducto> DetalleProducto { get; set; }
        public DbSet<tiendaOnline.Models.DetalleVendedor> DetalleVendedor { get; set; }
        public DbSet<tiendaOnline.Models.ProdCarrito> ProdCarrito { get; set; }
        public DbSet<tiendaOnline.Models.Cupon> Cupon { get; set; }
        public DbSet<tiendaOnline.Models.MetodoEnvio> MetodoEnvio { get; set; }
        public DbSet<tiendaOnline.Models.Orden> Orden { get; set; }
        public DbSet<tiendaOnline.Models.TipoDeDescuento> TipoDeDescuento { get; set; }
        public DbSet<tiendaOnline.Models.Departamento> Departamento { get; set; }

    }
}
