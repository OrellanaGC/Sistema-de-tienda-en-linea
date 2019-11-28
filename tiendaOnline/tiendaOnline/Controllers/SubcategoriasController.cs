using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Controllers
{
    public class SubcategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubcategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subcategorias
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subcategoria.Include(s => s.Categoria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subcategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategoria
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(m => m.SubcategoriaID == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // GET: Subcategorias/Create
        [Authorize(Roles = "Seller")]
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "nombre_categoria");
            return View();
        }

        // POST: Subcategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Create([Bind("SubcategoriaID,nombreSubcategoria,CategoriaID")] Subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "nombre_categoria", subcategoria.CategoriaID);
            return View(subcategoria);
        }

        // GET: Subcategorias/Edit/5
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategoria.FindAsync(id);
            if (subcategoria == null)
            {
                return NotFound();
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "nombre_categoria", subcategoria.CategoriaID);
            return View(subcategoria);
        }

        // POST: Subcategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Edit(int id, [Bind("SubcategoriaID,nombreSubcategoria,CategoriaID")] Subcategoria subcategoria)
        {
            if (id != subcategoria.SubcategoriaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoriaExists(subcategoria.SubcategoriaID))
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
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "nombre_categoria", subcategoria.CategoriaID);
            return View(subcategoria);
        }

        // GET: Subcategorias/Delete/5
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategoria
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(m => m.SubcategoriaID == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // POST: Subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategoria = await _context.Subcategoria.FindAsync(id);
            _context.Subcategoria.Remove(subcategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoriaExists(int id)
        {
            return _context.Subcategoria.Any(e => e.SubcategoriaID == id);
        }
    }
}
