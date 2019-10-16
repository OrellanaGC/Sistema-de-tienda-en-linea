using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
            DetalledevendedorDirIdDireccionNavigation = new HashSet<Detalledevendedor>();
            DetalledevendedorIdDireccionNavigation = new HashSet<Detalledevendedor>();
            Sucursal = new HashSet<Sucursal>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdDireccion { get; set; }
        public int IdDepartamento { get; set; }
        public int? IdSucursal { get; set; }
        public int? Codigopostal { get; set; }
        public string Direcciondetallada { get; set; }

        public Departamento IdDepartamentoNavigation { get; set; }
        public Sucursal IdSucursalNavigation { get; set; }
        public ICollection<Detalledevendedor> DetalledevendedorDirIdDireccionNavigation { get; set; }
        public ICollection<Detalledevendedor> DetalledevendedorIdDireccionNavigation { get; set; }
        public ICollection<Sucursal> Sucursal { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
