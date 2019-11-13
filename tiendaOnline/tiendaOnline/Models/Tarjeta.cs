using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Models
{
    public enum TipoTarjeta
    {
        Debito,
        Credito
    }
    public class Tarjeta
    {
        public int TarjetaID { get; set; }

        [CreditCard(ErrorMessage ="Introduzca un formato valido")]
        [Display(Name = "Codigo de Tarjeta")]
        [Required(ErrorMessage = "Ingresar el codigo de la tarjeta")]
        public int numeroTarjeta { get; set; }

        [Display(Name = "Codigo de Seguridad")]
        [Required(ErrorMessage = "Ingresar el codigo de seguridad")]
        public int codigoSeguridad { get; set; }

        [Display(Name = "Tipo de Tarjeta")]
        [Required(ErrorMessage = "Ingresar el tipo de la tarjeta")]
        public TipoTarjeta tipoTarjeta { get; set; }

        [Display(Name = "Titular de la Tarjeta")]
        [Required(ErrorMessage = "Ingresar el titular de la tarjeta")]
        public string titularTarjeta { get; set; } 

        [Display(Name = "Fecha de vencimiento")]        
        [Required(ErrorMessage = "Ingresar la fecha de vencimiento de la tarjeta")]
        public DateTime fechaVencimiento { get; set; }


        //relacion para user
        public string tiendaOnlineUserID { get; set; }
        public tiendaOnlineUser tiendaOnlineUser { get; set; }
    }
}
