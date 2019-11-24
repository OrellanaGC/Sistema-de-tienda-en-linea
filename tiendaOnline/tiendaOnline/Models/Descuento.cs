using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Descuento
    {
        public int DescuentoID { get; set; }
        public string NombreDelDescuento { get; set; }


        //Default será por porcentaje
        public bool TipoDeDescuento { get; set; }

        public int MontoDeDescuento { get; set; }

        public double PrecioConDesc { get; set; }

        //Relacion con Producto
        public int ProductoID { get; set; }
        public Producto producto { get; set; }

        public Descuento()
        {
            NombreDelDescuento = "";
            MontoDeDescuento = 0;
            TipoDeDescuento = true;
            PrecioConDesc = 0;
        }
    }
}
