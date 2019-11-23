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

        [Display(Name = "Código del cupón")]
        [Required(ErrorMessage = "Ingresar el Código del cupón"), MinLength(6, ErrorMessage = "Ingresar 6 caracteres"), StringLength(7, ErrorMessage = "Ingresar 7 caracteres")]
        public string codigoCupon { get; set; }

        [Display(Name = "Monto del cupón")]
        [Required(ErrorMessage = "Ingresar el monto del cupón"), Range(1.00, 20.00, ErrorMessage = "El cupón no puede valer más de $20.00")]
        public double montoCupon { get; set; }
        public Boolean estadoCupon { get; set; }

        [Display(Name = "Fecha de creación del cupón")]
        [Required(ErrorMessage = "Fecha de creación del cupón")]
        public DateTime fechaCreacion { get; set; }

        [Display(Name = "Fecha de vencimiento del cupón")]
        [Required(ErrorMessage = "Fecha de vencimiento del cupón")]
        public DateTime fechaVencimiento { get; set; }
        
        [Display(Name = "Titulo del cupón")]
        [Required(ErrorMessage = "Ingresar el Titulo del cupón"), MinLength(7, ErrorMessage = "Ingresar mínimo 7 caracteres"), StringLength(20, ErrorMessage = "Ingresar máximo 20 caracteres")]
        public string descripcionCupon { get; set; }

        //Relacion con usuarios
        public tiendaOnlineUser tiendaOnlineUser { get; set; }
        public string tiendaOnlineUserID { get; set; }

        public Cupon()
        {
            fechaCreacion = DateTime.Now;
            estadoCupon = false;
            fechaVencimiento = DateTime.Now;
            fechaVencimiento.AddDays(30);
        }


    }
}

