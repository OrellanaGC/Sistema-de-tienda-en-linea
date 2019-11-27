using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tiendaOnline.Areas.Identity.Data;
using tiendaOnline.Data;
using tiendaOnline.Models;

namespace tiendaOnline.Controllers
{
    public class DetalleProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<tiendaOnlineUser> _userManager;

        public DetalleProductosController(ApplicationDbContext context, UserManager<tiendaOnlineUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: DetalleProductos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetalleProducto.Include(d => d.producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalleProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleProducto = await _context.DetalleProducto
                .Include(d => d.producto).Include(d =>d.producto.detalleVendedor)
                .FirstOrDefaultAsync(m => m.productoID == id);
            if (detalleProducto == null)
            {
                return NotFound();
            }

            return View(detalleProducto);
        }

        // GET: DetalleProductos/Create
        public IActionResult Create()
        {                        
            return View();
        }

        // POST: DetalleProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleProductoID,Descripcion,Talla,Color,PesoKg,Marca,Modelo,productoID")] DetalleProducto detalleProducto)
        {
            if (ModelState.IsValid)
            {
                //detalleProducto.productoID = _context.Producto.Last().ProductoID;
                var user = await _userManager.GetUserAsync(User);
                var vendedor = _context.DetalleVendedor.Single(d => d.tiendaOnlineUser == user);                             
                detalleProducto.producto = _context.Producto.Last(p=> p.detalleVendedorID== vendedor.DetalleVendedorID);
                _context.Add(detalleProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexVendedor", "Productos");
            }
            
            return View(detalleProducto);
        }

         //GET: DetalleProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var detalleProducto = await _context.DetalleProducto
                .Include(d => d.producto).Include(d => d.producto.detalleVendedor)
                .FirstOrDefaultAsync(m => m.productoID == id);          
            if (detalleProducto == null)
            {
                return NotFound();
            }            
            return View(detalleProducto);
        }
        
        // POST: DetalleProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleProductoID,Descripcion,Talla,Color,PesoKg,Marca,Modelo,productoID")] DetalleProducto detalleProducto)
        {
            if (id != detalleProducto.productoID)
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
                    if (!DetalleProductoExists(detalleProducto.DetalleProductoID))
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

        // GET: DetalleProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleProducto = await _context.DetalleProducto
                .Include(d => d.producto)
                .FirstOrDefaultAsync(m => m.DetalleProductoID == id);
            if (detalleProducto == null)
            {
                return NotFound();
            }

            return View(detalleProducto);
        }

        // POST: DetalleProductos/Delete/5
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
            return _context.DetalleProducto.Any(e => e.DetalleProductoID == id);
        }
    }
}