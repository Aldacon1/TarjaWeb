using System.Reflection;

namespace TarjaAEP.Controllers
{
    #region Usings
    using CapaBLL;
    using CapaBO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Ionic.Zip;
    using Models;
    using Newtonsoft.Json;
    using RazorPDF;
    using System;
    using System.IO;
    using System.Web.Mvc;
    using Tools;
    #endregion
    [Authorize]
    public class DesconsolidadoController : Controller
    {
        #region Carga de vistas Principales

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || Singleton.RepositoryUsers == null) return RedirectToAction("Login", "Home");
            else
            {
                GlobalResponse globalResponse = new GlobalResponse();
                ViewBag.Terminales = new Terminal().ObtTerminales(ref globalResponse);
                ViewBag.Naves = new Nave().ObtNaves(ref globalResponse);
                ViewBag.Puertos = new Puertos().ObtPuertos(ref globalResponse);
                ViewBag.Clientes = new Clientes().ObtClientes(ref globalResponse);
                ViewBag.Isos = new Isos().ObtIso(ref globalResponse);
                ViewBag.Tarjadores = new Personas().ObtTarjador(ref globalResponse, Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name).DesTerminal);
                return View();
            }
        }

        #endregion

        #region Vista Desconsolidado
        [HttpGet]
        public ActionResult ObtLisDesc()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Desconsolidado().ObtPlanDesco(ref globalResponse, Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name).CodTerminal);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GuardarPlanDesc(string manifiesto, string bl, string mddt, string terminal, string contenedor, string nave, string viaje, string puertOr, string puerDest, string cliente, string iso, string sello, string fecha, string hInicio, string hTermino, string tarjador)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Desconsolidado.GuardarPlan(ref globalResponse, manifiesto, bl, mddt, terminal, contenedor, nave, viaje, puertOr, puerDest, cliente, iso, sello, fecha, hInicio, hTermino, tarjador);
            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Planificacion ingresada con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EliminarPlanificacion(string corr_planificacion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Desconsolidado.EliminarPlan(ref globalResponse, corr_planificacion);
            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Planificacion eliminada con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult EditarPlanificacion(string corr_planificacion)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Desconsolidado().EditarPlan(ref globalResponse, corr_planificacion);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarPlanEditDesc(string manifiesto, string bl, string mddt, string terminal, string contenedor, string nave, string viaje, string puertOr, string puerDest, string cliente, string iso, string sello, string fecha, string hInicio, string hTermino, string tarjador)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Desconsolidado.GuardarPlanEdit(ref globalResponse, manifiesto, bl, mddt, terminal, contenedor, nave, viaje, puertOr, puerDest, cliente, iso, sello, fecha, hInicio, hTermino, tarjador);
            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Planificacion ingresada con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
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
        #endregion
    }
}