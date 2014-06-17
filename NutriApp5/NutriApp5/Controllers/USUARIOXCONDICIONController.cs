using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class USUARIOXCONDICIONController : Controller
    {
		private readonly IUSUARIOXCONDICIONRepository usuarioxcondicionRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public USUARIOXCONDICIONController() : this(new USUARIOXCONDICIONRepository())
        {
        }

        public USUARIOXCONDICIONController(IUSUARIOXCONDICIONRepository usuarioxcondicionRepository)
        {
			this.usuarioxcondicionRepository = usuarioxcondicionRepository;
        }

        //
        // GET: /USUARIOXCONDICION/

        public ViewResult Index()
        {
            return View(usuarioxcondicionRepository.All);
        }

        //
        // GET: /USUARIOXCONDICION/Details/5

        public ViewResult Details(int id)
        {
            return View(usuarioxcondicionRepository.Find(id));
        }

        //
        // GET: /USUARIOXCONDICION/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /USUARIOXCONDICION/Create

        [HttpPost]
        public ActionResult Create(USUARIOXCONDICION usuarioxcondicion)
        {
            if (ModelState.IsValid) {
                usuarioxcondicionRepository.InsertOrUpdate(usuarioxcondicion);
                usuarioxcondicionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /USUARIOXCONDICION/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(usuarioxcondicionRepository.Find(id));
        }

        //
        // POST: /USUARIOXCONDICION/Edit/5

        [HttpPost]
        public ActionResult Edit(USUARIOXCONDICION usuarioxcondicion)
        {
            if (ModelState.IsValid) {
                usuarioxcondicionRepository.InsertOrUpdate(usuarioxcondicion);
                usuarioxcondicionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /USUARIOXCONDICION/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(usuarioxcondicionRepository.Find(id));
        }

        //
        // POST: /USUARIOXCONDICION/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarioxcondicionRepository.Delete(id);
            usuarioxcondicionRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                usuarioxcondicionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

