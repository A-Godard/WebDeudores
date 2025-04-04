using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDeudoresAlimenticios3._0.Models;

namespace WebDeudoresAlimenticios3._0.Controllers
{
    public class DeudorsController : Controller
    {
        private readonly BddeudorContext _context;

        public DeudorsController(BddeudorContext context)
        {
            _context = context;
        }

        // GET: Deudors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deudors.ToListAsync());
        }

        // GET: Deudors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudor = await _context.Deudors
                .FirstOrDefaultAsync(m => m.IdDeudor == id);
            if (deudor == null)
            {
                return NotFound();
            }

            return View(deudor);
        }

        // GET: Deudors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deudors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDeudor,Nombres,Apellidos,Direccion,Cedula,Celular,MesesMora,Activo")] Deudor deudor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deudor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deudor);
        }

        // GET: Deudors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudor = await _context.Deudors.FindAsync(id);
            if (deudor == null)
            {
                return NotFound();
            }
            return View(deudor);
        }

        // POST: Deudors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDeudor,Nombres,Apellidos,Direccion,Cedula,Celular,MesesMora,Activo")] Deudor deudor)
        {
            if (id != deudor.IdDeudor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deudor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeudorExists(deudor.IdDeudor))
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
            return View(deudor);
        }

        // GET: Deudors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudor = await _context.Deudors
                .FirstOrDefaultAsync(m => m.IdDeudor == id);
            if (deudor == null)
            {
                return NotFound();
            }

            return View(deudor);
        }

        // POST: Deudors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deudor = await _context.Deudors.FindAsync(id);
            if (deudor != null)
            {
                _context.Deudors.Remove(deudor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeudorExists(int id)
        {
            return _context.Deudors.Any(e => e.IdDeudor == id);
        }
    }
}
