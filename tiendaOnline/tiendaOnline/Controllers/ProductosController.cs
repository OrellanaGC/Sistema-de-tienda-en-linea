using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;

        public ProductosController(IHostingEnvironment e, ApplicationDbContext context)
        {
            _context = context;
            he = e;
        }

        // GET: Productos
        public async Task<IActionResult> Index(string searchString)
        {
            var applicationDbContext = _context.Producto.Include(p => p.DetalleProducto).Include(p => p.Subcategoria);
            //Cuadro de busqueda

            ViewData["CurrentFilter"] = searchString;
            var productos = from p in _context.Producto select p; //recorre todos los items en producto
            
            if (!String.IsNullOrEmpty(searchString))
            {
                //agregar metadata si se modifican los atributos
                productos = productos.Where(p => p.NombreProducto.Contains(searchString) || 
                p.Subcategoria.nombreSubcategoria.Contains(searchString) ||
                p.Subcategoria.Categoria.nombre_categoria.Contains(searchString)                
                );//realiza busqueda por nombre
            }


            return View(await productos.AsNoTracking().ToListAsync());
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.DetalleProducto)
                .Include(p => p.Subcategoria)
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        //Guarda la imagen
        public IActionResult Agrega(IFormFile Imagen)
        {
            if (Imagen != null)
            {
                var fileName = Path.Combine(he.WebRootPath, "images/productos", Path.GetFileName(Imagen.FileName));

                Imagen.CopyTo(new FileStream(fileName, FileMode.Create));
                ViewData["FileLocation"] = "/images/productos/" + Path.GetFileName(Imagen.FileName);
            }
            return View();
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["DetalleProductoID"] = new SelectList(_context.DetalleProducto, "DetalleProductoID", "DetalleProductoID");
            ViewData["SubcategoriaID"] = new SelectList(_context.Subcategoria, "SubcategoriaID", "SubcategoriaID");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoID,NombreProducto,Precio,Existencia,Codigo,Imagen,DetalleProductoID,SubcategoriaID")] Producto producto, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                Agrega(Imagen);
                producto.Imagen = Imagen.FileName;
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DetalleProductoID"] = new SelectList(_context.DetalleProducto, "DetalleProductoID", "DetalleProductoID", producto.DetalleProductoID);
            ViewData["SubcategoriaID"] = new SelectList(_context.Subcategoria, "SubcategoriaID", "SubcategoriaID", producto.SubcategoriaID);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["DetalleProductoID"] = new SelectList(_context.DetalleProducto, "DetalleProductoID", "DetalleProductoID", producto.DetalleProductoID);
            ViewData["SubcategoriaID"] = new SelectList(_context.Subcategoria, "SubcategoriaID", "SubcategoriaID", producto.SubcategoriaID);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoID,NombreProducto,Precio,Existencia,Codigo,Imagen,DetalleProductoID,SubcategoriaID")] Producto producto)
        {
            if (id != producto.ProductoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoID))
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
            //ViewData["FileLocation"] = "/images/productos/" + Path.GetFileName(Imagen.FileName);
            ViewData["DetalleProductoID"] = new SelectList(_context.DetalleProducto, "DetalleProductoID", "DetalleProductoID", producto.DetalleProductoID);
            ViewData["SubcategoriaID"] = new SelectList(_context.Subcategoria, "SubcategoriaID", "SubcategoriaID", producto.SubcategoriaID);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.DetalleProducto)
                .Include(p => p.Subcategoria)
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.ProductoID == id);
        }
    }
}
