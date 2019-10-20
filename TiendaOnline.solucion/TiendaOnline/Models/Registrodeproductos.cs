using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Registrodeproductos
    {
        public Registrodeproductos()
        {
            Detalledevendedor = new HashSet<Detalledevendedor>();
        }
        [Key]
        public string IdRegistro { get; set; }
        public int? IdProducto { get; set; }

        public Producto IdProductoNavigation { get; set; }
        public ICollection<Detalledevendedor> Detalledevendedor { get; set; }
    }
}
