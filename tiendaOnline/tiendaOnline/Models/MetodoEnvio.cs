using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class MetodoEnvio
    {
        public int MetodoEnvioID { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del intermediario de envio")]
        [Display(Name = "Intermediario de Envio")]
        public string nombreMetodoEnvio { get; set; }

        [Required(ErrorMessage = "Ingrese el maximo de Dias")]
        [Display(Name = "Dias maximos del envio")]
        public int maxDiasEnvio { get; set; }

        [Required(ErrorMessage = "Ingrese el minimo de Dias")]
        [Display(Name = "Dias minimos del envio")]
        public int minDiasEnvio { get; set; }

        [Required(ErrorMessage = "Ingrese el monto del envio")]
        [Display(Name = "Monto del envio")]
        public double montoEnvio { get; set; }



    }
}
