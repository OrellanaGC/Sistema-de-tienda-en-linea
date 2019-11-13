using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Subcategoria
    {
        public int SubcategoriaID { get; set; }
        public string nombreSubcategoria { get; set; }

        //Relacion con Categoria
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
    }
}
