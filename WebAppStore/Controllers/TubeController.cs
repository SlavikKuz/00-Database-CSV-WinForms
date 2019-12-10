using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppStore.Models;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    public class TubeController : Controller
    {
        private readonly ITubeRepository _tubeRepository;
        private readonly ICategoryRepository _categoryRepository;
        
        public TubeController(ITubeRepository tubeRepository, ICategoryRepository categoryRepository)
        {
            _tubeRepository = tubeRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            TubesListViewModel tubesListViewModel = new TubesListViewModel();
            tubesListViewModel.Tubes = _tubeRepository.Tubes;
            tubesListViewModel.CurrentCategory = "vacuum tubes";

            return View(tubesListViewModel);
        }
        
        
        
        
        
        
        
        // GET: Tube
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tube/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tube/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tube/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tube/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tube/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tube/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tube/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}