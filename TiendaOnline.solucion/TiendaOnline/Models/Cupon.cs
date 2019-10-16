using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Cupon
    {
        public Cupon()
        {
            Orden = new HashSet<Orden>();
        }

        public int IdCupon { get; set; }
        public string CodigoCupon { get; set; }
        public decimal? MontoCupon { get; set; }
        public bool? EstadoCupon { get; set; }
        public DateTime? Fechadecreacion { get; set; }
        public DateTime? Fechadevencimiento { get; set; }
        public string Descripciondelcupon { get; set; }

        public ICollection<Orden> Orden { get; set; }
    }
}
