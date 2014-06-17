using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class TIPO_COMERCIOController : Controller
    {
		private readonly ITIPO_COMERCIORepository tipo_comercioRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TIPO_COMERCIOController() : this(new TIPO_COMERCIORepository())
        {
        }

        public TIPO_COMERCIOController(ITIPO_COMERCIORepository tipo_comercioRepository)
        {
			this.tipo_comercioRepository = tipo_comercioRepository;
        }

        //
        // GET: /TIPO_COMERCIO/

        public ViewResult Index()
        {
            return View(tipo_comercioRepository.AllIncluding(tipo_comercio => tipo_comercio.COMERCIOS));
        }

        //
        // GET: /TIPO_COMERCIO/Details/5

        public ViewResult Details(decimal id)
        {
            return View(tipo_comercioRepository.Find(id));
        }

        //
        // GET: /TIPO_COMERCIO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TIPO_COMERCIO/Create

        [HttpPost]
        public ActionResult Create(TIPO_COMERCIO tipo_comercio)
        {
            if (ModelState.IsValid) {
                tipo_comercioRepository.InsertOrUpdate(tipo_comercio);
                tipo_comercioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /TIPO_COMERCIO/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(tipo_comercioRepository.Find(id));
        }

        //
        // POST: /TIPO_COMERCIO/Edit/5

        [HttpPost]
        public ActionResult Edit(TIPO_COMERCIO tipo_comercio)
        {
            if (ModelState.IsValid) {
                tipo_comercioRepository.InsertOrUpdate(tipo_comercio);
                tipo_comercioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /TIPO_COMERCIO/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(tipo_comercioRepository.Find(id));
        }

        //
        // POST: /TIPO_COMERCIO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tipo_comercioRepository.Delete(id);
            tipo_comercioRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                tipo_comercioRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

