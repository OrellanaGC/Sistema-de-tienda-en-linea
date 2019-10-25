using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Models;

namespace TiendaOnline.Data
{
    public class Carrito
    {
  
        private readonly ApplicationDbContext _ApplicationDbContext;
        private Carrito(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }
        public string CarritoId { get; set; }
        public List<ProdCarrito> ProdCarrito { get; set; }

        public static Carrito GetCarrito(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string carritosId = session.GetString("CarritosId") ?? Guid.NewGuid().ToString();
          
            // var cart= new Carrito(context) {CarritosId = carritosId };
            // _ApplicationDbContext.Carrito.Add(cart);
            return new Carrito(context) { CarritoId = carritosId };
        }

        public void AgregarCarrito(Producto producto, int cantidad)
        {
            var prodCarrito =
                    _ApplicationDbContext.ProdCarrito.SingleOrDefault(
                        s => s.Producto.IdProducto == producto.IdProducto && s.CarritoId == CarritoId);
            if (prodCarrito == null)
            {
                prodCarrito = new ProdCarrito
                {
                    CarritoId = CarritoId,
                    Producto = producto,
                    Cantidad = 1
                };
                //Guarda los productos en el carrito
                //_ApplicationDbContext.ProdCarrito.Add(prodCarrito);
            }
            else
            {
                prodCarrito.Cantidad++;
            }
            _ApplicationDbContext.SaveChanges();
        }

        public int EliminarDeCarrito(Producto producto)
        {
            var prodCarrito =
                    _ApplicationDbContext.ProdCarrito.SingleOrDefault(
                        s => s.Producto.IdProducto == producto.IdProducto && s.CarritoId == CarritoId);

            var cantidadlocal = 0;

            if (prodCarrito != null)
            {
                if (prodCarrito.Cantidad > 1)
                {
                    prodCarrito.Cantidad--;
                    cantidadlocal = prodCarrito.Cantidad;
                }
                else
                {
                    _ApplicationDbContext.ProdCarrito.Remove(prodCarrito);
                }
            }

            _ApplicationDbContext.SaveChanges();

            return cantidadlocal;
        }

        public List<ProdCarrito> GetProdCarrito()
        {
            return ProdCarrito ??
                   (ProdCarrito =
                       _ApplicationDbContext.ProdCarrito.Where(c => c.CarritoId == CarritoId)
                           .Include(s => s.Producto)
                           .ToList());
        }

        public void VaciarCarrito()
        {
            var ProdCarrito = _ApplicationDbContext
                .ProdCarrito
                .Where(carrito => carrito.CarritoId == CarritoId);

            _ApplicationDbContext.ProdCarrito.RemoveRange(ProdCarrito);

            _ApplicationDbContext.SaveChanges();
        }

        public decimal GetcarritoTotal()
        {
            var total = _ApplicationDbContext.ProdCarrito.Where(c => c.CarritoId == CarritoId)
                .Select(c => c.Producto.Preciounitario * c.Cantidad).Sum();
            return total;
        }
    }
}
