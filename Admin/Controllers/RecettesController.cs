using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using Admin.Helpers;
using Admin.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Admin.Controllers
{
    public class RecettesController : Controller
    {
        RecetteApi _recetteApi = new RecetteApi();
        
        public async Task<IActionResult> Index()
        {
            List<RecetteData> recettesData = new List<RecetteData>();
            HttpClient client = _recetteApi.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Recette");
            if (res.IsSuccessStatusCode)
            {
                var resultats = res.Content.ReadAsStringAsync().Result;
                recettesData = JsonConvert.DeserializeObject<List<RecetteData>>(resultats);

            }
            return View(recettesData);
        }

        // GET: Recettes
        //    public async Task<IActionResult> Index()
        //    {
        //        return View(await _context.recette.ToListAsync());
        //    }

        //    // GET: Recettes/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var recette = await _context.recette
        //            .FirstOrDefaultAsync(m => m.id == id);
        //        if (recette == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(recette);
        //    }

        //    // GET: Recettes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recettes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titre,recette,description,origine,typeRecette,createdBy,dateAdd,dateModify")] Recette recette)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _recetteApi.Initial();
                HttpResponseMessage res = await client.GetAsync("api/Recette");
                return RedirectToAction(nameof(Index));
            }
            return View(recette);
        }

        //    // GET: Recettes/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var recette = await _context.recette.FindAsync(id);
        //        if (recette == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(recette);
        //    }

        //    // POST: Recettes/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("id,titre,recette,description,origine,typeRecette,createdBy,dateAdd,dateModify")] Recette recette)
        //    {
        //        if (id != recette.id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(recette);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!RecetteExists(recette.id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(recette);
        //    }

        //    // GET: Recettes/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var recette = await _context.recette
        //            .FirstOrDefaultAsync(m => m.id == id);
        //        if (recette == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(recette);
        //    }

        //    // POST: Recettes/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var recette = await _context.recette.FindAsync(id);
        //        _context.recette.Remove(recette);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool RecetteExists(int id)
        //    {
        //        return _context.recette.Any(e => e.id == id);
        //    }
    }
}
