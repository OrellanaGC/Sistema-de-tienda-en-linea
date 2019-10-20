using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Models
{
    public class ProdCarrito
    {
        public int ProdCarritoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public string CarritoId { get; set; }
    }
}
