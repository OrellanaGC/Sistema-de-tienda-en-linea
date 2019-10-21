using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Data.Interfaces;

namespace TiendaOnline.Controllers
{
    public class OrdenController : Controller
    {
        private readonly IOrden _orden;
        private readonly CarritoController _carrito;

        public OrdenController(IOrden orden, CarritoController carrito)
        {
            _orden = orden;
            _carrito = carrito;
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}