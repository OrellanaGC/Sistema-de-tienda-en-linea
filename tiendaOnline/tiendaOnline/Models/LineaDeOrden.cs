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

        //the freaking price
        [Display(Name = "Subtotal")]
        public double subtotal { get; set; }

        public int Cantidad { get; set; }

        //Relacion a Producto
        public virtual Producto Producto { get; set; }
        public int? ProductoID { get; set; }
        

        //Relacion uno a muchos con Orden
        public Orden orden { get; set; }
        public int OrdenID { get; set; }

    }
}
