using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class BUSQUEDAXPRODUCTOSController : Controller
    {
		private readonly IBUSQUEDAXPRODUCTOSRepository busquedaxproductosRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public BUSQUEDAXPRODUCTOSController() : this(new BUSQUEDAXPRODUCTOSRepository())
        {
        }

        public BUSQUEDAXPRODUCTOSController(IBUSQUEDAXPRODUCTOSRepository busquedaxproductosRepository)
        {
			this.busquedaxproductosRepository = busquedaxproductosRepository;
        }

        //
        // GET: /BUSQUEDAXPRODUCTOS/

        public ViewResult Index()
        {
            return View(busquedaxproductosRepository.All);
        }

        //
        // GET: /BUSQUEDAXPRODUCTOS/Details/5

        public ViewResult Details(int id)
        {
            return View(busquedaxproductosRepository.Find(id));
        }

        //
        // GET: /BUSQUEDAXPRODUCTOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BUSQUEDAXPRODUCTOS/Create

        [HttpPost]
        public ActionResult Create(BUSQUEDAXPRODUCTOS busquedaxproductos)
        {
            if (ModelState.IsValid) {
                busquedaxproductosRepository.InsertOrUpdate(busquedaxproductos);
                busquedaxproductosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /BUSQUEDAXPRODUCTOS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(busquedaxproductosRepository.Find(id));
        }

        //
        // POST: /BUSQUEDAXPRODUCTOS/Edit/5

        [HttpPost]
        public ActionResult Edit(BUSQUEDAXPRODUCTOS busquedaxproductos)
        {
            if (ModelState.IsValid) {
                busquedaxproductosRepository.InsertOrUpdate(busquedaxproductos);
                busquedaxproductosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /BUSQUEDAXPRODUCTOS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(busquedaxproductosRepository.Find(id));
        }

        //
        // POST: /BUSQUEDAXPRODUCTOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            busquedaxproductosRepository.Delete(id);
            busquedaxproductosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                busquedaxproductosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

