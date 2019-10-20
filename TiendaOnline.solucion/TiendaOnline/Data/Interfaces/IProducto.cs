using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Models;

namespace TiendaOnline.Data.Interfaces
{
    public interface IProducto
    {
        IEnumerable<Producto> Productos { get;  }

        Producto GetProductoById(int IdProducto);
    }
}
