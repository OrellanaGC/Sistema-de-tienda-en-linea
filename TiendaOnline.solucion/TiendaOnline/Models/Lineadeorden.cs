using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Lineadeorden
    {
        public int IdLineadeorden { get; set; }
        public int? IdOrden { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidaddeproducto { get; set; }
        public decimal? Subtotal { get; set; }

        public Orden IdOrdenNavigation { get; set; }
        public Producto IdProductoNavigation { get; set; }
    }
}
