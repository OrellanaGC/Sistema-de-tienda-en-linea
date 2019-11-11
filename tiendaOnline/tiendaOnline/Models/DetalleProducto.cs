using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class DetalleProducto
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string PesoKg { get; set; }
        public string Modelo { get; set; }
        public int ProductoId { get; set; }
    }
}
