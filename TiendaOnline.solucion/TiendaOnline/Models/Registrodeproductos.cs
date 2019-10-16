using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Registrodeproductos
    {
        public Registrodeproductos()
        {
            Detalledevendedor = new HashSet<Detalledevendedor>();
        }

        public string IdRegistro { get; set; }
        public int? IdProducto { get; set; }

        public Producto IdProductoNavigation { get; set; }
        public ICollection<Detalledevendedor> Detalledevendedor { get; set; }
    }
}
