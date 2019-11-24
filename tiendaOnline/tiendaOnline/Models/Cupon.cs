using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace tiendaOnline.Models
{
    public class Cupon
    {
        public int CuponID { get; set; }
        public string codigoCupon { get; set; }
        public double montoCupon { get; set; }
        public Boolean estadoCupon { get; set; }
        public DateTime fechaCreacion { get; set; }        
        public DateTime fechaVencimiento { get; set; }
         public string descripcionCupon { get; set; }

        //Relacion con usuarios
        public tiendaOnlineUser tiendaOnlineUser { get; set; }
        public string tiendaOnlineUserID { get; set; }

        public Cupon()
        {
            montoCupon = 5.00;
            descripcionCupon = "Cupón de nuevo usuario";
            fechaCreacion = DateTime.Now;
            estadoCupon = false;
            fechaVencimiento = fechaCreacion.AddDays(30);
        }


    }
}

