using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public Carrito(string userid)
        {
            tiendaOnlineUserID = userid;
        }

        public int CarritoID { get; set; }

        //Relacion con ProdCarrito
        public List<ProdCarrito> prodCarrito { get; set; }

        //Relacion con usuario
        public String tiendaOnlineUserID { get; set; }
        public tiendaOnlineUser tiendaOnlineUser { get; set; }

        public static Carrito GetCarrito(IServiceProvider services)
        {

            var context = services.GetService<ApplicationDbContext>();
            //obtiene el id del usuario
            var session = services.GetRequiredService<IHttpContextAccessor>()?
                  .HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //con este comando se imprime en consola al hacer debug
            //System.Diagnostics.Debug.WriteLine("esto en consola xD");

            //aqui se busca el carrito que corresponde a ese usuario
            var carritos = context.Carrito;
            var carritoID =0;
            foreach(Carrito c in carritos)
            {   
                if(c.tiendaOnlineUserID == session)
                {
                    carritoID = c.CarritoID;
                }
            }

            return new Carrito(context) { CarritoID = carritoID };
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
            System.Diagnostics.Debug.WriteLine("esto en consola xD");
            System.Diagnostics.Debug.WriteLine("esto en consola xD");
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
                    _ApplicationDbContext.Remove(prodCarrito);
                }
            }
            _ApplicationDbContext.SaveChanges();

            return cantidadlocal;
        }

        public int EliminarProdDeCarrito(Producto producto)
        {
            var prodCarrito =
                    _ApplicationDbContext.ProdCarrito.SingleOrDefault(
                        s => s.producto.ProductoID == producto.ProductoID && s.CarritoID == CarritoID);
            var cantidadlocal = 0;

            if (prodCarrito != null)
            {
                
                    _ApplicationDbContext.Remove(prodCarrito);
                
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

        public void SeleccionarProd(Producto producto)
        {
            var prodCarrito =
                    _ApplicationDbContext.ProdCarrito.SingleOrDefault(
                        s => s.producto.ProductoID == producto.ProductoID && s.CarritoID == CarritoID);
            if (prodCarrito != null)
            {
                
                if (prodCarrito.IsSelected == false)
                {

                    prodCarrito.IsSelected = true;
                }
                else
                {
                    prodCarrito.IsSelected = false;
                }
                //Hay que guardar en LineaOrden
              //  _ApplicationDbContext.ProdCarrito.Add(prodCarrito);
            }
            _ApplicationDbContext.SaveChanges();
        }



        public double GetcarritoTotal()
        {
            var total = _ApplicationDbContext.ProdCarrito.Where(c => c.CarritoID == CarritoID && c.IsSelected== true)
                .Select(c => c.producto.PrecioUnitario * c.cantidadProducto).Sum();
            return total;
        }
    }
}
