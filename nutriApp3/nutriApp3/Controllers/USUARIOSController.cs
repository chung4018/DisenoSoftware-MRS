using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nutriApp3.Models;

namespace nutriApp3.Controllers
{   
    public class USUARIOSController : Controller
    {
		private readonly IUSUARIOSRepository usuariosRepository;
        private readonly IROLESRepository rolesRepository;
        private Entities db = new Entities();

        public LoginControl loginControl = LoginControl.Instance;
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
            return View(usuariosRepository.AllIncluding(usuarios => usuarios.BUSQUEDAS, usuarios => usuarios.NOTICIAS, usuarios => usuarios.ROLES, usuarios => usuarios.CONDICION));
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
            USUARIOS usuario = usuariosRepository.Find(id);
            IEnumerable selectedValues = null;
            foreach(var rol in usuario.ROLES)
            {
                

            }
            ViewBag.selectedRoles = selectedValues;
            IQueryable rolesApp = rolesRepository.All;
            ViewBag.RolesBag = new MultiSelectList(rolesApp);

             return View(usuario);
        }

        //
        // POST: /USUARIOS/Edit/5

        [HttpPost]
        public ActionResult Edit(USUARIOS usuarios)
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
            try             {
               
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
                ModelState.AddModelError("", "Ocurrió algun error."+EX.Message);
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
            return RedirectToAction("Index","Home");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                usuariosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
       
    }
    
}

