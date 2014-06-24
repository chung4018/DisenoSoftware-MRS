using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class NOTICIASController : Controller
    {
		private readonly INOTICIASRepository noticiasRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public NOTICIASController() : this(new NOTICIASRepository())
        {
        }

        public NOTICIASController(INOTICIASRepository noticiasRepository)
        {
			this.noticiasRepository = noticiasRepository;
        }

        //
        // GET: /NOTICIAS/

        public ViewResult Index()
        {
            return View(noticiasRepository.AllIncluding(noticias => noticias.NOTICIASXCONDICION));
        }

        //
        // GET: /NOTICIAS/Details/5

        public ViewResult Details(int id)
        {
            return View(noticiasRepository.Find(id));
        }

        //
        // GET: /NOTICIAS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /NOTICIAS/Create

        [HttpPost]
        public ActionResult Create(NOTICIAS noticias)
        {
            if (ModelState.IsValid) {
                noticiasRepository.InsertOrUpdate(noticias);
                noticiasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /NOTICIAS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(noticiasRepository.Find(id));
        }

        //
        // POST: /NOTICIAS/Edit/5

        [HttpPost]
        public ActionResult Edit(NOTICIAS noticias)
        {
            if (ModelState.IsValid) {
                noticiasRepository.InsertOrUpdate(noticias);
                noticiasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /NOTICIAS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(noticiasRepository.Find(id));
        }

        //
        // POST: /NOTICIAS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            noticiasRepository.Delete(id);
            noticiasRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                noticiasRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

