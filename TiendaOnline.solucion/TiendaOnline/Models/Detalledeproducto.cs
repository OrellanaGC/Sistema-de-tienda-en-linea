using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Detalledeproducto
    {
        public Detalledeproducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdDetalle { get; set; }
        public string Escripciondeproducto { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public decimal? Pesokg { get; set; }
        public string Modelo { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
