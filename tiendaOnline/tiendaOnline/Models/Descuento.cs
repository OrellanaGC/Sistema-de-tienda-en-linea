using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Descuento
    {
        public int DescuentoID { get; set; }

        [Display(Name = "Nombre de su descuento")]
        [Required(ErrorMessage = "Ingresar el nombre del descuento"), MinLength(5, ErrorMessage = "Ingresar minimo 5 caracteres"), StringLength(20, ErrorMessage = "El nombre deldescuento solo admite como máximo 20 caracteres")]
        public string NombreDelDescuento { get; set; }


        [Display(Name = "Seleccione el tipo de descuento que necesita")]
        [Required(ErrorMessage = "Es necesario seleccionar un tipo de descuento")]
        //Default será por porcentaje
        public bool TipoDeDescuento { get; set; }

        [Display(Name = "Monto de su descuento")]
        [Required(ErrorMessage = "Ingresar el monto del descuento"), Range(1, 100, ErrorMessage = "El porcentaje debe ser en números enteros, el monto no puede ser mayor a $100")]
        public int MontoDeDescuento { get; set; }

        public double PrecioConDesc { get; set; }

        //Relacion con Producto
        public int ProductoID { get; set; }
        public Producto producto { get; set; }

        public Descuento()
        {
            NombreDelDescuento = "";
            MontoDeDescuento = 0;
            TipoDeDescuento = true;
            PrecioConDesc = 0;
        }
    }
}
