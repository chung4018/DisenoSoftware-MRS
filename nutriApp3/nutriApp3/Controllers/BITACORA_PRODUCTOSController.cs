using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class BITACORA_PRODUCTOSController : Controller
    {
		private readonly IBITACORA_PRODUCTOSRepository bitacora_productosRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public BITACORA_PRODUCTOSController() : this(new BITACORA_PRODUCTOSRepository())
        {
        }

        public BITACORA_PRODUCTOSController(IBITACORA_PRODUCTOSRepository bitacora_productosRepository)
        {
			this.bitacora_productosRepository = bitacora_productosRepository;
        }

        //
        // GET: /BITACORA_PRODUCTOS/

        public ViewResult Index()
        {
            return View(bitacora_productosRepository.All);
        }

        //
        // GET: /BITACORA_PRODUCTOS/Details/5

        public ViewResult Details(int id)
        {
            return View(bitacora_productosRepository.Find(id));
        }

        //
        // GET: /BITACORA_PRODUCTOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BITACORA_PRODUCTOS/Create

        [HttpPost]
        public ActionResult Create(BITACORA_PRODUCTOS bitacora_productos)
        {
            if (ModelState.IsValid) {
                bitacora_productosRepository.InsertOrUpdate(bitacora_productos);
                bitacora_productosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /BITACORA_PRODUCTOS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(bitacora_productosRepository.Find(id));
        }

        //
        // POST: /BITACORA_PRODUCTOS/Edit/5

        [HttpPost]
        public ActionResult Edit(BITACORA_PRODUCTOS bitacora_productos)
        {
            if (ModelState.IsValid) {
                bitacora_productosRepository.InsertOrUpdate(bitacora_productos);
                bitacora_productosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /BITACORA_PRODUCTOS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(bitacora_productosRepository.Find(id));
        }

        //
        // POST: /BITACORA_PRODUCTOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bitacora_productosRepository.Delete(id);
            bitacora_productosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                bitacora_productosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

