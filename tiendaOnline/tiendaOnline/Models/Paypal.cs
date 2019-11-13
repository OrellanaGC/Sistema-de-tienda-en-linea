using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Models
{
    public class Paypal
    {
        public int PaypalID { get; set; }

        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "Ingrese un correo valido")]
        [Required(ErrorMessage = "Ingresar el correo de su cuenta paypal")]
        public string correoPaypal { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Ingresar la contraseña")]        
        public string psswrdPaypal { get; set; }

        //relacion para user
        public string tiendaOnlineUserID { get; set; }
        public tiendaOnlineUser tiendaOnlineUser { get; set; }

    }
}
