using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Models
{
    public class Direccion
    {
        public int DireccionID { get; set; }

        [Display(Name = "Dirección detallada")]
        [Required(ErrorMessage ="Ingresar la dirección"), MinLength(5), StringLength(50, ErrorMessage = "La descripción del producto solo admite como mínimo 10 y máximo 50 caracteres")]
        public string direccionDetallada { get; set; }

        [Display(Name = "Codigo Postal")]
        [Required(ErrorMessage = "Ingresar el Codigo Postal")]
        public int codigoPostal { get; set; }


        //Relacion con municipio
        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "Ingresar municipio")]
        public int MunicipioID { get; set; }
        public Municipio Municipio { get; set; }

        //Relacion para user
        public string tiendaOnlineUserID { get; set; }
        public tiendaOnlineUser tiendaOnlineUser { get; set; }

        //Relacion con DetalleVendedor
        public int? detalleVendedorID { get; set; }
        public DetalleVendedor detalleVendedor {get; set;}


        //Relacion para sucursal
        public int? sucursalID { get; set; }
        public Sucursal sucursal { get; set; }
    }
}
