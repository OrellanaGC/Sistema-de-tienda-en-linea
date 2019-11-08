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
    public class TipoDePagoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDePagoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoDePagoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TipoDePago.Include(t => t.Paypal).Include(t => t.Tarjeta).Include(t => t.tiendaOnlineUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TipoDePagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePago = await _context.TipoDePago
                .Include(t => t.Paypal)
                .Include(t => t.Tarjeta)
                .Include(t => t.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.TipoDePagoID == id);
            if (tipoDePago == null)
            {
                return NotFound();
            }

            return View(tipoDePago);
        }

        // GET: TipoDePagoes/Create
        public IActionResult Create()
        {
            ViewData["PaypalID"] = new SelectList(_context.Paypal, "PaypalID", "PaypalID");
            ViewData["TarjetaID"] = new SelectList(_context.Tarjeta, "TarjetaID", "TarjetaID");
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TipoDePagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDePagoID,PaypalID,TarjetaID,tiendaOnlineUserID")] TipoDePago tipoDePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDePago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaypalID"] = new SelectList(_context.Paypal, "PaypalID", "PaypalID", tipoDePago.PaypalID);
            ViewData["TarjetaID"] = new SelectList(_context.Tarjeta, "TarjetaID", "TarjetaID", tipoDePago.TarjetaID);
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", tipoDePago.tiendaOnlineUserID);
            return View(tipoDePago);
        }

        // GET: TipoDePagoes/Edit/5
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
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", tipoDePago.tiendaOnlineUserID);
            return View(tipoDePago);
        }

        // POST: TipoDePagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDePagoID,PaypalID,TarjetaID,tiendaOnlineUserID")] TipoDePago tipoDePago)
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
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", tipoDePago.tiendaOnlineUserID);
            return View(tipoDePago);
        }

        // GET: TipoDePagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePago = await _context.TipoDePago
                .Include(t => t.Paypal)
                .Include(t => t.Tarjeta)
                .Include(t => t.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.TipoDePagoID == id);
            if (tipoDePago == null)
            {
                return NotFound();
            }

            return View(tipoDePago);
        }

        // POST: TipoDePagoes/Delete/5
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
