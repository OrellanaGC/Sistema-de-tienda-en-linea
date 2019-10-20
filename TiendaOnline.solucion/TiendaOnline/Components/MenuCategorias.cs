using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data.Interfaces;

namespace TiendaOnline.Components
{
    public class MenuCategorias : ViewComponent
    {
        private readonly ICategoria _categoria;
        public MenuCategorias(ICategoria categoria)
        {
            _categoria = categoria;
        }
        public IViewComponentResult Invoke()
        {
            var categorias = _categoria.Categoria.OrderBy(p => p.NombreCategoria);
            return View(categorias);
        }
    }
}
