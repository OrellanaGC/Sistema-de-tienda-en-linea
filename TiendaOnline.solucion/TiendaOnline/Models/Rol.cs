using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }
        [Key]
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
        public string NombreRol { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
