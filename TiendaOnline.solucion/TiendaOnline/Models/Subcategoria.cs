using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Subcategoria
    {
        public Subcategoria()
        {
            Producto = new HashSet<Producto>();
        }
        [Key]
        public int IdSubcategoria { get; set; }
        public int IdCategoria { get; set; }
        public string NombreSubcategoria { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public ICollection<Producto> Producto { get; set; }
    }
}
