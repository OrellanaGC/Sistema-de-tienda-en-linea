using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOnline.Models
{
    [NotMapped]
    public partial class Detalledevendedor
    {
        public Detalledevendedor()
        {
            Empresa = new HashSet<Empresa>();
            Producto = new HashSet<Producto>();
            Tarjeta = new HashSet<Tarjeta>();
            Tipodevendedor = new HashSet<Tipodevendedor>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdVendedor { get; set; }
        public int? IdUsuario { get; set; }
        public string IdRegistro { get; set; }
        public int? IdTarjeta { get; set; }
        public int? IdDireccion { get; set; }
        public int? TarIdTarjeta { get; set; }
        public int? IdEmpresa { get; set; }
        public int? DirIdDireccion { get; set; }
        public string Nombrecomercial { get; set; }
        public string Correocomercial { get; set; }

        public Direccion DirIdDireccionNavigation { get; set; }
        public Direccion IdDireccionNavigation { get; set; }
        public Empresa IdEmpresaNavigation { get; set; }
        public Registrodeproductos IdRegistroNavigation { get; set; }
        public Tarjeta IdTarjetaNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public Tarjeta TarIdTarjetaNavigation { get; set; }
        public ICollection<Empresa> Empresa { get; set; }
        public ICollection<Producto> Producto { get; set; }
        public ICollection<Tarjeta> Tarjeta { get; set; }
        public ICollection<Tipodevendedor> Tipodevendedor { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
