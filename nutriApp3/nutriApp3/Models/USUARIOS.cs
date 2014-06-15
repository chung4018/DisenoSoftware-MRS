//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using nutriApp3.Models.Usuarios.Roles;

namespace nutriApp3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class USUARIOS
    {
        public USUARIOS()
        {
            this.BUSQUEDAS = new HashSet<BUSQUEDAS>();
            this.NOTICIAS = new HashSet<NOTICIAS>();
            this.ROLES = new HashSet<ROLES>();
            this.CONDICION = new HashSet<CONDICION>();

            this.generaRolesUsuario();//se crean los roles de acuerdo al patr�n jugador Rol.
        }
        [Key]
        public int ID_USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CORREO { get; set; }
        public string CONTRASENA { get; set; }
        public ICollection<RolUsuario> RolesUsuario{ get; set;}
    
        public virtual ICollection<BUSQUEDAS> BUSQUEDAS { get; set; }
        public virtual ICollection<NOTICIAS> NOTICIAS { get; set; }
        public virtual ICollection<ROLES> ROLES { get; set; }
        public virtual ICollection<CONDICION> CONDICION { get; set; }

        private void generaRolesUsuario()
        {
            foreach(var rol in this.ROLES)
            {
                RolUsuario newRol;
                switch (rol.NOMBRE)
                {
                    case "Administrador Plataforma":
                        newRol = new AdministradorPlataforma();
                        break;
                    case "Administrador Comercio":
                        newRol = new AdministradorComercio();
                        break;
                    case "Partner":
                        newRol = new Partner();
                        break;
                    default:
                        newRol = new Comun();
                        break;
                }
                this.RolesUsuario.Add(newRol);
            }
        }

    }

    public class ModeloLogin
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contrase�a")]
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
        [Display(Name = "Correo Electr�nico")]
        public string CORREO { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El n�mero de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contrase�a")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contrase�a")]
        [Compare("password", ErrorMessage = "La contrase�a y la contrase�a de confirmaci�n no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}