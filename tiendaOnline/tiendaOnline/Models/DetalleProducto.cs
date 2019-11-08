using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class DetalleProducto
    {
        public int DetalleProductoID { get; set; }
        public string Descripcion { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string PesoKg { get; set; }
        public string Modelo { get; set; }
    }
}

