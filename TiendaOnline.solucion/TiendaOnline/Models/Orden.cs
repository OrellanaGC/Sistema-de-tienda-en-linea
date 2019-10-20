using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Orden
    {
        public Orden()
        {
            Lineadeorden = new HashSet<Lineadeorden>();
        }
        [Key]
        public int IdOrden { get; set; }
        public int? IdEstadodeorden { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCupon { get; set; }
        public int? IdMetododeenvio { get; set; }
        public DateTime? Fechadecompra { get; set; }
        public decimal? Total { get; set; }

        public Cupon IdCuponNavigation { get; set; }
        public Estadodeorden IdEstadodeordenNavigation { get; set; }
        public Metododeenvio IdMetododeenvioNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Lineadeorden> Lineadeorden { get; set; }
    }
}
