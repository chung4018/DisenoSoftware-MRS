using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class BUSQUEDASController : Controller
    {
		private readonly IBUSQUEDASRepository busquedasRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public BUSQUEDASController() : this(new BUSQUEDASRepository())
        {
        }

        public BUSQUEDASController(IBUSQUEDASRepository busquedasRepository)
        {
			this.busquedasRepository = busquedasRepository;
        }

        //
        // GET: /BUSQUEDAS/

        public ViewResult Index()
        {
            return View(busquedasRepository.AllIncluding(busquedas => busquedas.COMERCIOS, busquedas => busquedas.PRODUCTOS));
        }

        //
        // GET: /BUSQUEDAS/Details/5

        public ViewResult Details(int id)
        {
            return View(busquedasRepository.Find(id));
        }

        //
        // GET: /BUSQUEDAS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BUSQUEDAS/Create

        [HttpPost]
        public ActionResult Create(BUSQUEDAS busquedas)
        {
            if (ModelState.IsValid) {
                busquedasRepository.InsertOrUpdate(busquedas);
                busquedasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /BUSQUEDAS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(busquedasRepository.Find(id));
        }

        //
        // POST: /BUSQUEDAS/Edit/5

        [HttpPost]
        public ActionResult Edit(BUSQUEDAS busquedas)
        {
            if (ModelState.IsValid) {
                busquedasRepository.InsertOrUpdate(busquedas);
                busquedasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /BUSQUEDAS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(busquedasRepository.Find(id));
        }

        //
        // POST: /BUSQUEDAS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            busquedasRepository.Delete(id);
            busquedasRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                busquedasRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

