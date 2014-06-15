using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class BITACORA_NOTICIASController : Controller
    {
		private readonly IBITACORA_NOTICIASRepository bitacora_noticiasRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public BITACORA_NOTICIASController() : this(new BITACORA_NOTICIASRepository())
        {
        }

        public BITACORA_NOTICIASController(IBITACORA_NOTICIASRepository bitacora_noticiasRepository)
        {
			this.bitacora_noticiasRepository = bitacora_noticiasRepository;
        }

        //
        // GET: /BITACORA_NOTICIAS/

        public ViewResult Index()
        {
            return View(bitacora_noticiasRepository.All);
        }

        //
        // GET: /BITACORA_NOTICIAS/Details/5

        public ViewResult Details(int id)
        {
            return View(bitacora_noticiasRepository.Find(id));
        }

        //
        // GET: /BITACORA_NOTICIAS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BITACORA_NOTICIAS/Create

        [HttpPost]
        public ActionResult Create(BITACORA_NOTICIAS bitacora_noticias)
        {
            if (ModelState.IsValid) {
                bitacora_noticiasRepository.InsertOrUpdate(bitacora_noticias);
                bitacora_noticiasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /BITACORA_NOTICIAS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(bitacora_noticiasRepository.Find(id));
        }

        //
        // POST: /BITACORA_NOTICIAS/Edit/5

        [HttpPost]
        public ActionResult Edit(BITACORA_NOTICIAS bitacora_noticias)
        {
            if (ModelState.IsValid) {
                bitacora_noticiasRepository.InsertOrUpdate(bitacora_noticias);
                bitacora_noticiasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /BITACORA_NOTICIAS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(bitacora_noticiasRepository.Find(id));
        }

        //
        // POST: /BITACORA_NOTICIAS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bitacora_noticiasRepository.Delete(id);
            bitacora_noticiasRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                bitacora_noticiasRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

