using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Data.Interfaces;
using tiendaOnline.Models;

namespace tiendaOnline.Data.Implementations
{
    public class ImpOrden : IOrden
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly Carrito _carrito;

        public ImpOrden(ApplicationDbContext applicationDbContext, Carrito carrito)
        {
            _applicationDbContext = applicationDbContext;
            _carrito = carrito;
        }

        public void CrearOrden(Orden orden)
        {
            orden.fechaOrden = DateTime.Now;
            _applicationDbContext.Orden.Add(orden);

            var prodCarrito = _carrito.prodCarrito;

            foreach (var producto in prodCarrito)
            {
                if (producto.IsSelected == true)
                {
                    var lineaDeOrden = new LineaDeOrden()
                    {
                        Cantidad = producto.cantidadProducto,
                        OrdenID = orden.OrdenID,
                        ProductoID = producto.producto.ProductoID,
                        subtotal = (producto.producto.PrecioUnitario * producto.cantidadProducto)
                    };
                    _applicationDbContext.Add(lineaDeOrden);
                }
            }
            _applicationDbContext.SaveChanges();
        }
    }
}
