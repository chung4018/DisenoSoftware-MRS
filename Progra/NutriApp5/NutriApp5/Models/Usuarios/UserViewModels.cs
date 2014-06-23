using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NutriApp5.Models.Usuarios
{
   
    public class ModeloLogin
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }

    public class ModeloRegistro 
    {
        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string APELLIDO { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Formato: email@domain.domain", MinimumLength = 6)]
        [Display(Name = "Correo Electrónico")]
        public string CORREO { get; set; }

        public IEnumerable<decimal> SelectedROLES { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> AllROLES { get; set; }

        public IEnumerable<decimal> SelectedCONDICIONES { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> AllCONDICIONES { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
    public class editUserViewModel
    {
        public int ID_USUARIO { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string APELLIDO { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string CORREO { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string CONTRASENA { get; set; }

        [Compare("CONTRASENA", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Seleccione los roles:")]
        public IEnumerable<decimal> SelectedROLES { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> AllROLES { get; set; }

        [Display(Name = "Seleccione sus condiciones:")]
        public IEnumerable<decimal> SelectedCONDICIONES { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> AllCONDICIONES { get; set; }

    }
}