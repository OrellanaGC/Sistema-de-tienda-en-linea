using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Models;
using TiendaOnline.ViewModels;

namespace TiendaOnline.Components
{
    public class CarritoComponent : ViewComponent
    {
        private readonly Carrito _carrito;
        public CarritoComponent(Carrito carrito)
        {
            _carrito = carrito;
        }
        public IViewComponentResult Invoke()
        {
            var items = _carrito.GetProdCarrito();
            _carrito.ProdCarrito = items;

            var carritoVM = new CarritoVM
            {
                Carrito = _carrito,
                TotalCarrito = _carrito.GetcarritoTotal()
            };
            return View(carritoVM);
        }
    }
}
