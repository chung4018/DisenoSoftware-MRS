using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NutriApp5.Models.Productos
{
    public class createEditProductViewModel
    {
        public int ID_PRODUCTO { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }
        [Required]
        [Display(Name = "Información adicional")]
        public string INFORMACION_ADICIONAL { get; set; }
        [Required]
        [Display(Name = "Seleccione el tipo de producto")]
        public Nullable<decimal> SelectedTIPO { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> AllTIPOS { get; set; }
    }
}