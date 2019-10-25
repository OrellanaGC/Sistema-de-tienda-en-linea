using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data.Interfaces;
using TiendaOnline.Models;

namespace TiendaOnline.Data.Implementations
{
    public class ImpOrden : IOrden
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        private readonly Carrito _carrito;

        public ImpOrden(ApplicationDbContext ApplicationDbContext, Carrito carrito)
        {
            _ApplicationDbContext = ApplicationDbContext;
            _carrito = carrito;
        }

        public void CrearOrden(Orden orden)
        {
            orden.Fechadecompra = DateTime.Now;
            _ApplicationDbContext.Add(orden);

            var prodCarrito = _carrito.ProdCarrito;

            foreach(var item in prodCarrito)
            {
                var linea = new Lineadeorden()
                {
                    Cantidaddeproducto = item.Cantidad,
                    IdProducto = item.Producto.IdProducto,
                    IdOrden = orden.IdOrden,
                    Subtotal = item.Producto.Preciounitario
                };
                _ApplicationDbContext.Lineadeorden.Add(linea);
            }
            _ApplicationDbContext.SaveChanges();
        }
    }
}
