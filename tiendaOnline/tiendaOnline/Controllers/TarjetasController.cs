﻿using System;
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
    public class TarjetasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<tiendaOnlineUser> _userManager;

        public TarjetasController(ApplicationDbContext context,
            UserManager<tiendaOnlineUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Tarjetas
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Tarjeta.Include(t => t.tiendaOnlineUser);
            //filtro de las direcciones del usuario
            var tarjetas = from t in _context.Tarjeta select t;
            var user = await _userManager.GetUserAsync(User);
            tarjetas = tarjetas.Where(t => t.tiendaOnlineUserID.Contains(user.Id));

            return View(await tarjetas.AsNoTracking().ToListAsync());


            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tarjetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta
                .Include(t => t.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.TarjetaID == id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return View(tarjeta);
        }

        // GET: Tarjetas/Create
        public IActionResult Create()
        {
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Tarjetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarjetaID,numeroTarjeta,codigoSeguridad,tipoTarjeta,titularTarjeta,fechaVencimiento,tiendaOnlineUserID")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var vendedor = _context.DetalleVendedor.Single(d => d.tiendaOnlineUser == user);
                tarjeta.tiendaOnlineUserID = user.Id;
                tarjeta.detalleVendedorID = vendedor.DetalleVendedorID;
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", tarjeta.tiendaOnlineUserID);
            return View(tarjeta);
        }

        // GET: Tarjetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta.FindAsync(id);
            if (tarjeta == null)
            {
                return NotFound();
            }
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", tarjeta.tiendaOnlineUserID);
            return View(tarjeta);
        }

        // POST: Tarjetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarjetaID,numeroTarjeta,codigoSeguridad,tipoTarjeta,titularTarjeta,fechaVencimiento,tiendaOnlineUserID")] Tarjeta tarjeta)
        {
            if (id != tarjeta.TarjetaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarjeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarjetaExists(tarjeta.TarjetaID))
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
            ViewData["tiendaOnlineUserID"] = new SelectList(_context.Users, "Id", "Id", tarjeta.tiendaOnlineUserID);
            return View(tarjeta);
        }

        // GET: Tarjetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta
                .Include(t => t.tiendaOnlineUser)
                .FirstOrDefaultAsync(m => m.TarjetaID == id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return View(tarjeta);
        }

        // POST: Tarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarjeta = await _context.Tarjeta.FindAsync(id);
            _context.Tarjeta.Remove(tarjeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarjetaExists(int id)
        {
            return _context.Tarjeta.Any(e => e.TarjetaID == id);
        }
    }
}
