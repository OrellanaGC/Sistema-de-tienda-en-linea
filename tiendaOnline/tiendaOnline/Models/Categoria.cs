using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string nombre_categoria { get; set; }

        //Agregando stocks a las categorias
        [Required(ErrorMessage = "Debe completar el campo de Stock mínimo")]
        [Display(Name = "Stock mínimo requerido")]
        public int stockMax { get; set; }
        [Required(ErrorMessage = "Debe completar el campo de Stock máximo")]
        [Display(Name = "Stock máximo permitido")]
        public int stockMin { get; set; }        
    }
}
