using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Areas.Identity.Data;

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
    }
}
