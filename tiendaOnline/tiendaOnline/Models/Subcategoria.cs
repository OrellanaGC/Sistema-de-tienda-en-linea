using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Subcategoria
    {
        public int SubcategoriaID { get; set; }
        [Required(ErrorMessage ="Ingresar el nombre del municipio")]
        public string nombreSubcategoria { get; set; }

        //Relacion con Categoria
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
    }
}
