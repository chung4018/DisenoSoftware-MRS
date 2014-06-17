using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;
using NutriApp5.Models;

namespace NutriApp5.Controllers
{   
    public class USUARIOSController : Controller
    {
		private readonly IUSUARIOSRepository usuariosRepository;
        private readonly NutriApp5.Models.IROLESRepository rolesRepository = new NutriApp5.Models.ROLESRepository();
        private Entities db = new Entities();
		// If you are using Dependency Injection, you can delete the following constructor
        public USUARIOSController() : this(new USUARIOSRepository())
        {
        }

        public USUARIOSController(IUSUARIOSRepository usuariosRepository)
        {
			this.usuariosRepository = usuariosRepository;
        }

        //
        // GET: /USUARIOS/

        public ViewResult Index()
        {
            return View(usuariosRepository.AllIncluding(usuarios => usuarios.BUSQUEDAS, usuarios => usuarios.NOTICIAS, usuarios => usuarios.ROLESXUSUARIO, usuarios => usuarios.USUARIOXCONDICION));
        }

        //
        // GET: /USUARIOS/Details/5

        public ViewResult Details(int id)
        {
            return View(usuariosRepository.Find(id));
        }

        //
        // GET: /USUARIOS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /USUARIOS/Create

        [HttpPost]
        public ActionResult Create(USUARIOS usuarios)
        {
            if (ModelState.IsValid) {
                usuariosRepository.InsertOrUpdate(usuarios);
                usuariosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /USUARIOS/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(usuariosRepository.Find(id));
        }

        //
        // POST: /USUARIOS/Edit/5

        [HttpPost]
        public ActionResult Edit(editUserViewModel userNewInfo)
        {
            if (ModelState.IsValid) {
                USUARIOS usuario = new USUARIOS();
                ICollection<ROLES> newRoles = new List<ROLES> { };
                //se generan los roles que han sido seleccionados por el usuario
                foreach (var rol in userNewInfo.SelectedROLES)
                {
                    newRoles.Add(rolesRepository.Find(rol));
                }

                usuario.ID_USUARIO = userNewInfo.ID_USUARIO;
                usuario.NOMBRE = userNewInfo.NOMBRE;
                usuario.APELLIDO = userNewInfo.APELLIDO;
                usuario.CORREO = userNewInfo.CORREO;
                usuario.CONTRASENA = userNewInfo.CONTRASENA;
                usuario.ROLES = newRoles;

                usuariosRepository.InsertOrUpdate(usuario);
                usuariosRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /USUARIOS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(usuariosRepository.Find(id));
        }

        //
        // POST: /USUARIOS/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            usuariosRepository.Delete(id);
            usuariosRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                usuariosRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Login(ModeloLogin model)
        {
            if (ModelState.IsValid)
            {
                USUARIOS users = (from USUARIOS p in db.USUARIOS
                                  where p.CORREO == model.UserName
                                  select p).FirstOrDefault();

                try
                {
                    if (users.CONTRASENA != null)
                    {
                        if (users.CONTRASENA == model.Password)
                        {
                            //            FormsService.SignIn(model.UserName, model.RememberMe);
                            LoginControl log = LoginControl.Instance;
                            log.idLogedUser = users.ID_USUARIO;
                            log.LogedUserName = users.NOMBRE;
                            log.LoginActive = true;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "El nombre de usuario o contraseña es incorrecta.");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario no existe.");
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "El nombre de usuario o contraseña es incorrecta.");
                    return View(model);
                }

            } return View(model);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
            //return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ModeloRegistro model)
        {
            USUARIOS users = new USUARIOS();
            users = (from USUARIOS p in db.USUARIOS
                     where p.CORREO == model.CORREO
                     select p).FirstOrDefault();
            int ind = 0;
            try
            {

                if (users == null)
                {
                    ind = 1;
                    USUARIOS user = new USUARIOS();
                    user.ID_USUARIO = default(short);
                    user.NOMBRE = model.NOMBRE;
                    user.APELLIDO = model.APELLIDO;
                    user.CONTRASENA = model.password;
                    user.CORREO = model.CORREO;
                    usuariosRepository.InsertOrUpdate(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Ya existe un usuario con este correo electronico.");
                }
            }
            catch (Exception EX)
            {
                ModelState.AddModelError("", "Ocurrió algun error." + EX.Message);
            }

            return View(model);

        }
        [HttpPost]
        public ActionResult logOff()
        {
            LoginControl log = LoginControl.Instance;
            log.idLogedUser = 0;
            log.LogedUserName = "";
            log.LoginActive = false;
            return RedirectToAction("Index", "Home");
        }
    }
}

