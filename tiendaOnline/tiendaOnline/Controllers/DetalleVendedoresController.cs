using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Areas.Identity.Data;
using tiendaOnline.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Controllers
{
    public class DetalleVendedoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<tiendaOnlineUser> _userManager;

        public DetalleVendedoresController(ApplicationDbContext context,
            UserManager<tiendaOnlineUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: DetalleVendedores
        public async Task<IActionResult> Index()
        {
            //Filtrar solo los detalles del vendedor que ha iniciado sesion
            var user = await _userManager.GetUserAsync(User);
            var vendedor = _context.DetalleVendedor.Single(v=> v.tiendaOnlineUserID== user.Id);
            var applicationDbContext = _context.DetalleVendedor.Include(d => d.tiendaOnlineUser).Where(d=> d.DetalleVendedorID== vendedor.DetalleVendedorID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalleVendedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVendedor = await _context.DetalleVendedor
                .Include(d => d.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.DetalleVendedorID == id);
            if (detalleVendedor == null)
            {
                return NotFound();
            }

            return View(detalleVendedor);
        }

        // GET: DetalleVendedores/Create
        public IActionResult Create()
        {
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: DetalleVendedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleVendedorID,nombreComercial,correoComercial,tipoVendedor,tiendaOnlineUserID")] DetalleVendedor detalleVendedor)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                detalleVendedor.tiendaOnlineUserID = user.Id;
                _context.Add(detalleVendedor);
                await _context.SaveChangesAsync();                
                await _userManager.AddToRoleAsync(user, "Seller");
                return RedirectToAction(nameof(Index));
            }
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Email", detalleVendedor.tiendaOnlineUserID);
            return View(detalleVendedor);
        }

        // GET: DetalleVendedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVendedor = await _context.DetalleVendedor.FindAsync(id);
            if (detalleVendedor == null)
            {
                return NotFound();
            }
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", detalleVendedor.tiendaOnlineUserID);
            return View(detalleVendedor);
        }

        // POST: DetalleVendedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleVendedorID,nombreComercial,correoComercial,tipoVendedor,tiendaOnlineUserID")] DetalleVendedor detalleVendedor)
        {
            if (id != detalleVendedor.DetalleVendedorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleVendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVendedorExists(detalleVendedor.DetalleVendedorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", detalleVendedor.tiendaOnlineUserID);
            return View(detalleVendedor);
        }

        // GET: DetalleVendedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVendedor = await _context.DetalleVendedor
                .Include(d => d.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.DetalleVendedorID == id);
            if (detalleVendedor == null)
            {
                return NotFound();
            }

            return View(detalleVendedor);
        }

        // POST: DetalleVendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleVendedor = await _context.DetalleVendedor.FindAsync(id);
            _context.DetalleVendedor.Remove(detalleVendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleVendedorExists(int id)
        {
            return _context.DetalleVendedor.Any(e => e.DetalleVendedorID == id);
        }
    }
}
