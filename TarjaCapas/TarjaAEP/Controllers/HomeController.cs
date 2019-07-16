using System.Configuration;

namespace TarjaAEP.Controllers
{
    #region Usings
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Tools;
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;
    using CapaBO;
    using CapaBLL;
    #endregion

    [AllowAnonymous]
    public class HomeController : Controller
    {
        #region Carga de vistas principales
        /// <summary>
        /// Vista Login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            //Se obtiene el session id provisto por .NET
            Singleton.SessionId = Session.SessionID;

            //Si el usuario no está autenticado o no hay usuarios en el repositorio, no entra automáticamente
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return View();
            else
            {
                return RedirectToAction("Principal", "Home");
            }
        }

        /// <summary>
        /// Vista Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Principal()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Home");
            else
            {
                return View();
            }
        }
        #endregion


        #region Vista Login
        /// <summary>
        /// Login de usuario
        /// </summary>
        /// <param name="usuario">Rut del usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <param name="dv">Dígito verificador del usuario</param>
        /// <returns></returns>
        public ActionResult ObtIniSes(string usuario, string contrasena, string dv)
        {
            GlobalResponse globalResponse = new GlobalResponse();
            //Se realiza el llamado
            GlobalUser gUser = new GlobalUser();
            LoginBO user = new LoginBLL().sp_sel_loginBLL(Convert.ToInt32(usuario), contrasena);

            gUser.RutUsuario = user.Rut_persona.ToString();
            gUser.DvUsuario = user.Dv_persona.ToString();
            gUser.CodTerminal = user.CodTerminal.ToString();
            gUser.DesTerminal = user.DesTerminal.ToString();
            gUser.NomUsuario = user.Nom_persona.ToString();
            gUser.FuncionUsuario = user.Funcion.ToString();
            if (user.EsValido == "1")
                gUser.esValido = true;


            //Se valida si la respuesta tiene errores
            if (gUser.esValido && !globalResponse.HasError)
            {
                Singleton.UserWeb = usuario;
                //Se inicia sesión de formulario a través de cookies
                FormsAuthentication.SetAuthCookie(usuario, false);
                if (Singleton.RepositoryUsers == null) Singleton.RepositoryUsers = new System.Collections.Generic.List<GlobalUser>();
                if (!Singleton.RepositoryUsers.Exists(u => u.RutUsuario == gUser.RutUsuario)) Singleton.RepositoryUsers.Add(gUser);
                //Se muestra una notificación inicial
                Singleton.ShowNotification("Bienvenido", gUser.NomUsuario, Singleton.ToastrType.Information);
                RedirectToAction("Principal", "Home");
            }
            //Se retorna el resultado
            return Json(new
            {
                //Envío mandatorio para validación de errores en el proceso
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        /// <summary>
        /// Valida la session del usuario
        /// </summary>
        /// <returns></returns>
        public ActionResult ValSession()
        {
            var cookie = Singleton.GetUserRut();
            return Json(new
            {
                Cookie = cookie
            });
        }
        #endregion
    }
}