using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Models
{
    public class Carrito
    {
        public int CarritoID { get; set; }

        //Relacion con ProdCarrito
        public int prodCarritoID { get; set; }
        public ProdCarrito prodCarrito { get; set; }

        //Relacion con usuario
        public String tiendaOnlineUserID { get; set; }
        public tiendaOnlineUser tiendaOnlineUser { get; set; }
    }
}
