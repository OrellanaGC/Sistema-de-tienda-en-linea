using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;
using tiendaOnline.Data;

namespace tiendaOnline.Models
{
    public class Carrito
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public Carrito(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }
        public Carrito()
        {
        }

        public int CarritoID { get; set; }

        //Relacion con ProdCarrito
        public List<ProdCarrito> prodCarrito { get; set; }

        //Relacion con usuario
        public String tiendaOnlineUserID { get; set; }
        public tiendaOnlineUser tiendaOnlineUser { get; set; }

        public static Carrito GetCarrito(IServiceProvider services)
        {

            var session = services.GetRequiredService<IHttpContextAccessor>()?
                  .HttpContext.User.Identity.Name;
            System.Diagnostics.Debug.WriteLine("aqui el user1... i guess");
            System.Diagnostics.Debug.WriteLine(session);
            System.Diagnostics.Debug.WriteLine("aqui el user1... i guess");

            var context = services.GetService<ApplicationDbContext>();
            //string carritosId = session.GetString("CarritosId") ?? Guid.NewGuid().ToString();
            // var cart= new Carrito(context) {CarritosId = carritosId };
            return new Carrito(context) { CarritoID = 1 };
        }

        public void AgregarCarrito(Producto producto, int cantidad)
        {
            var prodCarrito =
                    _ApplicationDbContext.ProdCarrito.SingleOrDefault(
                        s => s.producto.ProductoID == producto.ProductoID && s.CarritoID == CarritoID);
            if (prodCarrito == null)
            {
                prodCarrito = new ProdCarrito
                {
                    CarritoID = CarritoID,
                    producto = producto,
                    cantidadProducto = 1
                };
                //Guarda los productos en el carrito
                _ApplicationDbContext.ProdCarrito.Add(prodCarrito);
            }
            else
            {
                prodCarrito.cantidadProducto++;
            }
            _ApplicationDbContext.SaveChanges();
        }

        public int EliminarDeCarrito(Producto producto)
        {
            var prodCarrito =
                    _ApplicationDbContext.ProdCarrito.SingleOrDefault(
                        s => s.producto.ProductoID == producto.ProductoID && s.CarritoID == CarritoID);

            var cantidadlocal = 0;

            if (prodCarrito != null)
            {
                if (prodCarrito.cantidadProducto > 1)
                {
                    prodCarrito.cantidadProducto--;
                    cantidadlocal = prodCarrito.cantidadProducto;
                }
                else
                {
                    _ApplicationDbContext.ProdCarrito.Remove(prodCarrito);
                }
            }

            _ApplicationDbContext.SaveChanges();

            return cantidadlocal;
        }

        public List<ProdCarrito> GetprodCarrito()
        {

            return prodCarrito ??
                   (prodCarrito =
                       _ApplicationDbContext.ProdCarrito.Where(c => c.CarritoID == CarritoID)
                           .Include(s => s.producto)
                           .ToList());
        }

        public void VaciarCarrito()
        {
            var prodCarrito = _ApplicationDbContext
                .ProdCarrito
                .Where(carrito => carrito.CarritoID == CarritoID);

            _ApplicationDbContext.ProdCarrito.RemoveRange(prodCarrito);

            _ApplicationDbContext.SaveChanges();
        }


        public double GetcarritoTotal()
        {
            var total = _ApplicationDbContext.ProdCarrito.Where(c => c.CarritoID == CarritoID)
                .Select(c => c.producto.PrecioUnitario * c.cantidadProducto).Sum();
            return total;
        }
    }
}
