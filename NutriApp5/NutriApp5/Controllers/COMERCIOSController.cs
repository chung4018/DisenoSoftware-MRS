using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class COMERCIOSController : Controller
    {
		private readonly ICOMERCIOSRepository comerciosRepository;
        private readonly IUSUARIOSRepository usuariosRepository = new USUARIOSRepository();

		// If you are using Dependency Injection, you can delete the following constructor
        public COMERCIOSController() : this(new COMERCIOSRepository())
        {
        }

        public COMERCIOSController(ICOMERCIOSRepository comerciosRepository)
        {
			this.comerciosRepository = comerciosRepository;
        }

        //
        // GET: /COMERCIOS/

        public ViewResult Index()
        {
            return View(comerciosRepository.AllIncluding(comercios => comercios.BUSQUEDAXCOMERCIOS, comercios => comercios.PRODUCTOSXCOMERCIO));
        }

        //
        // GET: /COMERCIOS/Details/5

        public ViewResult Details(int id)
        {
            return View(comerciosRepository.Find(id));
        }

        //
        // GET: /COMERCIOS/Create

        public ActionResult Create()
        {
            createEditComercios comercioEdit = new createEditComercios();

            ICollection<USUARIOS> usuarios = usuariosRepository.All.ToList();
            comercioEdit.SelectedUsuario = 0;
            comercioEdit.AllUSERS = usuarios.Select(x => new SelectListItem
            {
                Value = x.ID_USUARIO.ToString(),
                Text = x.NOMBRE+x.APELLIDO,
            }).ToList();
            return View(comercioEdit);
        } 

        //
        // POST: /COMERCIOS/Create

        [HttpPost]
        public ActionResult Create(createEditComercios comercio)
        {
            if (ModelState.IsValid) {
                COMERCIOS comercioInsert = new COMERCIOS();

                comercioInsert.ID_COMERCIO = comercio.ID_COMERCIO;
                comercioInsert.ID_USUARIO = int.Parse(String.Concat(comercio.SelectedUsuario));
                comercioInsert.NOMBRE = comercio.NOMBRE;
                comercioInsert.LATITUD = comercio.LATITUD;
                comercioInsert.LONGUITUD = comercio.LONGUITUD;
                comercioInsert.TELEFONO = comercio.TELEFONO;
                comercioInsert.CORREO = comercio.CORREO;

                comerciosRepository.InsertOrUpdate(comercioInsert);
                comerciosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /COMERCIOS/Edit/5
 
        public ActionResult Edit(int id)
        {
            createEditComercios comercioEdit = new createEditComercios();
            COMERCIOS comercioAeditar = comerciosRepository.Find(id);

            comercioEdit.ID_COMERCIO = comercioAeditar.ID_COMERCIO;
            comercioEdit.ID_USUARIO = comercioAeditar.ID_USUARIO;
            comercioEdit.NOMBRE = comercioAeditar.NOMBRE;
            comercioEdit.LATITUD = comercioAeditar.LATITUD;
            comercioEdit.LONGUITUD = comercioAeditar.LONGUITUD;
            comercioEdit.TELEFONO = comercioAeditar.TELEFONO;
            comercioEdit.CORREO = comercioAeditar.CORREO;

            ICollection<USUARIOS> usuarios = usuariosRepository.All.ToList();
            comercioEdit.SelectedUsuario = comercioAeditar.ID_USUARIO;
            comercioEdit.AllUSERS = usuarios.Select(x => new SelectListItem
            {
                Value = x.ID_USUARIO.ToString(),
                Text = x.NOMBRE + x.APELLIDO,
            }).ToList();
            return View(comercioEdit);
        }

        //
        // POST: /COMERCIOS/Edit/5

        [HttpPost]
        public ActionResult Edit(createEditComercios comercio)
        {
            if (ModelState.IsValid) {
                COMERCIOS comercioEdit = new COMERCIOS();

                comercioEdit.ID_COMERCIO = comercio.ID_COMERCIO;
                comercioEdit.ID_USUARIO = comercio.ID_USUARIO;
                comercioEdit.NOMBRE = comercio.NOMBRE;
                comercioEdit.LATITUD = comercio.LATITUD;
                comercioEdit.LONGUITUD = comercio.LONGUITUD;
                comercioEdit.TELEFONO = comercio.TELEFONO;
                comercioEdit.CORREO = comercio.CORREO;

                comerciosRepository.InsertOrUpdate(comercioEdit);
                comerciosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /COMERCIOS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(comerciosRepository.Find(id));
        }

        //
        // POST: /COMERCIOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            comerciosRepository.Delete(id);
            comerciosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                comerciosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

