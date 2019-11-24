using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Data;
using tiendaOnline.Models;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<tiendaOnlineUser> _userManager;
        private readonly ApplicationDbContext _context; //Para tener acceso a los datos de la base
        public HomeController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context, UserManager<tiendaOnlineUser> userManager)
        {
            this.roleManager = roleManager;
            _context = context; //variable para contexto de la base
            _userManager = userManager;

        }        

        public async Task<IActionResult> Index()
        {
            //Creacion de Roles 
            string[] rolesName = { "Admin", "User", "Seller" };
            IdentityResult result;
            foreach (var roleName in rolesName)
            {
                bool roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var productos = from p in _context.Producto select p; //recorre todos los items en producto
            var user = await _userManager.GetUserAsync(User);
            var vendedor = _context.DetalleVendedor.Single(d => d.tiendaOnlineUser == user);
            if (vendedor != null)
            {
                productos = productos.Where(p => p.detalleVendedor.tiendaOnlineUserID != user.Id);
            }

            return View(await productos.AsNoTracking().ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
