using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOnline.Models
{
    [NotMapped]
    public partial class Sucursal
    {
        public Sucursal()
        {
            Direccion = new HashSet<Direccion>();
        }
        [Key]
        public int IdSucursal { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdDireccion { get; set; }
        public string NombreSucursal { get; set; }

        public Direccion IdDireccionNavigation { get; set; }
        public Empresa IdEmpresaNavigation { get; set; }
        public ICollection<Direccion> Direccion { get; set; }
    }
}
