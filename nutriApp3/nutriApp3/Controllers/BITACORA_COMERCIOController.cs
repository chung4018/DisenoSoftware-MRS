using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class BITACORA_COMERCIOController : Controller
    {
		private readonly IBITACORA_COMERCIORepository bitacora_comercioRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public BITACORA_COMERCIOController() : this(new BITACORA_COMERCIORepository())
        {
        }

        public BITACORA_COMERCIOController(IBITACORA_COMERCIORepository bitacora_comercioRepository)
        {
			this.bitacora_comercioRepository = bitacora_comercioRepository;
        }

        //
        // GET: /BITACORA_COMERCIO/

        public ViewResult Index()
        {
            return View(bitacora_comercioRepository.All);
        }

        //
        // GET: /BITACORA_COMERCIO/Details/5

        public ViewResult Details(int id)
        {
            return View(bitacora_comercioRepository.Find(id));
        }

        //
        // GET: /BITACORA_COMERCIO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BITACORA_COMERCIO/Create

        [HttpPost]
        public ActionResult Create(BITACORA_COMERCIO bitacora_comercio)
        {
            if (ModelState.IsValid) {
                bitacora_comercioRepository.InsertOrUpdate(bitacora_comercio);
                bitacora_comercioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /BITACORA_COMERCIO/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(bitacora_comercioRepository.Find(id));
        }

        //
        // POST: /BITACORA_COMERCIO/Edit/5

        [HttpPost]
        public ActionResult Edit(BITACORA_COMERCIO bitacora_comercio)
        {
            if (ModelState.IsValid) {
                bitacora_comercioRepository.InsertOrUpdate(bitacora_comercio);
                bitacora_comercioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /BITACORA_COMERCIO/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(bitacora_comercioRepository.Find(id));
        }

        //
        // POST: /BITACORA_COMERCIO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bitacora_comercioRepository.Delete(id);
            bitacora_comercioRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                bitacora_comercioRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

