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
    public class DeudorHijoCombsController : Controller
    {
        private readonly BddeudorContext _context;

        public DeudorHijoCombsController(BddeudorContext context)
        {
            _context = context;
        }

        // GET: DeudorHijoCombs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeudorHijoCombs.ToListAsync());
        }

        // GET: DeudorHijoCombs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudorHijoComb = await _context.DeudorHijoCombs
                .FirstOrDefaultAsync(m => m.IdHijoDeudor == id);
            if (deudorHijoComb == null)
            {
                return NotFound();
            }

            return View(deudorHijoComb);
        }

        // GET: DeudorHijoCombs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeudorHijoCombs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHijoDeudor,PadreDeudor,NombreHijo,Correo,Celular")] DeudorHijoComb deudorHijoComb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deudorHijoComb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deudorHijoComb);
        }

        // GET: DeudorHijoCombs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudorHijoComb = await _context.DeudorHijoCombs.FindAsync(id);
            if (deudorHijoComb == null)
            {
                return NotFound();
            }
            return View(deudorHijoComb);
        }

        // POST: DeudorHijoCombs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHijoDeudor,PadreDeudor,NombreHijo,Correo,Celular")] DeudorHijoComb deudorHijoComb)
        {
            if (id != deudorHijoComb.IdHijoDeudor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deudorHijoComb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeudorHijoCombExists(deudorHijoComb.IdHijoDeudor))
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
            return View(deudorHijoComb);
        }

        // GET: DeudorHijoCombs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deudorHijoComb = await _context.DeudorHijoCombs
                .FirstOrDefaultAsync(m => m.IdHijoDeudor == id);
            if (deudorHijoComb == null)
            {
                return NotFound();
            }

            return View(deudorHijoComb);
        }

        // POST: DeudorHijoCombs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deudorHijoComb = await _context.DeudorHijoCombs.FindAsync(id);
            if (deudorHijoComb != null)
            {
                _context.DeudorHijoCombs.Remove(deudorHijoComb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeudorHijoCombExists(int id)
        {
            return _context.DeudorHijoCombs.Any(e => e.IdHijoDeudor == id);
        }
    }
}
