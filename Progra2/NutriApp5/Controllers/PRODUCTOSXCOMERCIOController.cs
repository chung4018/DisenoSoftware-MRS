using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class PRODUCTOSXCOMERCIOController : Controller
    {
		private readonly IPRODUCTOSXCOMERCIORepository productosxcomercioRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PRODUCTOSXCOMERCIOController() : this(new PRODUCTOSXCOMERCIORepository())
        {
        }

        public PRODUCTOSXCOMERCIOController(IPRODUCTOSXCOMERCIORepository productosxcomercioRepository)
        {
			this.productosxcomercioRepository = productosxcomercioRepository;
        }

        //
        // GET: /PRODUCTOSXCOMERCIO/

        public ViewResult Index()
        {
            return View(productosxcomercioRepository.All);
        }

        //
        // GET: /PRODUCTOSXCOMERCIO/Details/5

        public ViewResult Details(int id)
        {
            return View(productosxcomercioRepository.Find(id));
        }

        //
        // GET: /PRODUCTOSXCOMERCIO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PRODUCTOSXCOMERCIO/Create

        [HttpPost]
        public ActionResult Create(PRODUCTOSXCOMERCIO productosxcomercio)
        {
            if (ModelState.IsValid) {
                productosxcomercioRepository.InsertOrUpdate(productosxcomercio);
                productosxcomercioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /PRODUCTOSXCOMERCIO/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(productosxcomercioRepository.Find(id));
        }

        //
        // POST: /PRODUCTOSXCOMERCIO/Edit/5

        [HttpPost]
        public ActionResult Edit(PRODUCTOSXCOMERCIO productosxcomercio)
        {
            if (ModelState.IsValid) {
                productosxcomercioRepository.InsertOrUpdate(productosxcomercio);
                productosxcomercioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /PRODUCTOSXCOMERCIO/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(productosxcomercioRepository.Find(id));
        }

        //
        // POST: /PRODUCTOSXCOMERCIO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            productosxcomercioRepository.Delete(id);
            productosxcomercioRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                productosxcomercioRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

