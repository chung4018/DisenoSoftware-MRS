using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class ROLESXUSUARIOController : Controller
    {
		private readonly IROLESXUSUARIORepository rolesxusuarioRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ROLESXUSUARIOController() : this(new ROLESXUSUARIORepository())
        {
        }

        public ROLESXUSUARIOController(IROLESXUSUARIORepository rolesxusuarioRepository)
        {
			this.rolesxusuarioRepository = rolesxusuarioRepository;
        }

        //
        // GET: /ROLESXUSUARIO/

        public ViewResult Index()
        {
            return View(rolesxusuarioRepository.All);
        }

        //
        // GET: /ROLESXUSUARIO/Details/5

        public ViewResult Details(int id)
        {
            return View(rolesxusuarioRepository.Find(id));
        }

        //
        // GET: /ROLESXUSUARIO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ROLESXUSUARIO/Create

        [HttpPost]
        public ActionResult Create(ROLESXUSUARIO rolesxusuario)
        {
            if (ModelState.IsValid) {
                rolesxusuarioRepository.InsertOrUpdate(rolesxusuario);
                rolesxusuarioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /ROLESXUSUARIO/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(rolesxusuarioRepository.Find(id));
        }

        //
        // POST: /ROLESXUSUARIO/Edit/5

        [HttpPost]
        public ActionResult Edit(ROLESXUSUARIO rolesxusuario)
        {
            if (ModelState.IsValid) {
                rolesxusuarioRepository.InsertOrUpdate(rolesxusuario);
                rolesxusuarioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /ROLESXUSUARIO/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(rolesxusuarioRepository.Find(id));
        }

        //
        // POST: /ROLESXUSUARIO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            rolesxusuarioRepository.Delete(id);
            rolesxusuarioRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                rolesxusuarioRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

