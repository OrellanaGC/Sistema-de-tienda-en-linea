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
        private readonly tiendaonlineDBContext _tiendaonlineDBContext;
        private readonly Carrito _carrito;

        public ImpOrden(tiendaonlineDBContext tiendaonlineDBContext, Carrito carrito)
        {
            _tiendaonlineDBContext = tiendaonlineDBContext;
            _carrito = carrito;
        }

        public void CrearOrden(Orden orden)
        {
            orden.Fechadecompra = DateTime.Now;
            _tiendaonlineDBContext.Add(orden);

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
                _tiendaonlineDBContext.Lineadeorden.Add(linea);
            }
            _tiendaonlineDBContext.SaveChanges();
        }
    }
}
