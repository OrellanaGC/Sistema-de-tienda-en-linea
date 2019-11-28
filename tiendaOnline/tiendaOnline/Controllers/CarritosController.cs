using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Areas.Identity.Data;
using tiendaOnline.Data;
using tiendaOnline.Data.Interfaces;
using tiendaOnline.Models;
using tiendaOnline.ViewModels;

namespace tiendaOnline.Controllers
{
    public class CarritosController : Controller
    {
        private readonly UserManager<tiendaOnlineUser> _userManager;
        private readonly IProducto _producto;
        private readonly Carrito _carrito;

        public CarritosController(IProducto producto, Carrito carrito, UserManager<tiendaOnlineUser> userManager)
        {
            _carrito = carrito;
            _producto = producto;
            _userManager = userManager;
        }
        [Authorize(Roles ="User")]
        public ViewResult Index()
        {
            var Prod = _carrito.GetprodCarrito();
            _carrito.prodCarrito = Prod;

            var carritoVM = new CarritoVM
            {
                Carrito = _carrito,
                TotalCarrito = _carrito.GetcarritoTotal()
            };
            return View(carritoVM);
        }

        [Authorize(Roles ="User")]
        public async Task<RedirectToActionResult> AgregarCarrito(int idProducto)
        {
            var user = await _userManager.GetUserAsync(User);

            var prodSeleccionado = _producto.Productos.FirstOrDefault(p => p.ProductoID == idProducto);
           
            if (prodSeleccionado != null)
            {
                _carrito.AgregarCarrito(prodSeleccionado, 1);
            }
            return RedirectToAction("Index","Home");
        }

        [Authorize(Roles = "User")]
        public async Task<RedirectToActionResult> EliminarDeCarrito(int idProducto)
        {
            var user = await _userManager.GetUserAsync(User);

            var prodSeleccionado = _producto.Productos.FirstOrDefault(p => p.ProductoID == idProducto);

            if (prodSeleccionado != null)
            {
                _carrito.EliminarDeCarrito(prodSeleccionado);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        public async Task<RedirectToActionResult> EliminarProdDeCarrito(int idProducto)
        {
            var user = await _userManager.GetUserAsync(User);

            var prodSeleccionado = _producto.Productos.FirstOrDefault(p => p.ProductoID == idProducto);

            if (prodSeleccionado != null)
            {
                _carrito.EliminarProdDeCarrito(prodSeleccionado);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        public async Task<RedirectToActionResult> SeleccionarProd(int idProducto)
        {
            var user = await _userManager.GetUserAsync(User);
            var prodSeleccionado = _producto.Productos.FirstOrDefault(p => p.ProductoID == idProducto);
            if (prodSeleccionado != null)
            {
                _carrito.SeleccionarProd(prodSeleccionado);
            }

            return RedirectToAction("Index");
        }
    }
}
