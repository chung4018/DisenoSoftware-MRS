using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class COMERCIOSController : Controller
    {
		private readonly ICOMERCIOSRepository comerciosRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public COMERCIOSController() : this(new COMERCIOSRepository())
        {
        }

        public COMERCIOSController(ICOMERCIOSRepository comerciosRepository)
        {
			this.comerciosRepository = comerciosRepository;
        }

        //
        // GET: /COMERCIOS/

        public ViewResult Index()
        {
            return View(comerciosRepository.AllIncluding(comercios => comercios.BUSQUEDAXCOMERCIOS, comercios => comercios.PRODUCTOSXCOMERCIO));
        }

        //
        // GET: /COMERCIOS/Details/5

        public ViewResult Details(int id)
        {
            return View(comerciosRepository.Find(id));
        }

        //
        // GET: /COMERCIOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /COMERCIOS/Create

        [HttpPost]
        public ActionResult Create(COMERCIOS comercios)
        {
            if (ModelState.IsValid) {
                comerciosRepository.InsertOrUpdate(comercios);
                comerciosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /COMERCIOS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(comerciosRepository.Find(id));
        }

        //
        // POST: /COMERCIOS/Edit/5

        [HttpPost]
        public ActionResult Edit(COMERCIOS comercios)
        {
            if (ModelState.IsValid) {
                comerciosRepository.InsertOrUpdate(comercios);
                comerciosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /COMERCIOS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(comerciosRepository.Find(id));
        }

        //
        // POST: /COMERCIOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            comerciosRepository.Delete(id);
            comerciosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                comerciosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

