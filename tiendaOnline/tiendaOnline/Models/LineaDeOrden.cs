using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class LineaDeOrden
    {
        public int LineaDeOrdenID { get; set; }

        [Display(Name ="Subtotal")]
        public double subtotal { get; set; }

        //Relacion uno a uno con ProdCarrito
        public ProdCarrito productoCarrito { get; set; }
        public int productoCarritoID { get; set; }
        

        //Relacion uno a muchos con Orden
        public Orden orden { get; set; }
        public int ordenID { get; set; }
    }
}
