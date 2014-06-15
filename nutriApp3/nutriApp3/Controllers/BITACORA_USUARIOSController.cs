using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class BITACORA_USUARIOSController : Controller
    {
		private readonly IBITACORA_USUARIOSRepository bitacora_usuariosRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public BITACORA_USUARIOSController() : this(new BITACORA_USUARIOSRepository())
        {
        }

        public BITACORA_USUARIOSController(IBITACORA_USUARIOSRepository bitacora_usuariosRepository)
        {
			this.bitacora_usuariosRepository = bitacora_usuariosRepository;
        }

        //
        // GET: /BITACORA_USUARIOS/

        public ViewResult Index()
        {
            return View(bitacora_usuariosRepository.All);
        }

        //
        // GET: /BITACORA_USUARIOS/Details/5

        public ViewResult Details(int id)
        {
            return View(bitacora_usuariosRepository.Find(id));
        }

        //
        // GET: /BITACORA_USUARIOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BITACORA_USUARIOS/Create

        [HttpPost]
        public ActionResult Create(BITACORA_USUARIOS bitacora_usuarios)
        {
            if (ModelState.IsValid) {
                bitacora_usuariosRepository.InsertOrUpdate(bitacora_usuarios);
                bitacora_usuariosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /BITACORA_USUARIOS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(bitacora_usuariosRepository.Find(id));
        }

        //
        // POST: /BITACORA_USUARIOS/Edit/5

        [HttpPost]
        public ActionResult Edit(BITACORA_USUARIOS bitacora_usuarios)
        {
            if (ModelState.IsValid) {
                bitacora_usuariosRepository.InsertOrUpdate(bitacora_usuarios);
                bitacora_usuariosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /BITACORA_USUARIOS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(bitacora_usuariosRepository.Find(id));
        }

        //
        // POST: /BITACORA_USUARIOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bitacora_usuariosRepository.Delete(id);
            bitacora_usuariosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                bitacora_usuariosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

