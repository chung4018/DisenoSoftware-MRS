using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class PRODUCTOSController : Controller
    {
		private readonly IPRODUCTOSRepository productosRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PRODUCTOSController() : this(new PRODUCTOSRepository())
        {
        }

        public PRODUCTOSController(IPRODUCTOSRepository productosRepository)
        {
			this.productosRepository = productosRepository;
        }

        //
        // GET: /PRODUCTOS/

        public ViewResult Index()
        {
            return View(productosRepository.AllIncluding(productos => productos.BUSQUEDAS, productos => productos.COMERCIOS));
        }

        //
        // GET: /PRODUCTOS/Details/5

        public ViewResult Details(int id)
        {
            return View(productosRepository.Find(id));
        }

        //
        // GET: /PRODUCTOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PRODUCTOS/Create

        [HttpPost]
        public ActionResult Create(PRODUCTOS productos)
        {
            if (ModelState.IsValid) {
                productosRepository.InsertOrUpdate(productos);
                productosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /PRODUCTOS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(productosRepository.Find(id));
        }

        //
        // POST: /PRODUCTOS/Edit/5

        [HttpPost]
        public ActionResult Edit(PRODUCTOS productos)
        {
            if (ModelState.IsValid) {
                productosRepository.InsertOrUpdate(productos);
                productosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /PRODUCTOS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(productosRepository.Find(id));
        }

        //
        // POST: /PRODUCTOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            productosRepository.Delete(id);
            productosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                productosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

