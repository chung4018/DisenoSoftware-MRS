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
        [HttpPost]
        public ActionResult Index(BusquedaViewModel model)
        {
            if (ModelState.IsValid)
            {
                /* IEnumerable<CONDICION> condiciones = condicionRepository.All.ToList();
           
                 model.arrayCondiciones = condiciones.Select(x => new SelectListItem
                 {
                     Value = x.ID_CONDICION.ToString(),
                     Text = x.NOMBRE,
                 }).ToList();

                 SeleccionObjetoBusqueda comerciosOPT = new SeleccionObjetoBusqueda(1, "Comercios"); 
                 SeleccionObjetoBusqueda productosOPT = new SeleccionObjetoBusqueda(2, "Productos");
                 ICollection<SeleccionObjetoBusqueda> opcionesBusqueda = new List<SeleccionObjetoBusqueda>();
                 opcionesBusqueda.Add(comerciosOPT);
                 opcionesBusqueda.Add(productosOPT);

                 model.arrayBuscarEn = opcionesBusqueda.Select(x => new SelectListItem
                 {
                     Value = x.idObjeto.ToString(),
                     Text = x.nombre,
                 }).ToList();*/
                //se realiza la busqueda segun los parametros dados
                //si la busqueda es de comercios se buscan los que sigan lo definido por el usuario

                if (model.buscarEn == 1)//Indica que busca comercios
                {
                    IQueryable<COMERCIOS> comercios = comerciosRepository.All;
                    foreach (var comercio in comercios)
                    {
                        bool hasSelected = false;
                        model.comerciosResultados.Add(comercio);
                        //filtra los comercios que tienen productos con el filtro dado 
                        foreach (var tipo in model.condicionSelected)
                        {
                            comerciosRepository.hasProductosByCondition(comercio.ID_COMERCIO, tipo);
                            hasSelected = true;
                        }
                        if (hasSelected)
                        {
                            if (!model.stringBuscado.Equals(""))
                            {

                            }
                            else
                            {
                                model.comerciosResultados.Add(comercio);
                            }
                        }

                    }


                }
                else if (model.buscarEn == 2)//indica que busca productos
                {
                    //model.comerciosResultados.Add(comercio);
                }
                
            }
            else
            {
               
            }

            return View("RealizarBusqueda",model);
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

