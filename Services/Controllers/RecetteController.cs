using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [Route("api/[Controller]")]

    public class RecetteController : Controller
    {
        // GET: Recette

        private readonly ContextRest _context;
        public RecetteController(ContextRest context)
        {
            _context = context;
        }
         
        public List<Recette> GetAllRecettes()
        {
            return _context.recette.ToList();
        }

        // GET: Recette/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Recette/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Recette/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(Recette recette)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Add(recette);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: Recette/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Recette/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Recette/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Recette/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}