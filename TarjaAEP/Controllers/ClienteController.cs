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
    using Models;
    using iTextSharp.text;
    using System.IO;
    using iTextSharp.text.pdf;
    #endregion
    public class ClienteController : Controller
    {
        public ActionResult Login()
        {
            //Se obtiene el session id provisto por .NET
            Singleton.SessionId = Session.SessionID;

            //Si el usuario no está autenticado o no hay usuarios en el repositorio, no entra automáticamente
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return View();
            else
            {
                return RedirectToAction("Principal", "Cliente");
            }
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Principal()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Cliente");
            else
            {
                return View();
            }
        }

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
            LoginBO user = new LoginBLL().sp_login_clienteBLL(Convert.ToInt32(usuario), contrasena);

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
                RedirectToAction("Principal", "Cliente");
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

        [HttpGet]
        public ActionResult ObtLisDesc()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Clientes().ObtPlanDesco(ref globalResponse, Convert.ToInt32(Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name).RutUsuario));
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ObtLisCons()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Clientes().ObtPlanConso(ref globalResponse, Convert.ToInt32(Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name).RutUsuario));
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtLisDesp()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Clientes().ObtPlanDespacho(ref globalResponse, Convert.ToInt32(Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name).RutUsuario));
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CrearPdf(string corr_planificacion)
        {
            Int64 nroTarja = 0;
            string planDescJson = new PlanificacionDescBLL().sp_selPlanDescIDBLL(corr_planificacion);

            PlanificacionDescBO planDesc = new PlanificacionDescBO();
            planDesc = JsonConvert.DeserializeObject<PlanificacionDescBO>(planDescJson);
            TarjaDescDetBO tarja = new TarjaDescDetBLL().sp_sel_tarjaDescDetBLL(corr_planificacion);
            nroTarja = tarja.Nro_tarja;

            Document doc = new Document(PageSize.A4.Rotate());
            MemoryStream outstreem = new MemoryStream();
            string fileName = null;
            PdfWriter.GetInstance(doc, outstreem).CloseStream = false;
            doc.Open();
            doc = new PdfDesco().BindingData(doc, planDesc, tarja);
            fileName = "reporte-" + nroTarja;
            doc.Close();

            byte[] byteInfo = outstreem.ToArray();
            outstreem.Write(byteInfo, 0, byteInfo.Length);
            outstreem.Position = 0;
            Response.Buffer = true;

            string base64string = Convert.ToBase64String(byteInfo);

            return File(byteInfo, "application/pdf");
        }

        [HttpGet]
        public ActionResult CrearPdfConso(string nro_tarja)
        {
            Int64 nroTarja = Convert.ToInt64(nro_tarja);

            Document doc = new Document(PageSize.A4.Rotate());
            MemoryStream outstreem = new MemoryStream();
            string fileName = null;
            PdfWriter.GetInstance(doc, outstreem).CloseStream = false;
            doc.Open();
            doc = new PdfConso().BindingData(doc, nroTarja);
            fileName = "reporte-" + nroTarja;
            doc.Close();

            byte[] byteInfo = outstreem.ToArray();
            outstreem.Write(byteInfo, 0, byteInfo.Length);
            outstreem.Position = 0;
            Response.Buffer = true;

            string base64string = Convert.ToBase64String(byteInfo);

            return File(byteInfo, "application/pdf");
        }

        [HttpGet]
        public ActionResult CrearPdfDespacho(string nro_tarja)
        {
            Int64 nroTarja = Convert.ToInt64(nro_tarja);

            Document doc = new Document(PageSize.A4.Rotate());
            MemoryStream outstreem = new MemoryStream();
            string fileName = null;
            PdfWriter.GetInstance(doc, outstreem).CloseStream = false;
            doc.Open();
            doc = new PdfDespacho().BindingData(doc, nroTarja);
            fileName = "reporte-" + nroTarja;
            doc.Close();

            byte[] byteInfo = outstreem.ToArray();
            outstreem.Write(byteInfo, 0, byteInfo.Length);
            outstreem.Position = 0;
            Response.Buffer = true;

            string base64string = Convert.ToBase64String(byteInfo);

            return File(byteInfo, "application/pdf");
        }

        [HttpGet]
        public ActionResult DowndZip(string corr_planificacion)
        {
            Int64 nroTarja = 0;
            string planDescJson = new PlanificacionDescBLL().sp_selPlanDescIDBLL(corr_planificacion);

            PlanificacionDescBO planDesc = new PlanificacionDescBO();
            planDesc = JsonConvert.DeserializeObject<PlanificacionDescBO>(planDescJson);
            TarjaDescDetBO tarja = new TarjaDescDetBLL().sp_sel_tarjaDescDetBLL(corr_planificacion);
            nroTarja = tarja.Nro_tarja;
            string contenedor = planDesc.Cod_contenedor;


            var memoryStream = new ZipFotos().crearZip(nroTarja, planDesc.Fecha);

            byte[] byteInfo = memoryStream.ToArray();
            memoryStream.Write(byteInfo, 0, byteInfo.Length);
            memoryStream.Position = 0;
            Response.Buffer = true;

            string base64string = Convert.ToBase64String(byteInfo);

            return File(byteInfo, "application/gzip", contenedor + ".zip");

        }

        [HttpGet]
        public ActionResult DownloadZip(string nro_tarja)
        {
            Int64 nroTarja = Convert.ToInt64(nro_tarja);
            string jsonPlan = string.Empty;
            PlanificacionConsBO planCons;

            MemoryStream outstreem = new MemoryStream();
            jsonPlan = new PlanificacionConsBLL().sp_sel_PlanificacionConsoIDDAL(nroTarja);
            planCons = JsonConvert.DeserializeObject<PlanificacionConsBO>(jsonPlan.Trim(new char[] { '[', ']' }));

            outstreem = new ZipFotoCons().crearZip(nroTarja, planCons.Fecha);


            byte[] byteInfo = outstreem.ToArray();
            outstreem.Write(byteInfo, 0, byteInfo.Length);
            outstreem.Position = 0;
            Response.Buffer = true;

            string base64string = Convert.ToBase64String(byteInfo);

            return File(byteInfo, "application/gzip", planCons.Gls_contenedor + ".zip");
        }

        public ActionResult DownloadZipDesp(string nro_tarja)
        {
            Int64 nroTarja = Convert.ToInt64(nro_tarja);
            string jsonPlan = string.Empty;
            PlanificacionDespBO planCons;

            MemoryStream outstreem = new MemoryStream();
            jsonPlan = new PlanificacionDespBLL().sp_sel_PlanificacionDespIDBLL(nroTarja);
            planCons = JsonConvert.DeserializeObject<PlanificacionDespBO>(jsonPlan.Trim(new char[] { '[', ']' }));

            outstreem = new ZipFotoDesp().crearZip(nroTarja, planCons.Fecha);


            byte[] byteInfo = outstreem.ToArray();
            outstreem.Write(byteInfo, 0, byteInfo.Length);
            outstreem.Position = 0;
            Response.Buffer = true;

            string base64string = Convert.ToBase64String(byteInfo);

            return File(byteInfo, "application/gzip", planCons.Nro_tarja + ".zip");
        }

        public ActionResult obtLinksVideo(string contenedor)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Desconsolidado().obtLinksVideo(ref globalResponse, contenedor);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}