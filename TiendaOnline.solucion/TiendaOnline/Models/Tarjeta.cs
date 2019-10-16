using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Tarjeta
    {
        public Tarjeta()
        {
            DetalledevendedorIdTarjetaNavigation = new HashSet<Detalledevendedor>();
            DetalledevendedorTarIdTarjetaNavigation = new HashSet<Detalledevendedor>();
            Tipodepago = new HashSet<Tipodepago>();
        }

        public int IdTarjeta { get; set; }
        public int? IdVendedor { get; set; }
        public int? CodigoTarjeta { get; set; }
        public DateTime? FechadevencimientoTarjeta { get; set; }
        public string Tipodetarjeta { get; set; }

        public Detalledevendedor IdVendedorNavigation { get; set; }
        public ICollection<Detalledevendedor> DetalledevendedorIdTarjetaNavigation { get; set; }
        public ICollection<Detalledevendedor> DetalledevendedorTarIdTarjetaNavigation { get; set; }
        public ICollection<Tipodepago> Tipodepago { get; set; }
    }
}
