using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Subcategoria
    {
        public Subcategoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdSubcategoria { get; set; }
        public int IdCategoria { get; set; }
        public string NombreSubcategoria { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public ICollection<Producto> Producto { get; set; }
    }
}
