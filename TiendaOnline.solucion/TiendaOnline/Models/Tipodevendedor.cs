using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Tipodevendedor
    {
        public Tipodevendedor()
        {
            Usuario = new HashSet<Usuario>();
        }
        [Key]
        public int IdTipodevendedor { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdVendedor { get; set; }
        public string Tipodevendedor1 { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public Detalledevendedor IdVendedorNavigation { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
