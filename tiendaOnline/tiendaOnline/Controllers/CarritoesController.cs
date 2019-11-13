using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Controllers
{
    public class CarritoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carritoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carrito.Include(c => c.prodCarrito).Include(c => c.tiendaOnlineUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Carritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito
                .Include(c => c.prodCarrito)
                .Include(c => c.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.CarritoID == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carritoes/Create
        public IActionResult Create()
        {
            ViewData["prodCarritoID"] = new SelectList(_context.ProdCarrito, "ProdCarritoID", "ProdCarritoID");
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Carritoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarritoID,prodCarritoID,tiendaOnlineUserID")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["prodCarritoID"] = new SelectList(_context.ProdCarrito, "ProdCarritoID", "ProdCarritoID", carrito.prodCarritoID);
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", carrito.tiendaOnlineUserID);
            return View(carrito);
        }

        // GET: Carritoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            ViewData["prodCarritoID"] = new SelectList(_context.ProdCarrito, "ProdCarritoID", "ProdCarritoID", carrito.prodCarritoID);
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", carrito.tiendaOnlineUserID);
            return View(carrito);
        }

        // POST: Carritoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarritoID,prodCarritoID,tiendaOnlineUserID")] Carrito carrito)
        {
            if (id != carrito.CarritoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.CarritoID))
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
            ViewData["prodCarritoID"] = new SelectList(_context.ProdCarrito, "ProdCarritoID", "ProdCarritoID", carrito.prodCarritoID);
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", carrito.tiendaOnlineUserID);
            return View(carrito);
        }

        // GET: Carritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito
                .Include(c => c.prodCarrito)
                .Include(c => c.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.CarritoID == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrito = await _context.Carrito.FindAsync(id);
            _context.Carrito.Remove(carrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
            return _context.Carrito.Any(e => e.CarritoID == id);
        }
    }
}
