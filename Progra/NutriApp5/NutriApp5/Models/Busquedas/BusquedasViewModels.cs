using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriApp5.Models.Busquedas
{
    public class BusquedaViewModel
    {
        public int ID_BUSQUEDA { get; set; }
        public Nullable<int> ID_USUARIO { get; set; }
        public Nullable<System.DateTime> FECHA_HORA { get; set; }
        [Display(Name="Filtro por nombre")]
        public string stringBuscado { get; set; }

        [Required]
        [Display(Name="Seleccione las condiciones")]
        public IEnumerable<int> condicionSelected;
        public IEnumerable<System.Web.Mvc.SelectListItem> arrayCondiciones;

        public int buscarEn;
        public IEnumerable<System.Web.Mvc.SelectListItem> arrayBuscarEn ;

        public ICollection<PRODUCTOS> productosResultados { get; set; }
        public ICollection<COMERCIOS> comerciosResultados { get; set; }

        public virtual USUARIOS USUARIOS { get; set; }
        public virtual ICollection<BUSQUEDAXCOMERCIOS> BUSQUEDAXCOMERCIOS { get; set; }
        public virtual ICollection<BUSQUEDAXPRODUCTOS> BUSQUEDAXPRODUCTOS { get; set; }

        private readonly ICONDICIONRepository condicionRepository = new CONDICIONRepository();
        public BusquedaViewModel()
        {
            this.FECHA_HORA = DateTime.Now.Date;
            this.ID_USUARIO = LoginControl.Instance.idLogedUser;
           
            IEnumerable<CONDICION> condiciones = condicionRepository.All.ToList();

            this.arrayCondiciones = condiciones.Select(x => new System.Web.Mvc.SelectListItem
            {
                Value = x.ID_CONDICION.ToString(),
                Text = x.NOMBRE,
            }).ToList();

            SeleccionObjetoBusqueda comercios = new SeleccionObjetoBusqueda(1, "Comercios");
            SeleccionObjetoBusqueda productos = new SeleccionObjetoBusqueda(2, "Productos");
            ICollection<SeleccionObjetoBusqueda> opcionesBusqueda = new List<SeleccionObjetoBusqueda>();
            opcionesBusqueda.Add(comercios);
            opcionesBusqueda.Add(productos);

            this.arrayBuscarEn = opcionesBusqueda.Select(x => new SelectListItem
            {
                Value = x.idObjeto.ToString(),
                Text = x.nombre,
            }).ToList();
            
        }

        public void addProducts(IEnumerable<int> arrayProductos)
        {

        }

        public void addComercios(IEnumerable<int> arrayComercios)
        {
            
        }
    }

    public class SeleccionObjetoBusqueda
    {
        public int idObjeto { get; set; }
        public string nombre { get; set; }

        public SeleccionObjetoBusqueda(int id, string nombre)
        {
            this.idObjeto = id;
            this.nombre = nombre;
        }
    }
}