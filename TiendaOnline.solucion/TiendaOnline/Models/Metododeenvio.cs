using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Metododeenvio
    {
        public Metododeenvio()
        {
            Orden = new HashSet<Orden>();
        }
        [Key]
        public int IdMetododeenvio { get; set; }
        public int? IdEmpresa { get; set; }
        public string NombreMetododeenvio { get; set; }
        public int? Maxdediasdeenvio { get; set; }
        public int? Mindediasdeenvio { get; set; }
        public decimal? Montoporenvio { get; set; }

        public Empresa IdEmpresaNavigation { get; set; }
        public ICollection<Orden> Orden { get; set; }
    }
}
