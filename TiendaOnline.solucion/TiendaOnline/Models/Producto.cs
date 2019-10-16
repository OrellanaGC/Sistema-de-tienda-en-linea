using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Lineadeorden = new HashSet<Lineadeorden>();
            Registrodeproductos = new HashSet<Registrodeproductos>();
        }

        public int IdProducto { get; set; }
        public int IdDetalle { get; set; }
        public int? IdTipodedescuento { get; set; }
        public int IdSubcategoria { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdEmpresa { get; set; }
        public string NombreProducto { get; set; }
        public decimal Preciounitario { get; set; }
        public byte[] ImgProducto { get; set; }
        public int Existencia { get; set; }
        public string Codigodeproducto { get; set; }

        public Detalledeproducto IdDetalleNavigation { get; set; }
        public Empresa IdEmpresaNavigation { get; set; }
        public Subcategoria IdSubcategoriaNavigation { get; set; }
        public Tipodedescuento IdTipodedescuentoNavigation { get; set; }
        public Detalledevendedor IdVendedorNavigation { get; set; }
        public ICollection<Lineadeorden> Lineadeorden { get; set; }
        public ICollection<Registrodeproductos> Registrodeproductos { get; set; }
    }
}
