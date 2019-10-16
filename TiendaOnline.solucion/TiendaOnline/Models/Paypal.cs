using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Paypal
    {
        public Paypal()
        {
            Tipodepago = new HashSet<Tipodepago>();
        }

        public int IdPaypal { get; set; }
        public string CorreoPaypal { get; set; }
        public string PsswdPaypal { get; set; }

        public ICollection<Tipodepago> Tipodepago { get; set; }
    }
}
