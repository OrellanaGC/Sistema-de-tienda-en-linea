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
    public class DescuentosController : Controller
    {
        private readonly UserManager<tiendaOnlineUser> _userManager;

        private readonly ApplicationDbContext _context;

        public DescuentosController(ApplicationDbContext context, UserManager<tiendaOnlineUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Descuentos
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var vendedor = _context.DetalleVendedor.Single(d => d.tiendaOnlineUser == user);


            var applicationDbContext = _context.Descuento.Include(d => d.producto).Where(d => d.producto.detalleVendedorID==vendedor.DetalleVendedorID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Descuentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuento = await _context.Descuento
                .Include(d => d.producto)
                .FirstOrDefaultAsync(m => m.DescuentoID == id);
            if (descuento == null)
            {
                return NotFound();
            }

            return View(descuento);
        }

        // GET: Descuentos/Create
        public IActionResult Create()
        {
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo");
            return View();
        }

        // POST: Descuentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescuentoID,NombreDelDescuento,TipoDeDescuento,MontoDeDescuento,PrecioConDesc,ProductoID")] Descuento descuento)
        {
            double desc = descuento.MontoDeDescuento;
            foreach (var producto in _context.Producto)
            {  
                if(descuento.ProductoID == producto.ProductoID)
                {
                    if(descuento.TipoDeDescuento == true)
                    {
                       
                        descuento.PrecioConDesc = producto.PrecioUnitario *(1-(desc*0.01));
                    } else
                    {
                        descuento.PrecioConDesc = producto.PrecioUnitario - desc;
                    }
                }
                 
            }
            if (ModelState.IsValid)
            {
                _context.Add(descuento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", descuento.ProductoID);
            return View(descuento);
        }

        // GET: Descuentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuento = await _context.Descuento.FindAsync(id);
            if (descuento == null)
            {
                return NotFound();
            }
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", descuento.ProductoID);
            return View(descuento);
        }

        // POST: Descuentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescuentoID,NombreDelDescuento,TipoDeDescuento,MontoDeDescuento,PrecioConDesc,ProductoID")] Descuento descuento)
        {
            if (id != descuento.DescuentoID)
            {
                return NotFound();
            }
            double desc = descuento.MontoDeDescuento;
            descuento.EstaActivo = true;
            foreach (var producto in _context.Producto)
            {
                if (descuento.ProductoID == producto.ProductoID)
                {
                    if (descuento.TipoDeDescuento == true)
                    {

                        descuento.PrecioConDesc = producto.PrecioUnitario * (1 - (desc * 0.01));
                    }
                    else
                    {
                        descuento.PrecioConDesc = producto.PrecioUnitario - desc;
                    }
                }

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descuento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescuentoExists(descuento.DescuentoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("IndexVendedor", "Productos");
               
            }
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "Codigo", descuento.ProductoID);
            return View(descuento);
        }

        
        //Para Desactivar desde el index
        public async Task<RedirectToActionResult> ActivarDescuento(int id)
        {
            var descSeleccionado = _context.Descuento.FirstOrDefault(d => d.DescuentoID == id);

                descSeleccionado.EstaActivo = false;
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: Descuentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuento = await _context.Descuento
                .Include(d => d.producto)
                .FirstOrDefaultAsync(m => m.DescuentoID == id);
            if (descuento == null)
            {
                return NotFound();
            }

            return View(descuento);
        }



        // POST: Descuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var descuento = await _context.Descuento.FindAsync(id);
            _context.Descuento.Remove(descuento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescuentoExists(int id)
        {
            return _context.Descuento.Any(e => e.DescuentoID == id);
        }
    }
}
