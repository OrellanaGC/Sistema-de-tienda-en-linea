using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Areas.Identity.Data;
using tiendaOnline.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Controllers
{
    public class ProductosController : Controller
    {
        private readonly UserManager<tiendaOnlineUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;


        public ProductosController(IHostingEnvironment e, ApplicationDbContext context, UserManager<tiendaOnlineUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            he = e;
        }

        // GET: Productos       
         public async Task<IActionResult> Index(string searchString)
        {

            //var applicationDbContext = _context.Producto.Include(p => p.Subcategoria).Include(p => p.detalleVendedor).Include(p => p.detalleVendedor.tiendaOnlineUser);
            //Cuadro de busqueda

            ViewData["CurrentFilter"] = searchString;
            var productos = from p in _context.Producto select p; //recorre todos los items en producto

            if (!String.IsNullOrEmpty(searchString))
            {
                //agregar metadata si se modifican los atributos
                //agregar metadata si se modifican los atributos
                productos = productos.Where(p => p.NombreProducto.Contains(searchString) ||
                p.Subcategoria.nombreSubcategoria.Contains(searchString) ||
                p.Subcategoria.Categoria.nombre_categoria.Contains(searchString)
                );//realiza busqueda por nombre
            }
            //muestra los productos que no son del vendedor logeado
            var user = await _userManager.GetUserAsync(User);
            var vendedor = _context.DetalleVendedor.Single(d => d.tiendaOnlineUser == user);
            if (vendedor!=null)
            {
                productos = productos.Where(p => p.detalleVendedor.tiendaOnlineUserID!= user.Id);
            }



            return View(await productos.AsNoTracking().ToListAsync());
            //return View(await applicationDbContext.ToListAsync());
        }

        //Visualizar productos propios de cada vendedor
        public async Task<IActionResult> IndexVendedor(string searchString)
        {
            var user = await _userManager.GetUserAsync(User);
            var vendedor = _context.DetalleVendedor.Single(d => d.tiendaOnlineUser == user);
            var applicationDbContext = _context.Producto.Include(p => p.Subcategoria).Include(p => p.detalleVendedor);
            //Cuadro de busqueda

            ViewData["CurrentFilter"] = searchString;
            var productos = from p in _context.Producto.Where(p => p.detalleVendedorID == vendedor.DetalleVendedorID) select p; //recorre todos los items en producto

            if (!String.IsNullOrEmpty(searchString))
            {
                //agregar metadata si se modifican los atributos
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
                .Include(p => p.Subcategoria)
                .Include(p => p.detalleVendedor)
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        //Metodo Json para llenar el select de subcategorias en la vista
        public async Task<JsonResult> SubCate(int idcat)
        {
            List<Subcategoria> subcats = await this._context.Subcategoria.Where(c => c.CategoriaID == idcat).ToListAsync();
            ViewData["SUB"] = new SelectList(subcats, "SubcategoriaID", "nombreSubcategoria");
            return new JsonResult(subcats);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "nombre_categoria");
                                
            return View();
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
        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoID,NombreProducto,PrecioUnitario,Existencia,Codigo,Imagen,SubcategoriaID,detalleVendedorID")] Producto producto, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                
                Agrega(Imagen);
                producto.Imagen = Imagen.FileName;
                //generador random de codigo
                var chars = Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", 10);
                var randomStr = new string(chars.SelectMany(str => str)
                                                .OrderBy(c => Guid.NewGuid())
                                                .Take(10).ToArray());
                //setzy codiguito wapo
                producto.Codigo = randomStr;

                //Asignando el producto al vendedor que ha iniciado sesion
                var user = await _userManager.GetUserAsync(User);
                var vendedor = _context.DetalleVendedor.Single(d => d.tiendaOnlineUser == user);
                producto.detalleVendedorID = vendedor.DetalleVendedorID;
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "DetalleProductos");

            }
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "nombre_categoria");
            ViewData["detalleVendedorID"] = new SelectList(_context.DetalleVendedor, "DetalleVendedorID", "correoComercial", producto.detalleVendedorID);
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
            ViewData["SubcategoriaID"] = new SelectList(_context.Subcategoria, "SubcategoriaID", "nombreSubcategoria", producto.SubcategoriaID);
            ViewData["detalleVendedorID"] = new SelectList(_context.DetalleVendedor, "DetalleVendedorID", "correoComercial", producto.detalleVendedorID);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoID,NombreProducto,PrecioUnitario,Existencia,Codigo,Imagen,SubcategoriaID,detalleVendedorID")] Producto producto)
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
                    return RedirectToAction("Index", "Productos");
                   
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
                
            }
            ViewData["SubcategoriaID"] = new SelectList(_context.Subcategoria, "SubcategoriaID", "nombreSubcategoria", producto.SubcategoriaID);
            ViewData["detalleVendedorID"] = new SelectList(_context.DetalleVendedor, "DetalleVendedorID", "correoComercial", producto.detalleVendedorID);
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
                .Include(p => p.Subcategoria)
                .Include(p => p.detalleVendedor)
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