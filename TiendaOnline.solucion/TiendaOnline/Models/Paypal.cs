using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Paypal
    {
        public Paypal()
        {
            Tipodepago = new HashSet<Tipodepago>();
        }
        [Key]
        public int IdPaypal { get; set; }
        public string CorreoPaypal { get; set; }
        public string PsswdPaypal { get; set; }

        public ICollection<Tipodepago> Tipodepago { get; set; }
    }
}
