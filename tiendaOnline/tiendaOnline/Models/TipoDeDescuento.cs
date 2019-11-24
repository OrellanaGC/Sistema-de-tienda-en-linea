using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class TipoDeDescuento
    {
        public int TipoDeDescuentoID { get; set; }

        [Display(Name = "Nombre de su descuento")]
        [Required(ErrorMessage = "Ingresar el nombre del descuento"), MinLength(5, ErrorMessage = "Ingresar minimo 5 caracteres"), StringLength(20, ErrorMessage = "El nombre deldescuento solo admite como máximo 20 caracteres")]
        public string nombreDelDescuento { get; set; }

        [Display(Name = "Monto de su descuento")]
        [Required(ErrorMessage = "Ingresar el monto del descuento"), Range(1,100, ErrorMessage = "El producto no puede tener descuento superior a $100.00")]
        public int montoDeDescuento { get; set; }

        [Display(Name = "Porcentaje de su descuento (en entero)")]
        [Required(ErrorMessage = "Ingresar el porcentaje del descuento"), Range(1, 99, ErrorMessage = "El producto no puede tener descuento superior al 99%")]
        public int porcentajeDeDescuento { get; set; }

        //Relacion con Producto
        public int ProductoID { get; set; }
        public Producto producto { get; set; }
        
        public TipoDeDescuento()
        {
            nombreDelDescuento = "";
            montoDeDescuento = 0;
            porcentajeDeDescuento = 0;
        }
       

    }
}
