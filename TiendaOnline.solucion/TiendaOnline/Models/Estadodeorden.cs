using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Estadodeorden
    {
        public Estadodeorden()
        {
            Orden = new HashSet<Orden>();
        }
        [Key]
        public int IdEstadodeorden { get; set; }
        public bool? EstadoDeorden1 { get; set; }

        public ICollection<Orden> Orden { get; set; }
    }
}
