using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Models;

namespace TiendaOnline.ViewModels
{
    public class CarritoVM
    {
        public Carrito Carrito { get; set; }
        public decimal TotalCarrito { get; set; }
    }
}
