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
    public class ProdCarritoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdCarritoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProdCarritoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProdCarrito.Include(p => p.producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProdCarritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCarrito = await _context.ProdCarrito
                .Include(p => p.producto)
                .FirstOrDefaultAsync(m => m.ProdCarritoID == id);
            if (prodCarrito == null)
            {
                return NotFound();
            }

            return View(prodCarrito);
        }

        // GET: ProdCarritoes/Create
        public IActionResult Create()
        {
            ViewData["productoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo");
            return View();
        }

        // POST: ProdCarritoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdCarritoID,cantidadProducto,productoID")] ProdCarrito prodCarrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodCarrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", prodCarrito.productoID);
            return View(prodCarrito);
        }

        // GET: ProdCarritoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCarrito = await _context.ProdCarrito.FindAsync(id);
            if (prodCarrito == null)
            {
                return NotFound();
            }
            ViewData["productoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", prodCarrito.productoID);
            return View(prodCarrito);
        }

        // POST: ProdCarritoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdCarritoID,cantidadProducto,productoID")] ProdCarrito prodCarrito)
        {
            if (id != prodCarrito.ProdCarritoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodCarrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdCarritoExists(prodCarrito.ProdCarritoID))
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
            ViewData["productoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", prodCarrito.productoID);
            return View(prodCarrito);
        }

        // GET: ProdCarritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCarrito = await _context.ProdCarrito
                .Include(p => p.producto)
                .FirstOrDefaultAsync(m => m.ProdCarritoID == id);
            if (prodCarrito == null)
            {
                return NotFound();
            }

            return View(prodCarrito);
        }

        // POST: ProdCarritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodCarrito = await _context.ProdCarrito.FindAsync(id);
            _context.ProdCarrito.Remove(prodCarrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdCarritoExists(int id)
        {
            return _context.ProdCarrito.Any(e => e.ProdCarritoID == id);
        }
    }
}
