using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        //it may be nombre
        public string NombreProducto { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public string Codigo { get; set; }
        public string Imagen { get; set; }
        public int DetalleProductoID { get; set; }
        public DetalleProducto DetalleProducto { get; set; }
        public int SubcategoriaID { get; set; }
        public Subcategoria Subcategoria { get; set; }

    }
}
