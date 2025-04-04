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
    public class AbogadoAsociadoCombsController : Controller
    {
        private readonly BddeudorContext _context;

        public AbogadoAsociadoCombsController(BddeudorContext context)
        {
            _context = context;
        }

        // GET: AbogadoAsociadoCombs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AbogadoAsociadoCombs.ToListAsync());
        }

        // GET: AbogadoAsociadoCombs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abogadoAsociadoComb = await _context.AbogadoAsociadoCombs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abogadoAsociadoComb == null)
            {
                return NotFound();
            }

            return View(abogadoAsociadoComb);
        }

        // GET: AbogadoAsociadoCombs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AbogadoAsociadoCombs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreTutor,NombreAbogado,ApellidosAbogado,Correo,Celular,Cedula,Direccion,NumeroDeCarnet")] AbogadoAsociadoComb abogadoAsociadoComb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abogadoAsociadoComb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abogadoAsociadoComb);
        }

        // GET: AbogadoAsociadoCombs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abogadoAsociadoComb = await _context.AbogadoAsociadoCombs.FindAsync(id);
            if (abogadoAsociadoComb == null)
            {
                return NotFound();
            }
            return View(abogadoAsociadoComb);
        }

        // POST: AbogadoAsociadoCombs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreTutor,NombreAbogado,ApellidosAbogado,Correo,Celular,Cedula,Direccion,NumeroDeCarnet")] AbogadoAsociadoComb abogadoAsociadoComb)
        {
            if (id != abogadoAsociadoComb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abogadoAsociadoComb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbogadoAsociadoCombExists(abogadoAsociadoComb.Id))
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
            return View(abogadoAsociadoComb);
        }

        // GET: AbogadoAsociadoCombs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abogadoAsociadoComb = await _context.AbogadoAsociadoCombs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abogadoAsociadoComb == null)
            {
                return NotFound();
            }

            return View(abogadoAsociadoComb);
        }

        // POST: AbogadoAsociadoCombs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abogadoAsociadoComb = await _context.AbogadoAsociadoCombs.FindAsync(id);
            if (abogadoAsociadoComb != null)
            {
                _context.AbogadoAsociadoCombs.Remove(abogadoAsociadoComb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbogadoAsociadoCombExists(int id)
        {
            return _context.AbogadoAsociadoCombs.Any(e => e.Id == id);
        }
    }
}
