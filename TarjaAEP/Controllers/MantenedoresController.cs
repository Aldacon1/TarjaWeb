namespace TarjaAEP.Controllers
{
    #region Usings
    using CapaBO;
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Tools;
    #endregion
    [Authorize]
    public class MantenedoresController : Controller
    {
        #region Vistas Principales
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Home");
            else
            {
                return RedirectToAction("Bultos");
            }
        }

        public ActionResult Bultos()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Home");
            else
            {
                return View();
            }
        }

        public ActionResult Clientes()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Home");
            else
            {
                return View();
            }
        }

        public ActionResult Naves()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Home");
            else
            {
                return View();
            }
        }

        public ActionResult Personas()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Home");
            else
            {
                GlobalResponse globalResponse = new GlobalResponse();
                ViewBag.Terminales = new Terminal().ObtTerminales(ref globalResponse);
                ViewBag.Funciones = new Funciones().obtFunciones(ref globalResponse);
                return View();
            }
        }

        public ActionResult Terminales()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Home");
            else
            {
                return View();
            }
        }

        #endregion


        #region Vista Bultos
        [HttpGet]
        public ActionResult obtBultos()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            List<BultosBO> listBultos = new TipoBulto().ObtTiposBultos(ref globalResponse);

            var data = JsonConvert.SerializeObject(listBultos);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarBulto(string codigo, string descripcion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            TipoBulto.GuardarBulto(ref globalResponse, codigo, descripcion);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Bulto ingresado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EliminarBulto(string codigo)
        {
            GlobalResponse globalResponse = new Tools.GlobalResponse();

            TipoBulto.EliminarBulto(ref globalResponse, codigo);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Bulto eliminado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EditarBultos(string codigo)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new TipoBulto().EditarBultos(ref globalResponse, codigo);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarBultoEdit(string codigo, string descripcion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            TipoBulto.GuardarBultoEdit(ref globalResponse, codigo, descripcion);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Bulto modificado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }
        #endregion

        #region Vista Clientes
        [HttpGet]
        public ActionResult obtClientes()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            List<ForwardersBO> listClientes = new Clientes().ObtClientes(ref globalResponse);

            var data = JsonConvert.SerializeObject(listClientes);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarCliente(string rut, string nombre, string password, string mail, string fono)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Models.Clientes.GuardarCliente(ref globalResponse, rut, nombre, password, mail, fono);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Cliente ingresado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EditarCliente(string rut_cliente)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Clientes().EditarCliente(ref globalResponse, rut_cliente);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarCliente(string rut)
        {
            GlobalResponse globalResponse = new Tools.GlobalResponse();

            Models.Clientes.EliminarCliente(ref globalResponse, rut);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Bulto eliminado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult GuardarEditCliente(string rut, string nombre, string mail, string password, string fono)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Models.Clientes.GuardarEditCliente(ref globalResponse, rut, nombre, mail, password, fono);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Cliente modificado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }
        #endregion

        #region Vista Naves
        [HttpGet]
        public ActionResult obtNaves()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            List<NavesBO> listNaves = new Nave().ObtNaves(ref globalResponse);

            var data = JsonConvert.SerializeObject(listNaves);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarNave(string codigo, string descripcion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Nave.GuardarNave(ref globalResponse, codigo, descripcion);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Nave ingresada con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EliminarNave(string codigo)
        {
            GlobalResponse globalResponse = new Tools.GlobalResponse();

            Nave.EliminarNave(ref globalResponse, codigo);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Nave eliminada con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EditarNaves(string codigo)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Nave().EditarNaves(ref globalResponse, codigo);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarNaveEdit(string codigo, string descripcion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Nave.GuardarNaveEdit(ref globalResponse, codigo, descripcion);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Bulto modificado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }
        #endregion

        #region Vista Personas
        [HttpGet]
        public ActionResult obtPersonas()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            List<PersonasBO> listaPersonas = new Personas().ObtPersonas(ref globalResponse, Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name).DesTerminal);

            var data = JsonConvert.SerializeObject(listaPersonas);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarPersona(string rut, string nombre, string password, string terminal, string funcion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Models.Personas.GuardarPersona(ref globalResponse, rut, nombre, password, terminal, funcion);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Persona ingresada con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EditarPersona(string rut_persona)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Personas().EditarPersona(ref globalResponse, rut_persona);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarPersona(string rut)
        {
            GlobalResponse globalResponse = new Tools.GlobalResponse();

            Models.Personas.EliminarPersona(ref globalResponse, rut);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Persona eliminada con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult GuardarEditPersona(string rut, string nombre, string password, string terminal, string funcion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Models.Personas.GuardarEditPersona(ref globalResponse, rut, nombre, password, terminal, funcion);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Persona modificada con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }
        #endregion

        #region Terminales
        [HttpGet]
        public ActionResult obtTerminales()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            List<TerminalesBO> listTerminales = new Terminal().ObtTerminales(ref globalResponse);

            var data = JsonConvert.SerializeObject(listTerminales);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult guardarTerminal(string codigo, string descripcion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Terminal.GuardarTerminal(ref globalResponse, codigo, descripcion);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Terminal ingresado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EliminarTerminal(string codigo)
        {
            GlobalResponse globalResponse = new Tools.GlobalResponse();

            Terminal.EliminarTerminal(ref globalResponse, codigo);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Terminal eliminado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult editarTerminales(string codigo)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Terminal().EditarTerminales(ref globalResponse, codigo);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarTerminalEdit(string codigo, string descripcion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Terminal.GuardarTerminalEdit(ref globalResponse, codigo, descripcion);

            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Terminal modificado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }
        #endregion
    }
}