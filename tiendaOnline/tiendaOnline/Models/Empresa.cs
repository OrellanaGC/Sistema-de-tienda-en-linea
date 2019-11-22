using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Empresa
    {
        public int EmpresaID { get; set; }

        [Required(ErrorMessage ="Ingrese el nombre de la empresa")]
        [Display(Name ="Nombre de la Empresa")]
        public string nombreEmpresa { get; set; }

        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "Ingresar un correo valido")]
        [Required(ErrorMessage = "Ingresar el Correo ")]
        public string correoComercial { get; set; }
    }
}
