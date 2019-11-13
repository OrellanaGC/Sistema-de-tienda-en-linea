using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class ProdCarrito
    {
        public int ProdCarritoID { get; set; }
        public int cantidadProducto { get; set; }

        //Relacion con Producto
        public int? productoID { get; set; }
        public Producto producto { get; set; }
    }
}
