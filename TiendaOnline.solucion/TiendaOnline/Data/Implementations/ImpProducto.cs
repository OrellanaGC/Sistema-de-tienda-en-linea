using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data.Interfaces;
using TiendaOnline.Models;

namespace TiendaOnline.Data.Implementations
{
    public class ImpProducto: IProducto
    {
        private readonly tiendaonlineDBContext _tiendaDbContext;

        public ImpProducto(tiendaonlineDBContext tiendaDbContext)
        {
            _tiendaDbContext = tiendaDbContext;
             
        }

        public IEnumerable<Producto> Productos => _tiendaDbContext.Producto;

        public Producto GetProductoById(int idProducto) =>
            _tiendaDbContext.Producto.FirstOrDefault(p => p.IdProducto == idProducto);

    }
}
