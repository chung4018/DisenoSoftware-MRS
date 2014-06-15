using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class ROLESController : Controller
    {
		private readonly IROLESRepository rolesRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ROLESController() : this(new ROLESRepository())
        {
        }

        public ROLESController(IROLESRepository rolesRepository)
        {
			this.rolesRepository = rolesRepository;
        }

        //
        // GET: /ROLES/

        public ViewResult Index()
        {
            return View(rolesRepository.AllIncluding(roles => roles.USUARIOS));
        }

        //
        // GET: /ROLES/Details/5

        public ViewResult Details(decimal id)
        {
            return View(rolesRepository.Find(id));
        }

        //
        // GET: /ROLES/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ROLES/Create

        [HttpPost]
        public ActionResult Create(ROLES roles)
        {
            if (ModelState.IsValid) {
                rolesRepository.InsertOrUpdate(roles);
                rolesRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /ROLES/Edit/5
 
        public ActionResult Edit(decimal id)
        {
             return View(rolesRepository.Find(id));
        }

        //
        // POST: /ROLES/Edit/5

        [HttpPost]
        public ActionResult Edit(ROLES roles)
        {
            if (ModelState.IsValid) {
                rolesRepository.InsertOrUpdate(roles);
                rolesRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /ROLES/Delete/5
 
        public ActionResult Delete(decimal id)
        {
            return View(rolesRepository.Find(id));
        }

        //
        // POST: /ROLES/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            rolesRepository.Delete(id);
            rolesRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                rolesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

