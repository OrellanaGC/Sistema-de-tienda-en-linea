using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class TipoDePago
    {
        public int TipoDePagoID { get; set; }
        public int PaypalID { get; set; }
        public Paypal Paypal { get; set; }
        public int TarjetaID { get; set; }
        public Tarjeta Tarjeta { get; set; }
    }
}
