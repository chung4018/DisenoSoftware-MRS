using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class TIPO_PRODUCTOController : Controller
    {
		private readonly ITIPO_PRODUCTORepository tipo_productoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TIPO_PRODUCTOController() : this(new TIPO_PRODUCTORepository())
        {
        }

        public TIPO_PRODUCTOController(ITIPO_PRODUCTORepository tipo_productoRepository)
        {
			this.tipo_productoRepository = tipo_productoRepository;
        }

        //
        // GET: /TIPO_PRODUCTO/

        public ViewResult Index()
        {
            return View(tipo_productoRepository.AllIncluding(tipo_producto => tipo_producto.PRODUCTOS));
        }

        //
        // GET: /TIPO_PRODUCTO/Details/5

        public ViewResult Details(decimal id)
        {
            return View(tipo_productoRepository.Find(id));
        }

        //
        // GET: /TIPO_PRODUCTO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TIPO_PRODUCTO/Create

        [HttpPost]
        public ActionResult Create(TIPO_PRODUCTO tipo_producto)
        {
            if (ModelState.IsValid) {
                tipo_productoRepository.InsertOrUpdate(tipo_producto);
                tipo_productoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /TIPO_PRODUCTO/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(tipo_productoRepository.Find(id));
        }

        //
        // POST: /TIPO_PRODUCTO/Edit/5

        [HttpPost]
        public ActionResult Edit(TIPO_PRODUCTO tipo_producto)
        {
            if (ModelState.IsValid) {
                tipo_productoRepository.InsertOrUpdate(tipo_producto);
                tipo_productoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /TIPO_PRODUCTO/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(tipo_productoRepository.Find(id));
        }

        //
        // POST: /TIPO_PRODUCTO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tipo_productoRepository.Delete(id);
            tipo_productoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                tipo_productoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

