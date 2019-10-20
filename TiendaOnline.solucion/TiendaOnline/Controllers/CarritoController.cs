using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Data.Interfaces;
using TiendaOnline.Models;
using TiendaOnline.ViewModels;
using Microsoft.AspNetCore.Authorization;
using TiendaOnline.Data.Implementations;

namespace TiendaOnline.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IProducto _producto;
        private readonly Carrito _carrito;

        public CarritoController(IProducto producto, Carrito carrito)
        {
            _carrito = carrito;
            _producto = producto;
        }
        public ViewResult IndexC()
        {
            var Prod = _carrito.GetProdCarrito();
            _carrito.ProdCarrito = Prod;

            var carritoVM = new CarritoVM
            {
                Carrito = _carrito,
                TotalCarrito = _carrito.GetcarritoTotal()
            };
            return View(carritoVM);
        }

        [Authorize]
        public RedirectToActionResult AgregarCarrito(int idProducto)
        {
            var prodSeleccionado = _producto.Productos.FirstOrDefault(p => p.IdProducto == idProducto);
            if (prodSeleccionado != null)
            {
                _carrito.AgregarCarrito(prodSeleccionado, 1);
            }
            return RedirectToAction("IndexC");
        }

        public RedirectToActionResult EliminarDeCarrito(int idProducto)
        {
            var prodSeleccionado = _producto.Productos.FirstOrDefault(p => p.IdProducto == idProducto);
            if (prodSeleccionado != null)
            {
                _carrito.EliminarDeCarrito(prodSeleccionado);
            }
            return RedirectToAction("IndexC");
        }
    }
}