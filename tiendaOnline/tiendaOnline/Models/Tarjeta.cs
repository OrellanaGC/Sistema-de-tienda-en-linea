using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Tarjeta
    {
        public int TarjetaID { get; set; }
        public int codigoTarjeta { get; set; }
        public string tipoTarjeta { get; set; }
        public DateTime fechaVencimiento { get; set; }
    }
}
