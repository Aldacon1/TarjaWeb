namespace TarjaAEP.Tools
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;
    using System.Reflection;
    using System.Web;
    using System.Net.Http;
    using Newtonsoft.Json;
    #endregion

    public static class Singleton
    {
        #region Variables globales
        //Helper de base de datos
        public static GlobalResponse ObjectResponse { get; set; }
        public static List<OleDbParameter> Parameters { get; set; }
        //Nombre de la aplicación
        public static readonly string ApplicationName = Assembly.GetExecutingAssembly().GetName().Name;
        //Escritura de eventos
        public static string SessionId { get; set; }
        public static string UserWeb { get; set; }


        public static List<GlobalUser> RepositoryUsers { get; set; }

        //Tabla vacía
        public static readonly DataTable EmptyTable = new DataTable("EmptyData");
        #endregion

        #region Notificaciones de javascript
        public enum ToastrType { Error, Success, Warning, Information }

        /// <summary>
        /// Envía una notificación al cliente vía servidor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void ShowNotification(string title, string message, ToastrType type)
        {
            HttpContext.Current.Session["Global:Toastr:Title"] = title;
            HttpContext.Current.Session["Global:Toastr:Message"] = message;
            HttpContext.Current.Session["Global:Toastr:Type"] = type;
        }
        #endregion

        public static string GetUserRut()
        {
            string keyCookie = HttpContext.Current.Request.Cookies["ckUserSAAM"] == null ? "" : HttpContext.Current.Request.Cookies["ckUserSAAM"].Value;
            return keyCookie;
        }
    }

    public class GlobalResponse
    {
        public GlobalResponse()
        {
            this.Message = string.Empty;
            this.HasError = false;
        }

        public string Message { get; set; }
        public bool HasError { get; set; }
    }

    public class GlobalUser
    {
        public string CodTerminal { get; set; }
        public string DesTerminal { get; set; }
        public string CodAgeSaam { get; set; }
        public string CodAlmacen { get; set; }
        public string RutUsuario { get; set; }
        public string DvUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string FuncionUsuario { get; set; }
        public bool esValido { get; set; }
    }
}