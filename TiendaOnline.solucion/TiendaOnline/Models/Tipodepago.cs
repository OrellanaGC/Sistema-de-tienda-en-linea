using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Tipodepago
    {
        public Tipodepago()
        {
            Usuario = new HashSet<Usuario>();
        }
        [Key]
        public int IdTipodepago { get; set; }
        public int? IdTarjeta { get; set; }
        public int? IdPaypal { get; set; }

        public Paypal IdPaypalNavigation { get; set; }
        public Tarjeta IdTarjetaNavigation { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
