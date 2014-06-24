using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;
using NutriApp5.Models.Busquedas;

namespace NutriApp5.Controllers
{   
    public class BUSQUEDASController : Controller
    {
		private readonly IBUSQUEDASRepository busquedasRepository;
        private readonly ICONDICIONRepository condicionRepository = new CONDICIONRepository();
        private readonly IPRODUCTOSRepository productosRepository = new PRODUCTOSRepository();
        private readonly ICOMERCIOSRepository comerciosRepository = new COMERCIOSRepository();

		// If you are using Dependency Injection, you can delete the following constructor
        public BUSQUEDASController() : this(new BUSQUEDASRepository())
        {
        }

        public BUSQUEDASController(IBUSQUEDASRepository busquedasRepository)
        {
			this.busquedasRepository = busquedasRepository;
        }

        //
        // GET: /BUSQUEDAS/

        public ViewResult Index()
        {
            BusquedaViewModel model = new BusquedaViewModel();
           

            return View(model);
        }

        public JsonResult RealizarBusqueda(string stringBuscado, string[] condicionSelected,string buscarEn)
        {
            string HTMLresultado = "<div>";

            BusquedaViewModel model = new BusquedaViewModel();
            model.stringBuscado = stringBuscado;

            //se crea el array de int con los id de las condiciones seleccionadas
            ICollection<int> condicionesSelected = new List<int>();
            
            foreach(var stringId in condicionSelected)
            {
                try
                {
                    condicionesSelected.Add(Int32.Parse(stringId));
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            model.condicionSelected = condicionesSelected;
            model.buscarEn = Int32.Parse(buscarEn);// se convierte el identificador del tipo de busqueda realizado
            
            if (model.buscarEn == 1)//Indica que busca comercios
                {
                    model.comerciosResultados = new List<COMERCIOS>();
                   // model.stringBuscado = "EN COMERCIOS";
                    IQueryable<COMERCIOS> comercios = comerciosRepository.All;
                    foreach (var comercio in comercios)
                    {
                        bool hasSelected = false;
                        if (model.condicionSelected.Count() > 0)
                        {
                            //filtra los comercios que tienen productos con el filtro dado 
                            foreach (var tipo in model.condicionSelected)
                            {
                                hasSelected = comerciosRepository.hasProductosByCondition(comercio.ID_COMERCIO, tipo);

                            }
                        }
                        else
                        {
                            hasSelected = true;
                        }
                        if (hasSelected)
                        {
                            if (!model.stringBuscado.Equals(""))
                            {
                                if (comercio.NOMBRE.IndexOf(model.stringBuscado) != -1)
                                {
                                    model.comerciosResultados.Add(comercio);
                                }
                            }
                            else
                            {
                                model.comerciosResultados.Add(comercio);
                            }
                        }
                    }
                    foreach(var comercioResult in model.comerciosResultados)
                    {
                        HTMLresultado = HTMLresultado + "<div class='resultadoBusquedaItem'><span class='nombre'>Comercio: " + comercioResult.NOMBRE + "</span>"
                            + "<ul><li><span class='correo'>Correo electronico:" + comercioResult.CORREO + "</span></li><li><span class='telefono'>Telefono: " + comercioResult.TELEFONO + "</span></li>"
                            +"<div class='showUbication' nombre='"+comercioResult.NOMBRE+"' latitud='"+comercioResult.LATITUD+"' longitud='"+comercioResult.LONGUITUD+"'>Ver ubicacion</div></div>";
                    }

                }
                else if (model.buscarEn == 2)//indica que busca productos
                {
                    IQueryable<PRODUCTOS> allProductos = productosRepository.All;
                    model.productosResultados = new List<PRODUCTOS>();
                    foreach (var producto in allProductos)
                    {
                        if (condicionesSelected.Count > 0)
                        {
                            foreach (var condicion in model.condicionSelected)
                            {
                                if (producto.ID_TIPO == condicion)
                                    if (!model.stringBuscado.Equals(""))
                                    {
                                        if (producto.NOMBRE.IndexOf(model.stringBuscado) != -1)
                                        {
                                            model.productosResultados.Add(producto);
                                        }
                                    }
                                    else
                                    {
                                        model.productosResultados.Add(producto);
                                    }
                            }
                        }
                        else
                        {
                             if (!model.stringBuscado.Equals(""))
                                    {
                                        if (producto.NOMBRE.IndexOf(model.stringBuscado) != -1)
                                        {
                                            model.productosResultados.Add(producto);
                                        }
                                    }
                             else
                             {
                                 model.productosResultados.Add(producto);
                             }
                        }
                    }
                    foreach (var productoResult in model.productosResultados)
                    {
                        HTMLresultado = HTMLresultado + "<div class='resultadoBusquedaItem'><span class='nombre'>Producto: " + productoResult.NOMBRE + "</span>"
                            + "<ul><li><span class='infoAdicional'>Información Adicional" + productoResult.INFORMACION_ADICIONAL + "</span></li></ul></div>";
;
                    }
                }
            HTMLresultado = HTMLresultado + "</div>";

            return Json(new { message = HTMLresultado }, JsonRequestBehavior.AllowGet);
        }

        
        //
        // GET: /BUSQUEDAS/Details/5

        public ViewResult Details(int id)
        {
            return View(busquedasRepository.Find(id));
        }

        //
        // GET: /BUSQUEDAS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BUSQUEDAS/Create

        [HttpPost]
        public ActionResult Create(BUSQUEDAS busquedas)
        {
            if (ModelState.IsValid) {
                busquedasRepository.InsertOrUpdate(busquedas);
                busquedasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /BUSQUEDAS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(busquedasRepository.Find(id));
        }

        //
        // POST: /BUSQUEDAS/Edit/5

        [HttpPost]
        public ActionResult Edit(BUSQUEDAS busquedas)
        {
            if (ModelState.IsValid) {
                busquedasRepository.InsertOrUpdate(busquedas);
                busquedasRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /BUSQUEDAS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(busquedasRepository.Find(id));
        }

        //
        // POST: /BUSQUEDAS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            busquedasRepository.Delete(id);
            busquedasRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                busquedasRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

