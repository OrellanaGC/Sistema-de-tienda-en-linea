using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Data.Interfaces;
using tiendaOnline.Models;

namespace tiendaOnline.Data.Implementations
{
    public class ImpProducto : IProducto 
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public ImpProducto(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;

        }

        public IEnumerable<Producto> Productos => _ApplicationDbContext.Producto;

        public Producto GetProductoById(int idProducto) =>
            _ApplicationDbContext.Producto.FirstOrDefault(p => p.ProductoID == idProducto);
    }
}
