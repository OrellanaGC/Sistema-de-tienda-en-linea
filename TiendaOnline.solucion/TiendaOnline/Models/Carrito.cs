using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Models
{
    public class Carrito
    {
  
        private readonly tiendaonlineDBContext _tiendaonlineDBContext;
        private Carrito(tiendaonlineDBContext tiendaonlineDBContext)
        {
            _tiendaonlineDBContext = tiendaonlineDBContext;
        }
        public string CarritoId { get; set; }
        public List<ProdCarrito> ProdCarrito { get; set; }

        public static Carrito GetCarrito(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<tiendaonlineDBContext>();
            string carritosId = session.GetString("CarritosId") ?? Guid.NewGuid().ToString();
          
            // var cart= new Carrito(context) {CarritosId = carritosId };
            // _tiendaonlineDBContext.Carrito.Add(cart);
            return new Carrito(context) { CarritoId = carritosId };
        }

        public void AgregarCarrito(Producto producto, int cantidad)
        {
            var prodCarrito =
                    _tiendaonlineDBContext.ProdCarrito.SingleOrDefault(
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
                //_tiendaonlineDBContext.ProdCarrito.Add(prodCarrito);
            }
            else
            {
                prodCarrito.Cantidad++;
            }
            _tiendaonlineDBContext.SaveChanges();
        }

        public int EliminarDeCarrito(Producto producto)
        {
            var prodCarrito =
                    _tiendaonlineDBContext.ProdCarrito.SingleOrDefault(
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
                    _tiendaonlineDBContext.ProdCarrito.Remove(prodCarrito);
                }
            }

            _tiendaonlineDBContext.SaveChanges();

            return cantidadlocal;
        }

        public List<ProdCarrito> GetProdCarrito()
        {
            return ProdCarrito ??
                   (ProdCarrito =
                       _tiendaonlineDBContext.ProdCarrito.Where(c => c.CarritoId == CarritoId)
                           .Include(s => s.Producto)
                           .ToList());
        }

        public void VaciarCarrito()
        {
            var ProdCarrito = _tiendaonlineDBContext
                .ProdCarrito
                .Where(carrito => carrito.CarritoId == CarritoId);

            _tiendaonlineDBContext.ProdCarrito.RemoveRange(ProdCarrito);

            _tiendaonlineDBContext.SaveChanges();
        }

        public decimal GetcarritoTotal()
        {
            var total = _tiendaonlineDBContext.ProdCarrito.Where(c => c.CarritoId == CarritoId)
                .Select(c => c.Producto.Preciounitario * c.Cantidad).Sum();
            return total;
        }
    }
}
