using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Models
{    
    public class DetalleVendedor
    {
        public int DetalleVendedorID { get; set; }

        [Display(Name = "Nombre Comercial")]
        [Required(ErrorMessage = "Ingresar el Nombre Comercial")]
        [MaxLength(30, ErrorMessage ="ingresar 30 caracteres como maximo"), MinLength(3, ErrorMessage ="Ingresar 3 caracteres como minimo")]
        public string nombreComercial { get; set; }

        [Display(Name = "Correo Comercial")]
        [EmailAddress(ErrorMessage ="Ingresar un correo valido")]
        [Required(ErrorMessage = "Ingresar el Correo Comercial")]
        public string correoComercial { get; set; }

        [Display(Name = "Tipo de Vendedor")]
        [Required(ErrorMessage = "Ingresar el Tipo de Vendedor")]
        public TipoVendedor tipoVendedor { get; set; }

        ////relacion para user OneToOne
        public string tiendaOnlineUserID { get; set; }
        public tiendaOnlineUser tiendaOnlineUser { get; set; }

    }

    //Tipos de Vendedor
    public enum TipoVendedor
    {
        [Display(Name = "Particular")] Particular,
        [Display(Name = "Privado")]    Privado
    }
}
