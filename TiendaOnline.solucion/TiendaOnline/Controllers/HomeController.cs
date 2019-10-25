using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Data;
using TiendaOnline.Data.Interfaces;
using TiendaOnline.Models;
using TiendaOnline.ViewModels;

namespace TiendaOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoria _categoria;
        private readonly IProducto _producto;

        public HomeController(ICategoria categoria, IProducto producto)
        {
            _categoria = categoria;
            _producto = producto;
        }
        
        public ViewResult Index()
        {
            //ViewBag para pasar datos del controlador a la vista
            ViewBag.Nombre = "Esto esta en el controlador ;)";
            var productos = _producto.Productos;

            ListaProductoVM vm = new ListaProductoVM();
            vm.Productos = _producto.Productos;
           // vm.CategoriaSeleccionada = "Categoria de productos";

            return View(vm);
        }



        public IActionResult Categoria()
        {
            var entities = new ApplicationDbContext();

            return View(model: entities.Categoria.ToList());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
