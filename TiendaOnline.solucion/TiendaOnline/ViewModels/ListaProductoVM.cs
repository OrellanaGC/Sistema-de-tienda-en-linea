using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Models;

namespace TiendaOnline.ViewModels
{
    public class ListaProductoVM
    {
        public IEnumerable<Producto> Productos { get; set; }
        //public string CategoriaSeleccionada { get; set; }
    }
}
