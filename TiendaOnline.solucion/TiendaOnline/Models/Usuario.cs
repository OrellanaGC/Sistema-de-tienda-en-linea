using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOnline.Models
{
    [NotMapped]
    public partial class Usuario
    {
        public Usuario()
        {
            Detalledevendedor = new HashSet<Detalledevendedor>();
            Orden = new HashSet<Orden>();
            Rol = new HashSet<Rol>();
            Tipodevendedor = new HashSet<Tipodevendedor>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipodepago { get; set; }
        public int? IdDireccion { get; set; }
        public int IdRol { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdTipodevendedor { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public int? TelefonoUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string PsswdUsuario { get; set; }
        public string Nameuser { get; set; }
        public DateTime? Fechadenacimiento { get; set; }

        public Direccion IdDireccionNavigation { get; set; }
        public Rol IdRolNavigation { get; set; }
        public Tipodepago IdTipodepagoNavigation { get; set; }
        public Tipodevendedor IdTipodevendedorNavigation { get; set; }
        public Detalledevendedor IdVendedorNavigation { get; set; }
        public ICollection<Detalledevendedor> Detalledevendedor { get; set; }
        public ICollection<Orden> Orden { get; set; }
        public ICollection<Rol> Rol { get; set; }
        public ICollection<Tipodevendedor> Tipodevendedor { get; set; }
    }
}
