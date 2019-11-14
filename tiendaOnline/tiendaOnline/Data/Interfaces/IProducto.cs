using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tiendaOnline.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tiendaOnline.Data.Interfaces
{
    public interface IProducto 
    {
        IEnumerable<Producto> Productos { get; }

        Producto GetProductoById(int Id);
    }
}
