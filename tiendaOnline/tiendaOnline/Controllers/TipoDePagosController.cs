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
    public class TipoDePagosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDePagosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoDePagos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TipoDePago.Include(t => t.Paypal).Include(t => t.Tarjeta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TipoDePagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePago = await _context.TipoDePago
                .Include(t => t.Paypal)
                .Include(t => t.Tarjeta)
                .FirstOrDefaultAsync(m => m.TipoDePagoID == id);
            if (tipoDePago == null)
            {
                return NotFound();
            }

            return View(tipoDePago);
        }

        // GET: TipoDePagos/Create
        public IActionResult Create()
        {
            ViewData["PaypalID"] = new SelectList(_context.Paypal, "PaypalID", "PaypalID");
            ViewData["TarjetaID"] = new SelectList(_context.Tarjeta, "TarjetaID", "TarjetaID");
            return View();
        }

        // POST: TipoDePagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDePagoID,PaypalID,TarjetaID")] TipoDePago tipoDePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDePago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaypalID"] = new SelectList(_context.Paypal, "PaypalID", "PaypalID", tipoDePago.PaypalID);
            ViewData["TarjetaID"] = new SelectList(_context.Tarjeta, "TarjetaID", "TarjetaID", tipoDePago.TarjetaID);
            return View(tipoDePago);
        }

        // GET: TipoDePagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePago = await _context.TipoDePago.FindAsync(id);
            if (tipoDePago == null)
            {
                return NotFound();
            }
            ViewData["PaypalID"] = new SelectList(_context.Paypal, "PaypalID", "PaypalID", tipoDePago.PaypalID);
            ViewData["TarjetaID"] = new SelectList(_context.Tarjeta, "TarjetaID", "TarjetaID", tipoDePago.TarjetaID);
            return View(tipoDePago);
        }

        // POST: TipoDePagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDePagoID,PaypalID,TarjetaID")] TipoDePago tipoDePago)
        {
            if (id != tipoDePago.TipoDePagoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDePago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDePagoExists(tipoDePago.TipoDePagoID))
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
            ViewData["PaypalID"] = new SelectList(_context.Paypal, "PaypalID", "PaypalID", tipoDePago.PaypalID);
            ViewData["TarjetaID"] = new SelectList(_context.Tarjeta, "TarjetaID", "TarjetaID", tipoDePago.TarjetaID);
            return View(tipoDePago);
        }

        // GET: TipoDePagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePago = await _context.TipoDePago
                .Include(t => t.Paypal)
                .Include(t => t.Tarjeta)
                .FirstOrDefaultAsync(m => m.TipoDePagoID == id);
            if (tipoDePago == null)
            {
                return NotFound();
            }

            return View(tipoDePago);
        }

        // POST: TipoDePagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDePago = await _context.TipoDePago.FindAsync(id);
            _context.TipoDePago.Remove(tipoDePago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDePagoExists(int id)
        {
            return _context.TipoDePago.Any(e => e.TipoDePagoID == id);
        }
    }
}
