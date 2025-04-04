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
    public class TutorLegalCombsController : Controller
    {
        private readonly BddeudorContext _context;

        public TutorLegalCombsController(BddeudorContext context)
        {
            _context = context;
        }

        // GET: TutorLegalCombs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TutorLegalCombs.ToListAsync());
        }

        // GET: TutorLegalCombs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorLegalComb = await _context.TutorLegalCombs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutorLegalComb == null)
            {
                return NotFound();
            }

            return View(tutorLegalComb);
        }

        // GET: TutorLegalCombs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TutorLegalCombs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreHijo,NombreTutor,ApellidosTutor,Correo,Celular,Cedula,Direccion")] TutorLegalComb tutorLegalComb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutorLegalComb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tutorLegalComb);
        }

        // GET: TutorLegalCombs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorLegalComb = await _context.TutorLegalCombs.FindAsync(id);
            if (tutorLegalComb == null)
            {
                return NotFound();
            }
            return View(tutorLegalComb);
        }

        // POST: TutorLegalCombs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreHijo,NombreTutor,ApellidosTutor,Correo,Celular,Cedula,Direccion")] TutorLegalComb tutorLegalComb)
        {
            if (id != tutorLegalComb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutorLegalComb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorLegalCombExists(tutorLegalComb.Id))
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
            return View(tutorLegalComb);
        }

        // GET: TutorLegalCombs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorLegalComb = await _context.TutorLegalCombs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutorLegalComb == null)
            {
                return NotFound();
            }

            return View(tutorLegalComb);
        }

        // POST: TutorLegalCombs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tutorLegalComb = await _context.TutorLegalCombs.FindAsync(id);
            if (tutorLegalComb != null)
            {
                _context.TutorLegalCombs.Remove(tutorLegalComb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorLegalCombExists(int id)
        {
            return _context.TutorLegalCombs.Any(e => e.Id == id);
        }
    }
}
