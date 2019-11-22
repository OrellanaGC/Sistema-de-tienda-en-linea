using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class DetalleProducto
    {
        public int DetalleProductoID { get; set; }

        [Required, MinLength(10), StringLength(300, ErrorMessage = "La descripción del producto solo admite como mínimo 10 y máximo 300 caracteres")]
        [Display(Name ="Descripción")]        
        public string Descripcion { get; set; }

        [StringLength(10, ErrorMessage = "La talla solo admite como máximo 10 caracteres"), MinLength(1)]
        [Display(Name ="Talla")]
        public string Talla { get; set; }

        [StringLength(20, ErrorMessage = "El color solo admite como máximo 20 caracteres"), MinLength(3)]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Range(0,100, ErrorMessage = "El peso solo puede ser máximo 100kg")]
        [Display(Name = "Peso (kg)")]
        public double PesoKg { get; set; }

        [StringLength(20, ErrorMessage = "La marca solo admite como máximo 20 caracteres"), MinLength(3)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [StringLength(20, ErrorMessage = "El modelo solo admite como máximo 20 caracteres")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        //Relacion con Producto
        public int productoID { get; set; }
        public Producto producto { get; set; }

        
    }
}
