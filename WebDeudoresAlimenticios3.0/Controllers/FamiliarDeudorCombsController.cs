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
    public class FamiliarDeudorCombsController : Controller
    {
        private readonly BddeudorContext _context;

        public FamiliarDeudorCombsController(BddeudorContext context)
        {
            _context = context;
        }

        // GET: FamiliarDeudorCombs
        public async Task<IActionResult> Index()
        {
            return View(await _context.FamiliarDeudorCombs.ToListAsync());
        }

        // GET: FamiliarDeudorCombs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiarDeudorComb = await _context.FamiliarDeudorCombs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiarDeudorComb == null)
            {
                return NotFound();
            }

            return View(familiarDeudorComb);
        }

        // GET: FamiliarDeudorCombs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamiliarDeudorCombs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreFamiliarDeudor,Parentesco,NombreDeudor,ApellidoDeudor,Direccion,Cedula,Celular")] FamiliarDeudorComb familiarDeudorComb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiarDeudorComb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familiarDeudorComb);
        }

        // GET: FamiliarDeudorCombs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiarDeudorComb = await _context.FamiliarDeudorCombs.FindAsync(id);
            if (familiarDeudorComb == null)
            {
                return NotFound();
            }
            return View(familiarDeudorComb);
        }

        // POST: FamiliarDeudorCombs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreFamiliarDeudor,Parentesco,NombreDeudor,ApellidoDeudor,Direccion,Cedula,Celular")] FamiliarDeudorComb familiarDeudorComb)
        {
            if (id != familiarDeudorComb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiarDeudorComb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliarDeudorCombExists(familiarDeudorComb.Id))
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
            return View(familiarDeudorComb);
        }

        // GET: FamiliarDeudorCombs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiarDeudorComb = await _context.FamiliarDeudorCombs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiarDeudorComb == null)
            {
                return NotFound();
            }

            return View(familiarDeudorComb);
        }

        // POST: FamiliarDeudorCombs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familiarDeudorComb = await _context.FamiliarDeudorCombs.FindAsync(id);
            if (familiarDeudorComb != null)
            {
                _context.FamiliarDeudorCombs.Remove(familiarDeudorComb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliarDeudorCombExists(int id)
        {
            return _context.FamiliarDeudorCombs.Any(e => e.Id == id);
        }
    }
}
