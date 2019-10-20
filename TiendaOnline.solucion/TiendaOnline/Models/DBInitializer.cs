using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TiendaOnline.Data;
using System;
using System.Linq;

namespace TiendaOnline.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tiendaonlineDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tiendaonlineDBContext>>()))
            {
                // Look for any movies.
                if (context.Producto.Any())
                {
                    return;   // DB has been seeded
                }

                context.Producto.AddRange(
                   
                );
                context.SaveChanges();
            }
        }
    }
}