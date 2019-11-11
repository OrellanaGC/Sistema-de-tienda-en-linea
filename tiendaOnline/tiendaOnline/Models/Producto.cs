using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string NombreProducto { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int Existencia { get; set; }
        public string Codigo { get; set; }
        public string Imagen { get; set; }
        public DetalleProducto DetalleProducto { get; set; }
        public int SubcategoriaID { get; set; }
        public Subcategoria Subcategoria { get; set; }
    }
}

