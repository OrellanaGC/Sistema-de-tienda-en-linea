using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Tipodepago
    {
        public Tipodepago()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipodepago { get; set; }
        public int? IdTarjeta { get; set; }
        public int? IdPaypal { get; set; }

        public Paypal IdPaypalNavigation { get; set; }
        public Tarjeta IdTarjetaNavigation { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
