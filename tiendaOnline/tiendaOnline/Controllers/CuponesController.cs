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
    public class CuponesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuponesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cupones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cupon.Include(c => c.tiendaOnlineUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cupones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cupon = await _context.Cupon
                .Include(c => c.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.CuponID == id);
            if (cupon == null)
            {
                return NotFound();
            }

            return View(cupon);
        }

        // GET: Cupones/Create
        public IActionResult Create()
        {
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Cupones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CuponID,codigoCupon,montoCupon,estadoCupon,fechaCreacion,fechaVencimiento,descripcionCupon,tiendaOnlineUserID")] Cupon cupon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cupon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", cupon.tiendaOnlineUserID);
            return View(cupon);
        }

        // GET: Cupones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cupon = await _context.Cupon.FindAsync(id);
            if (cupon == null)
            {
                return NotFound();
            }
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", cupon.tiendaOnlineUserID);
            return View(cupon);
        }

        // POST: Cupones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CuponID,codigoCupon,montoCupon,estadoCupon,fechaCreacion,fechaVencimiento,descripcionCupon,tiendaOnlineUserID")] Cupon cupon)
        {
            if (id != cupon.CuponID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cupon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuponExists(cupon.CuponID))
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
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", cupon.tiendaOnlineUserID);
            return View(cupon);
        }

        // GET: Cupones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cupon = await _context.Cupon
                .Include(c => c.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.CuponID == id);
            if (cupon == null)
            {
                return NotFound();
            }

            return View(cupon);
        }

        // POST: Cupones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cupon = await _context.Cupon.FindAsync(id);
            _context.Cupon.Remove(cupon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuponExists(int id)
        {
            return _context.Cupon.Any(e => e.CuponID == id);
        }
    }
}
