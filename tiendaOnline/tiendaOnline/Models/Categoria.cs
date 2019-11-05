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
        public string nombre_categoria { get; set; }

        //public ICollection<Subcategoria> Subcategoria { get; set; }
    }
}
