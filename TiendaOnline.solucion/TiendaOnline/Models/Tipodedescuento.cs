using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Tipodedescuento
    {
        public Tipodedescuento()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdTipodedescuento { get; set; }
        public string Nombredeldescuento { get; set; }
        public decimal? Montodedescuento { get; set; }
        public decimal? Porcentajededescuento { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
