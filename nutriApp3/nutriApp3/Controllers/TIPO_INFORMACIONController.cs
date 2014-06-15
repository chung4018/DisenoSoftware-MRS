using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class TIPO_INFORMACIONController : Controller
    {
		private readonly ITIPO_INFORMACIONRepository tipo_informacionRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TIPO_INFORMACIONController() : this(new TIPO_INFORMACIONRepository())
        {
        }

        public TIPO_INFORMACIONController(ITIPO_INFORMACIONRepository tipo_informacionRepository)
        {
			this.tipo_informacionRepository = tipo_informacionRepository;
        }

        //
        // GET: /TIPO_INFORMACION/

        public ViewResult Index()
        {
            return View(tipo_informacionRepository.AllIncluding(tipo_informacion => tipo_informacion.NOTICIAS));
        }

        //
        // GET: /TIPO_INFORMACION/Details/5

        public ViewResult Details(decimal id)
        {
            return View(tipo_informacionRepository.Find(id));
        }

        //
        // GET: /TIPO_INFORMACION/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TIPO_INFORMACION/Create

        [HttpPost]
        public ActionResult Create(TIPO_INFORMACION tipo_informacion)
        {
            if (ModelState.IsValid) {
                tipo_informacionRepository.InsertOrUpdate(tipo_informacion);
                tipo_informacionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /TIPO_INFORMACION/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(tipo_informacionRepository.Find(id));
        }

        //
        // POST: /TIPO_INFORMACION/Edit/5

        [HttpPost]
        public ActionResult Edit(TIPO_INFORMACION tipo_informacion)
        {
            if (ModelState.IsValid) {
                tipo_informacionRepository.InsertOrUpdate(tipo_informacion);
                tipo_informacionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /TIPO_INFORMACION/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(tipo_informacionRepository.Find(id));
        }

        //
        // POST: /TIPO_INFORMACION/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tipo_informacionRepository.Delete(id);
            tipo_informacionRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                tipo_informacionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

