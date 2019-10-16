using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Estadodeorden
    {
        public Estadodeorden()
        {
            Orden = new HashSet<Orden>();
        }

        public int IdEstadodeorden { get; set; }
        public bool? EstadoDeorden1 { get; set; }

        public ICollection<Orden> Orden { get; set; }
    }
}
