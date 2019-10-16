using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Detalledevendedor = new HashSet<Detalledevendedor>();
            Metododeenvio = new HashSet<Metododeenvio>();
            Producto = new HashSet<Producto>();
            Sucursal = new HashSet<Sucursal>();
        }

        public int? TelefonoAtencionalcliente { get; set; }
        public string CorreoAtencionalcliente { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdVendedor { get; set; }

        public Detalledevendedor IdVendedorNavigation { get; set; }
        public ICollection<Detalledevendedor> Detalledevendedor { get; set; }
        public ICollection<Metododeenvio> Metododeenvio { get; set; }
        public ICollection<Producto> Producto { get; set; }
        public ICollection<Sucursal> Sucursal { get; set; }
    }
}
