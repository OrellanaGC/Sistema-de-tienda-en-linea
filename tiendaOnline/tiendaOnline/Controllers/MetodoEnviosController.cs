using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class MetodoEnviosController : Controller
    {
        private readonly UserManager<tiendaOnlineUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;

        public MetodoEnviosController(IHostingEnvironment e, ApplicationDbContext context, UserManager<tiendaOnlineUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            he = e;
        }

        // GET: MetodoEnvios
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetodoEnvio.ToListAsync());
        }

        // GET: MetodoEnvios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoEnvio = await _context.MetodoEnvio
                .FirstOrDefaultAsync(m => m.MetodoEnvioID == id);
            if (metodoEnvio == null)
            {
                return NotFound();
            }

            return View(metodoEnvio);
        }

        // GET: MetodoEnvios/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetodoEnvios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("MetodoEnvioID,nombreMetodoEnvio,maxDiasEnvio,minDiasEnvio,montoEnvio")] MetodoEnvio metodoEnvio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoEnvio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodoEnvio);
        }

        // GET: MetodoEnvios/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoEnvio = await _context.MetodoEnvio.FindAsync(id);
            if (metodoEnvio == null)
            {
                return NotFound();
            }
            return View(metodoEnvio);
        }

        // POST: MetodoEnvios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("MetodoEnvioID,nombreMetodoEnvio,maxDiasEnvio,minDiasEnvio,montoEnvio")] MetodoEnvio metodoEnvio)
        {
            if (id != metodoEnvio.MetodoEnvioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoEnvio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoEnvioExists(metodoEnvio.MetodoEnvioID))
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
            return View(metodoEnvio);
        }

        // GET: MetodoEnvios/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoEnvio = await _context.MetodoEnvio
                .FirstOrDefaultAsync(m => m.MetodoEnvioID == id);
            if (metodoEnvio == null)
            {
                return NotFound();
            }

            return View(metodoEnvio);
        }

        // POST: MetodoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodoEnvio = await _context.MetodoEnvio.FindAsync(id);
            _context.MetodoEnvio.Remove(metodoEnvio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoEnvioExists(int id)
        {
            return _context.MetodoEnvio.Any(e => e.MetodoEnvioID == id);
        }
    }
}
