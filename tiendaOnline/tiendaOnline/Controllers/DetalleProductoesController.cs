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
    public class DetalleProductoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalleProductoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetalleProducto.ToListAsync());
        }

        // GET: DetalleProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleProducto = await _context.DetalleProducto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleProducto == null)
            {
                return NotFound();
            }

            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalleProductoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Talla,Color,PesoKg,Modelo,ProductoId")] DetalleProducto detalleProducto)
        {
            if (ModelState.IsValid)
            {
                detalleProducto.ProductoId = _context.Producto.Last().Id;
                _context.Add(detalleProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Productoes");
            }
            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleProducto = await _context.DetalleProducto.FindAsync(id);
            if (detalleProducto == null)
            {
                return NotFound();
            }
            return View(detalleProducto);
        }

        // POST: DetalleProductoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Talla,Color,PesoKg,Modelo,ProductoId")] DetalleProducto detalleProducto)
        {
            if (id != detalleProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleProductoExists(detalleProducto.Id))
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
            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleProducto = await _context.DetalleProducto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleProducto == null)
            {
                return NotFound();
            }

            return View(detalleProducto);
        }

        // POST: DetalleProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleProducto = await _context.DetalleProducto.FindAsync(id);
            _context.DetalleProducto.Remove(detalleProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleProductoExists(int id)
        {
            return _context.DetalleProducto.Any(e => e.Id == id);
        }
    }
}
