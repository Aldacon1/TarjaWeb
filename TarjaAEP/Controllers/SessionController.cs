using TarjaAEP.Tools;

namespace TarjaAEP.Controllers
{
    #region Usings
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Security;
    #endregion
    public class SessionController : Controller
    {
        #region Métodos Genéricos
        /// <summary>
        /// Limpieza de variables de sesión
        /// </summary>
        [HttpPost]
        public void CleanSession()
        {
            //Se recorren las variables de sesión
            for (var i = Session.Keys.Count - 1; i >= 0; i--)
            {
                //Se limpian todas las variables que no comiencen con 'Global:'
                if (!Session.Keys[i].StartsWith("Global:"))
                    Session.RemoveAt(i);
            }
        }

        /// <summary>
        /// Cambio del lenguaje de la aplicación
        /// </summary>
        /// <param name="culture"></param>
        public void SwitchLanguage(string culture)
        {
            //Se carga el código de cultura en sesión
            Session["Global:Lenguaje"] = culture;

            //Se establece la nueva cultura para el sistema
            var cultureInfo = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }

        /// <summary>
        /// Finalización de una sesión
        /// </summary>
        public ActionResult CerrarSession()
        {
            Session.Clear(); //Elimina la sesión
            Session.Abandon(); //Abandona la sesión
            string cookieKey = Response.Cookies["ckUserSAAM"].Equals(null) ? User.Identity.Name : Request.Cookies["ckUserSAAM"].Value;

            Singleton.RepositoryUsers.Remove(Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name));

            if (Response.Cookies["ckUserSAAM"] != null) Response.Cookies["ckUserSAAM"].Expires = DateTime.Now.AddDays(-366);
            FormsAuthentication.SignOut(); //Finaliza la sesión de formulario
            Singleton.ShowNotification("¡Hasta Pronto!", "Su sesión ha finalizado con éxito", Singleton.ToastrType.Information);
            return RedirectToAction("Login", "Home");
        }
        #endregion
    }
}