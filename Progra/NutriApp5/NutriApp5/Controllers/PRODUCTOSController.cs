using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class PRODUCTOSController : Controller
    {
		private readonly IPRODUCTOSRepository productosRepository = new PRODUCTOSRepository();
        private readonly ITIPO_PRODUCTORepository tipoProductosRepository = new TIPO_PRODUCTORepository();

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
            return View(productosRepository.AllIncluding(productos => productos.BUSQUEDAXPRODUCTOS, productos => productos.PRODUCTOSXCOMERCIO));
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
            createEditProductViewModel productEdit = new createEditProductViewModel();

            ICollection<TIPO_PRODUCTO> tiposProductos = tipoProductosRepository.All.ToList();
            productEdit.SelectedTIPO = 0;
            productEdit.AllTIPOS = tiposProductos.Select(x => new SelectListItem
            {
                Value = x.ID_TIPO.ToString(),
                Text = x.NOMBRE,
            }).ToList();
            return View(productEdit);
        } 

        //
        // POST: /PRODUCTOS/Create

        [HttpPost]
        public ActionResult Create(createEditProductViewModel producto)
        {
            if (ModelState.IsValid) {
                PRODUCTOS productoInsert = new PRODUCTOS();

                productoInsert.ID_PRODUCTO = producto.ID_PRODUCTO;
                productoInsert.ID_TIPO = producto.SelectedTIPO;
                productoInsert.NOMBRE = producto.NOMBRE;
                productoInsert.INFORMACION_ADICIONAL = producto.INFORMACION_ADICIONAL;

                productosRepository.InsertOrUpdate(productoInsert);
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
            PRODUCTOS producto = productosRepository.Find(id);

            createEditProductViewModel productEdit = new createEditProductViewModel();

            ICollection<TIPO_PRODUCTO> tiposProductos = tipoProductosRepository.All.ToList();
            productEdit.NOMBRE = producto.NOMBRE;
            productEdit.INFORMACION_ADICIONAL = producto.INFORMACION_ADICIONAL;
            productEdit.ID_PRODUCTO = producto.ID_PRODUCTO;
            productEdit.SelectedTIPO = producto.ID_TIPO;
            productEdit.AllTIPOS = tiposProductos.Select(x => new SelectListItem
            {
                Value = x.ID_TIPO.ToString(),
                Text = x.NOMBRE,
            }).ToList();           
           
             return View(productEdit);
        }

        //
        // POST: /PRODUCTOS/Edit/5

        [HttpPost]
        public ActionResult Edit(createEditProductViewModel producto)
        {
            if (ModelState.IsValid) {
                PRODUCTOS productoInsert = new PRODUCTOS();

                productoInsert.ID_PRODUCTO = producto.ID_PRODUCTO;
                productoInsert.ID_TIPO = producto.SelectedTIPO;
                productoInsert.NOMBRE = producto.NOMBRE;
                productoInsert.INFORMACION_ADICIONAL = producto.INFORMACION_ADICIONAL;

                productosRepository.InsertOrUpdate(productoInsert);
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

