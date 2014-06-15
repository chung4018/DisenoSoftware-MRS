using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class CONDICIONController : Controller
    {
		private readonly ICONDICIONRepository condicionRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CONDICIONController() : this(new CONDICIONRepository())
        {
        }

        public CONDICIONController(ICONDICIONRepository condicionRepository)
        {
			this.condicionRepository = condicionRepository;
        }

        //
        // GET: /CONDICION/

        public ViewResult Index()
        {
            return View(condicionRepository.All);
        }

        //
        // GET: /CONDICION/Details/5

        public ViewResult Details(decimal id)
        {
            return View(condicionRepository.Find(id));
        }

        //
        // GET: /CONDICION/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CONDICION/Create

        [HttpPost]
        public ActionResult Create(CONDICION condicion)
        {
            if (ModelState.IsValid) {
                condicionRepository.InsertOrUpdate(condicion);
                condicionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /CONDICION/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(condicionRepository.Find(id));
        }

        //
        // POST: /CONDICION/Edit/5

        [HttpPost]
        public ActionResult Edit(CONDICION condicion)
        {
            if (ModelState.IsValid) {
                condicionRepository.InsertOrUpdate(condicion);
                condicionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /CONDICION/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(condicionRepository.Find(id));
        }

        //
        // POST: /CONDICION/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            condicionRepository.Delete(id);
            condicionRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                condicionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

