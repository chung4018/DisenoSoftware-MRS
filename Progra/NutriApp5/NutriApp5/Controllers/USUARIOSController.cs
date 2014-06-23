using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NutriApp5.Models;
using NutriApp5.Models.Usuarios;

namespace NutriApp5.Controllers
{   
    public class USUARIOSController : Controller
    {
		private readonly IUSUARIOSRepository usuariosRepository;
        private readonly NutriApp5.Models.IROLESRepository rolesRepository = new NutriApp5.Models.ROLESRepository();
        private readonly ICONDICIONRepository condicionRepository = new CONDICIONRepository();
        private Entities db = new Entities();

        private readonly IROLESXUSUARIORepository rolesXusuarioRepository = new ROLESXUSUARIORepository();
        private readonly IUSUARIOXCONDICIONRepository usuarioXcondicionRepository = new USUARIOXCONDICIONRepository();
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
            editUserViewModel model = new editUserViewModel();
            IEnumerable<ROLES> roles = rolesRepository.All.ToList();

            ICollection<CONDICION> condicion = condicionRepository.All.ToList();

            //model.SelectedROLES = new List<decimal> { };
            model.AllROLES = roles.Select(x => new SelectListItem
            {
                Value = x.ID_ROL.ToString(),
                Text = x.NOMBRE,
            }).ToList();

           // userEdit.SelectedCONDICIONES = usuario.CONDICIONES.Select(x => x.ID_CONDICION);
            model.AllCONDICIONES = condicion.Select(x => new SelectListItem
            {
                Value = x.ID_CONDICION.ToString(),
                Text = x.NOMBRE,
            }).ToList();
            return View(model);
        } 

        //
        // POST: /USUARIOS/Create

        [HttpPost]
        public ActionResult Create(editUserViewModel userNewInfo)
        {
            //if (ModelState.IsValid) {
                 USUARIOS users = new USUARIOS();
                 users = (from USUARIOS p in db.USUARIOS
                     where p.CORREO == userNewInfo.CORREO
                     select p).FirstOrDefault();
                 if (users == null)
                 {
                     USUARIOS usuario = new USUARIOS();
                     IEnumerable<ROLES> newRoles = new List<ROLES> { };

                     usuario.ID_USUARIO = userNewInfo.ID_USUARIO;
                     usuario.NOMBRE = userNewInfo.NOMBRE;
                     usuario.APELLIDO = userNewInfo.APELLIDO;
                     usuario.CORREO = userNewInfo.CORREO;
                     usuario.CONTRASENA = userNewInfo.CONTRASENA;

                     //se guarda el usuario
                     usuariosRepository.InsertOrUpdate(usuario);

                     //se eliminan todos los roles del usuario para insertar los nuevos seleccionados
                     rolesXusuarioRepository.DeleteAllRolesUser(usuario.ID_USUARIO);
                     //se recorren los roles que se le han asignado al usuario
                     foreach (var rol in userNewInfo.SelectedROLES)
                     {
                         ROLESXUSUARIO insertRol = new ROLESXUSUARIO();
                         insertRol.ID_ROL = rol;
                         USUARIOS userByEmail = usuariosRepository.getUserByEmail(usuario.CORREO);
                         insertRol.ID_USUARIO = userByEmail.ID_USUARIO;

                         rolesXusuarioRepository.InsertOrUpdate(insertRol);
                         rolesXusuarioRepository.Save();
                     }
                     //se eliminan todos los roles del usuario para insertar los nuevos seleccionados
                     usuarioXcondicionRepository.DeleteAllCondicionesUser(usuario.ID_USUARIO);
                     //se recorren los roles que se le han asignado al usuario
                     foreach (var condicion in userNewInfo.SelectedCONDICIONES)
                     {
                         USUARIOXCONDICION insertCondicion = new USUARIOXCONDICION();
                         insertCondicion.ID_CONDICION = condicion;
                         USUARIOS userByEmail = usuariosRepository.getUserByEmail(usuario.CORREO);
                         insertCondicion.ID_USUARIO = userByEmail.ID_USUARIO;

                         usuarioXcondicionRepository.InsertOrUpdate(insertCondicion);
                         usuarioXcondicionRepository.Save();
                     }

                     usuariosRepository.Save();
                     return RedirectToAction("Index");
                 }
                 else
                 {
                     ModelState.AddModelError("", "Ya existe un usuario con este correo electronico.");
                     return View(userNewInfo);
                 }
        }
        
        //
        // GET: /USUARIOS/Edit/5
 
        public ActionResult Edit(int id)
        {
            USUARIOS usuario = usuariosRepository.Find(id);
            editUserViewModel userEdit = new editUserViewModel();

           ICollection<ROLES> roles = rolesRepository.All.ToList();

           ICollection<CONDICION> condicion = condicionRepository.All.ToList();

            userEdit.ID_USUARIO = usuario.ID_USUARIO;
            userEdit.NOMBRE = usuario.NOMBRE;
            userEdit.APELLIDO = usuario.APELLIDO;
            userEdit.CORREO = userEdit.CORREO;
            userEdit.CONTRASENA = userEdit.CONTRASENA;
            ViewBag.pass = userEdit.CONTRASENA;
            userEdit.SelectedROLES = usuario.ROLES.Select(x => x.ID_ROL);
            userEdit.AllROLES = roles.Select(x => new SelectListItem
            {
                Value = x.ID_ROL.ToString(),
                Text = x.NOMBRE,
            }).ToList();

            userEdit.SelectedCONDICIONES = usuario.CONDICIONES.Select(x => x.ID_CONDICION);
            userEdit.AllCONDICIONES = condicion.Select(x => new SelectListItem
            {
                Value = x.ID_CONDICION.ToString(),
                Text = x.NOMBRE,
            }).ToList();
             return View(userEdit);
        }

        //
        // POST: /USUARIOS/Edit/5

        [HttpPost]
        public ActionResult Edit(editUserViewModel userNewInfo)
        {
            if (ModelState.IsValid) {
                USUARIOS usuario = new USUARIOS();
                ICollection<ROLES> newRoles = new List<ROLES> { };
               
                usuario.ID_USUARIO = userNewInfo.ID_USUARIO;
                usuario.NOMBRE = userNewInfo.NOMBRE;
                usuario.APELLIDO = userNewInfo.APELLIDO;
                usuario.CORREO = userNewInfo.CORREO;
                usuario.CONTRASENA = userNewInfo.CONTRASENA;
                
                //se guarda el usuario
                usuariosRepository.InsertOrUpdate(usuario);

                //se eliminan todos los roles del usuario para insertar los nuevos seleccionados
                rolesXusuarioRepository.DeleteAllRolesUser(usuario.ID_USUARIO);
                //se recorren los roles que se le han asignado al usuario
                foreach (var rol in userNewInfo.SelectedROLES)
                {
                    ROLESXUSUARIO insertRol = new ROLESXUSUARIO();
                    insertRol.ID_ROL = rol;
                    USUARIOS userByEmail = usuariosRepository.getUserByEmail(usuario.CORREO);
                    insertRol.ID_USUARIO = userByEmail.ID_USUARIO;

                    rolesXusuarioRepository.InsertOrUpdate(insertRol);
                    rolesXusuarioRepository.Save();
                }
                //se eliminan todos los roles del usuario para insertar los nuevos seleccionados
                usuarioXcondicionRepository.DeleteAllCondicionesUser(usuario.ID_USUARIO);
                //se recorren los roles que se le han asignado al usuario
                foreach (var condicion in userNewInfo.SelectedCONDICIONES)
                {
                    USUARIOXCONDICION insertCondicion = new USUARIOXCONDICION();
                    insertCondicion.ID_CONDICION = condicion;
                    USUARIOS userByEmail = usuariosRepository.getUserByEmail(usuario.CORREO);
                    insertCondicion.ID_USUARIO = userByEmail.ID_USUARIO;

                    usuarioXcondicionRepository.InsertOrUpdate(insertCondicion);
                    usuarioXcondicionRepository.Save();
                }

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
            rolesXusuarioRepository.DeleteAllRolesUser(id);//se eliminan los roles de la base de datos
            usuarioXcondicionRepository.DeleteAllCondicionesUser(id);
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
                USUARIOS user = (from USUARIOS p in db.USUARIOS
                                  where p.CORREO == model.UserName
                                  select p).FirstOrDefault();
                USUARIOS userInstance = usuariosRepository.Find(user.ID_USUARIO);
                try
                {
                    if (user.CONTRASENA != null)
                    {
                        if (user.CONTRASENA == model.Password)
                        {
                            //            FormsService.SignIn(model.UserName, model.RememberMe);
                            LoginControl log = LoginControl.Instance;
                            log.idLogedUser = userInstance.ID_USUARIO;
                            log.LogedUserName = userInstance.NOMBRE;
                            log.objUsuario = userInstance;
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
            ModeloRegistro modelRegister = new ModeloRegistro();

            ICollection<CONDICION> condicion = condicionRepository.All.ToList();
            modelRegister.AllCONDICIONES = condicion.Select(x => new SelectListItem
            {
                Value = x.ID_CONDICION.ToString(),
                Text = x.NOMBRE,
            }).ToList();
            
            ICollection<ROLES> roles = rolesRepository.All.ToList();
            modelRegister.AllROLES = roles.Select(x => new SelectListItem
            {
                Value = x.ID_ROL.ToString(),
                Text = x.NOMBRE,
            }).ToList();
            return View(modelRegister);
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
                    
                    foreach (var rol in model.SelectedROLES)
                    {
                        ROLESXUSUARIO insertRol = new ROLESXUSUARIO();
                        insertRol.ID_ROL = rol;
                        USUARIOS userByEmail = usuariosRepository.getUserByEmail(user.CORREO);
                        insertRol.ID_USUARIO = userByEmail.ID_USUARIO;

                        rolesXusuarioRepository.InsertOrUpdate(insertRol);
                        rolesXusuarioRepository.Save();
                    }
                    foreach (var condicion in model.SelectedCONDICIONES)
                    {
                        USUARIOXCONDICION insertCondicion = new USUARIOXCONDICION();
                        insertCondicion.ID_CONDICION = condicion;
                        USUARIOS userByEmail = usuariosRepository.getUserByEmail(user.CORREO);
                        insertCondicion.ID_USUARIO = userByEmail.ID_USUARIO;

                        usuarioXcondicionRepository.InsertOrUpdate(insertCondicion);
                        usuarioXcondicionRepository.Save();
                    }

                    
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
            log.objUsuario = null;
            log.LoginActive = false;
            return RedirectToAction("Index", "Home");
        }
    }
}