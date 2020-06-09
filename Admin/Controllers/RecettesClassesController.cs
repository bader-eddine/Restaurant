using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Admin.Models;
using DAL;
using DAL.Entities;

namespace Admin.Controllers
{
    public class RecettesClassesController : Controller
    {
        private readonly ContextRest _context;

        public RecettesClassesController(ContextRest context)
        {
            _context = context;
        }

        // GET: RecettesClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.recette.ToListAsync());
        }

        // GET: RecettesClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recettesClass = await _context.recette
                .FirstOrDefaultAsync(m => m.id == id);
            if (recettesClass == null)
            {
                return NotFound();
            }

            return View(recettesClass);
        }

        // GET: RecettesClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecettesClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titre,recette,description,origine,typeRecette,createdBy,dateAdd,dateModify")] Recette recettesClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recettesClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recettesClass);
        }

        // GET: RecettesClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recettesClass = await _context.recette.FindAsync(id);
            if (recettesClass == null)
            {
                return NotFound();
            }
            return View(recettesClass);
        }

        // POST: RecettesClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,titre,recette,description,origine,typeRecette,createdBy,dateAdd,dateModify")] Recette recettesClass)
        {
            if (id != recettesClass.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recettesClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecettesClassExists(recettesClass.id))
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
            return View(recettesClass);
        }

        // GET: RecettesClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recettesClass = await _context.recette
                .FirstOrDefaultAsync(m => m.id == id);
            if (recettesClass == null)
            {
                return NotFound();
            }

            return View(recettesClass);
        }

        // POST: RecettesClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recettesClass = await _context.recette.FindAsync(id);
            _context.recette.Remove(recettesClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecettesClassExists(int id)
        {
            return _context.recette.Any(e => e.id == id);
        }
    }
}
