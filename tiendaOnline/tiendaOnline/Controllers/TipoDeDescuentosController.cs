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
    public class TipoDeDescuentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDeDescuentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeDescuentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TipoDeDescuento.Include(t => t.producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TipoDeDescuentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeDescuento = await _context.TipoDeDescuento
                .Include(t => t.producto)
                .FirstOrDefaultAsync(m => m.TipoDeDescuentoID == id);
            if (tipoDeDescuento == null)
            {
                return NotFound();
            }

            return View(tipoDeDescuento);
        }

        // GET: TipoDeDescuentos/Create
        public IActionResult Create()
        {
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo");
            return View();
        }

        // POST: TipoDeDescuentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDeDescuentoID,nombreDelDescuento,montoDeDescuento,porcentajeDeDescuento,ProductoID")] TipoDeDescuento tipoDeDescuento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeDescuento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", tipoDeDescuento.ProductoID);
            return View(tipoDeDescuento);
        }

        // GET: TipoDeDescuentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeDescuento = await _context.TipoDeDescuento.FindAsync(id);
            if (tipoDeDescuento == null)
            {
                return NotFound();
            }
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", tipoDeDescuento.ProductoID);
            return View(tipoDeDescuento);
        }

        // POST: TipoDeDescuentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDeDescuentoID,nombreDelDescuento,montoDeDescuento,porcentajeDeDescuento,ProductoID")] TipoDeDescuento tipoDeDescuento)
        {
            if (id != tipoDeDescuento.TipoDeDescuentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeDescuento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeDescuentoExists(tipoDeDescuento.TipoDeDescuentoID))
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
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", tipoDeDescuento.ProductoID);
            return View(tipoDeDescuento);
        }

        // GET: TipoDeDescuentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeDescuento = await _context.TipoDeDescuento
                .Include(t => t.producto)
                .FirstOrDefaultAsync(m => m.TipoDeDescuentoID == id);
            if (tipoDeDescuento == null)
            {
                return NotFound();
            }

            return View(tipoDeDescuento);
        }

        // POST: TipoDeDescuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeDescuento = await _context.TipoDeDescuento.FindAsync(id);
            _context.TipoDeDescuento.Remove(tipoDeDescuento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeDescuentoExists(int id)
        {
            return _context.TipoDeDescuento.Any(e => e.TipoDeDescuentoID == id);
        }
    }
}
