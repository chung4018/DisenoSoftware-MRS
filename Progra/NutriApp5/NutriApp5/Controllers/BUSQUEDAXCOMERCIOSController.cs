using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class BUSQUEDAXCOMERCIOSController : Controller
    {
		private readonly IBUSQUEDAXCOMERCIOSRepository busquedaxcomerciosRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public BUSQUEDAXCOMERCIOSController() : this(new BUSQUEDAXCOMERCIOSRepository())
        {
        }

        public BUSQUEDAXCOMERCIOSController(IBUSQUEDAXCOMERCIOSRepository busquedaxcomerciosRepository)
        {
			this.busquedaxcomerciosRepository = busquedaxcomerciosRepository;
        }

        //
        // GET: /BUSQUEDAXCOMERCIOS/

        public ViewResult Index()
        {
            return View(busquedaxcomerciosRepository.All);
        }

        //
        // GET: /BUSQUEDAXCOMERCIOS/Details/5

        public ViewResult Details(int id)
        {
            return View(busquedaxcomerciosRepository.Find(id));
        }

        //
        // GET: /BUSQUEDAXCOMERCIOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BUSQUEDAXCOMERCIOS/Create

        [HttpPost]
        public ActionResult Create(BUSQUEDAXCOMERCIOS busquedaxcomercios)
        {
            if (ModelState.IsValid) {
                busquedaxcomerciosRepository.InsertOrUpdate(busquedaxcomercios);
                busquedaxcomerciosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /BUSQUEDAXCOMERCIOS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(busquedaxcomerciosRepository.Find(id));
        }

        //
        // POST: /BUSQUEDAXCOMERCIOS/Edit/5

        [HttpPost]
        public ActionResult Edit(BUSQUEDAXCOMERCIOS busquedaxcomercios)
        {
            if (ModelState.IsValid) {
                busquedaxcomerciosRepository.InsertOrUpdate(busquedaxcomercios);
                busquedaxcomerciosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /BUSQUEDAXCOMERCIOS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(busquedaxcomerciosRepository.Find(id));
        }

        //
        // POST: /BUSQUEDAXCOMERCIOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            busquedaxcomerciosRepository.Delete(id);
            busquedaxcomerciosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                busquedaxcomerciosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

