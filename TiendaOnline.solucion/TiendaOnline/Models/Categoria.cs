using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Subcategoria = new HashSet<Subcategoria>();
        }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }

        public ICollection<Subcategoria> Subcategoria { get; set; }
    }
}
