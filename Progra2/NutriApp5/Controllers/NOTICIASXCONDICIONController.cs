using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class NOTICIASXCONDICIONController : Controller
    {
		private readonly INOTICIASXCONDICIONRepository noticiasxcondicionRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public NOTICIASXCONDICIONController() : this(new NOTICIASXCONDICIONRepository())
        {
        }

        public NOTICIASXCONDICIONController(INOTICIASXCONDICIONRepository noticiasxcondicionRepository)
        {
			this.noticiasxcondicionRepository = noticiasxcondicionRepository;
        }

        //
        // GET: /NOTICIASXCONDICION/

        public ViewResult Index()
        {
            return View(noticiasxcondicionRepository.All);
        }

        //
        // GET: /NOTICIASXCONDICION/Details/5

        public ViewResult Details(int id)
        {
            return View(noticiasxcondicionRepository.Find(id));
        }

        //
        // GET: /NOTICIASXCONDICION/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /NOTICIASXCONDICION/Create

        [HttpPost]
        public ActionResult Create(NOTICIASXCONDICION noticiasxcondicion)
        {
            if (ModelState.IsValid) {
                noticiasxcondicionRepository.InsertOrUpdate(noticiasxcondicion);
                noticiasxcondicionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /NOTICIASXCONDICION/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(noticiasxcondicionRepository.Find(id));
        }

        //
        // POST: /NOTICIASXCONDICION/Edit/5

        [HttpPost]
        public ActionResult Edit(NOTICIASXCONDICION noticiasxcondicion)
        {
            if (ModelState.IsValid) {
                noticiasxcondicionRepository.InsertOrUpdate(noticiasxcondicion);
                noticiasxcondicionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /NOTICIASXCONDICION/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(noticiasxcondicionRepository.Find(id));
        }

        //
        // POST: /NOTICIASXCONDICION/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            noticiasxcondicionRepository.Delete(id);
            noticiasxcondicionRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                noticiasxcondicionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

