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
        private readonly IPRODUCTOSRepository productosRepository = new PRODUCTOSRepository();
        private readonly IPRODUCTOSXCOMERCIORepository productosXcomercioRepository = new PRODUCTOSXCOMERCIORepository();

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
            comercioEdit.selectedUser = 1;
            comercioEdit.AllUSERS = usuarios.Select(x => new SelectListItem
            {
                Value = x.ID_USUARIO.ToString(),
                Text = x.NOMBRE+" "+x.APELLIDO,
            }).ToList();

            ICollection<PRODUCTOS> productos = productosRepository.All.ToList();
            comercioEdit.AllPRODUCTOS = productos.Select(x => new SelectListItem
            {
                Value = x.ID_PRODUCTO.ToString(),
                Text = x.NOMBRE,
            }).ToList();

            return View(comercioEdit);
        } 

        //
        // POST: /COMERCIOS/Create

        [HttpPost]
        public ActionResult Create(createEditComercios comercio)
        {
           // if (ModelState.IsValid) {
                COMERCIOS comercioInsert = new COMERCIOS();

              //  comercioInsert.ID_COMERCIO = comercio.ID_COMERCIO;
                comercioInsert.ID_USUARIO = comercio.selectedUser;
                comercioInsert.NOMBRE = comercio.NOMBRE;
                comercioInsert.LATITUD = comercio.LATITUD;
                comercioInsert.LONGUITUD = comercio.LONGUITUD;
                comercioInsert.TELEFONO = comercio.TELEFONO;
                comercioInsert.CORREO = comercio.CORREO;

                comerciosRepository.InsertOrUpdate(comercioInsert);
                comerciosRepository.Save();

                foreach (var producto in comercio.SelectedPRODUCTOS)
                {
                    PRODUCTOSXCOMERCIO insertProducto = new PRODUCTOSXCOMERCIO();
                    insertProducto.ID_PRODUCTO = Int32.Parse(String.Concat(producto));
                    int comercioInsertID = comerciosRepository.getLastNumber();
                        //comerciosRepository.Find(comercio.ID_COMERCIO);
                    insertProducto.ID_COMERCIO = comercioInsertID;

                    productosXcomercioRepository.InsertOrUpdate(insertProducto);
                    productosXcomercioRepository.Save();
                }

                
                return RedirectToAction("Index");
           /* } else {
				return View();
			}*/
        }
        
        //
        // GET: /COMERCIOS/Edit/5
 
        public ActionResult Edit(int id)
        {
            createEditComercios comercioEdit = new createEditComercios();
            COMERCIOS comercioAeditar = comerciosRepository.Find(id);

            comercioEdit.ID_COMERCIO = comercioAeditar.ID_COMERCIO;
            comercioEdit.selectedUser = comercioAeditar.ID_USUARIO;
            comercioEdit.NOMBRE = comercioAeditar.NOMBRE;
            comercioEdit.LATITUD = comercioAeditar.LATITUD;
            comercioEdit.LONGUITUD = comercioAeditar.LONGUITUD;
            comercioEdit.TELEFONO = comercioAeditar.TELEFONO;
            comercioEdit.CORREO = comercioAeditar.CORREO;

            comercioAeditar.PRODUCTOS = comerciosRepository.productosComercio(comercioAeditar.ID_COMERCIO);
            
            comercioEdit.SelectedPRODUCTOS = comercioAeditar.PRODUCTOS.Select(x => x.ID_PRODUCTO);
            ICollection<PRODUCTOS> productos = productosRepository.All.ToList();

            comercioEdit.AllPRODUCTOS = productos.Select(x => new SelectListItem
            {
                Value = x.ID_PRODUCTO.ToString(),
                Text = x.NOMBRE,
            }).ToList();


            ICollection<USUARIOS> usuarios = usuariosRepository.All.ToList();

            comercioEdit.selectedUser = comercioAeditar.ID_USUARIO;
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
            //if (ModelState.IsValid) {
                COMERCIOS comercioEdit = new COMERCIOS();

                comercioEdit.ID_COMERCIO = comercio.ID_COMERCIO;
                comercioEdit.ID_USUARIO = comercio.selectedUser;
                comercioEdit.NOMBRE = comercio.NOMBRE;
                comercioEdit.LATITUD = comercio.LATITUD;
                comercioEdit.LONGUITUD = comercio.LONGUITUD;
                comercioEdit.TELEFONO = comercio.TELEFONO;
                comercioEdit.CORREO = comercio.CORREO;

                productosXcomercioRepository.DeleteAllProductosComercio(comercio.ID_COMERCIO);

                foreach (var producto in comercio.SelectedPRODUCTOS)
                {
                    PRODUCTOSXCOMERCIO insertProducto = new PRODUCTOSXCOMERCIO();
                    insertProducto.ID_PRODUCTO = Int32.Parse(String.Concat(producto));
                    insertProducto.ID_COMERCIO = comercio.ID_COMERCIO;

                    productosXcomercioRepository.InsertOrUpdate(insertProducto);
                    productosXcomercioRepository.Save();
                }

                comerciosRepository.InsertOrUpdate(comercioEdit);
                comerciosRepository.Save();
                return RedirectToAction("Index");
           /* } else {
				return View();
			}*/
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

