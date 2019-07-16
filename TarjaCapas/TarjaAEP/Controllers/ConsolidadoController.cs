using System.Reflection;

namespace TarjaAEP.Controllers
{
    using CapaBLL;
    #region Usings
    using CapaBO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Web.Mvc;
    using Tools;
    #endregion
    [Authorize]
    public class ConsolidadoController : Controller
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
                ViewBag.TipoDocumento = new TipoDocumento().ObtTiposDocs(ref globalResponse);
                ViewBag.TipoBulto = new TipoBulto().ObtTiposBultos(ref globalResponse);
                return View();
            }
        }

        #endregion

        #region Vista Consolidado
        [HttpGet]
        public ActionResult ObtLisCons()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Consolidado().ObtPlanConso(ref globalResponse, Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name).CodTerminal);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtLisDocCons(string nroTarja)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Consolidado().ObtDocsConso(ref globalResponse, nroTarja);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarPlanCons(string nroTarja, string reserva, string terminal, string contenedor, string nave, string viaje, string puertOr, string puerDest, string cliente, string iso, string sello, string fecha, string tarjador)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Consolidado.GuardarPlanCons(ref globalResponse, nroTarja, reserva, terminal, contenedor, nave, viaje, puertOr, puerDest, cliente, iso, sello, fecha, tarjador);
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

        public ActionResult guardarDocCons(string nroTarja, string nroDoc, string tipoDoc, string dres, string consignante, string consignatario, string despachante)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Consolidado.GuardarDocCons(ref globalResponse, nroTarja, nroDoc, tipoDoc, dres, consignante, consignatario, despachante);
            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Documento ingresado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult GuardarMercCons(string nroTarja, string nroDoc, string codMercancia, string marca, string contenido, string bultoPrin, string bultoSec, string alto, string largo, string ancho, string cantidad, string peso)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Consolidado.GuardarMercCons(ref globalResponse, nroTarja, nroDoc, codMercancia, marca, contenido, bultoPrin, bultoSec, alto, largo, ancho, cantidad, peso);
            if (!globalResponse.HasError)
            {
                globalResponse.Message = "Documento ingresado con exito";
                globalResponse.HasError = false;
            }

            return Json(new
            {
                globalResponse.HasError,
                globalResponse.Message
            });
        }

        public ActionResult ObtLisMercCons(string nroTarja, string nroDoc)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Consolidado().ObtLisMercCons(ref globalResponse, nroTarja, nroDoc);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarDoc(string nroDoc, string nroTarja)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Consolidado.EliminarDoc(ref globalResponse, nroDoc, nroTarja);
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

        public ActionResult EliminarMercCons(string codMercancia)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Consolidado.EliminarMercCons(ref globalResponse, codMercancia);
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

        public ActionResult EditarPlanificacion(string nroTarja)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Consolidado().EditarPlan(ref globalResponse, nroTarja);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarPlanEditCons(string nroTarja, string reserva, string terminal, string contenedor, string nave, string viaje, string puertOr, string puerDest, string cliente, string iso, string sello, string fecha, string tarjador)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Consolidado.GuardarPlanEdit(ref globalResponse, nroTarja, reserva, terminal, contenedor, nave, viaje, puertOr, puerDest, cliente, iso, sello, fecha, tarjador);
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
        public ActionResult CrearPdf(string nro_tarja)
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
        public ActionResult DownloadZip(string nro_tarja)
        {
            Int64 nroTarja = Convert.ToInt64(nro_tarja);
            string jsonPlan = string.Empty;
            PlanificacionConsBO planCons;

            MemoryStream outstreem = new MemoryStream();
            jsonPlan = new PlanificacionConsBLL().sp_sel_PlanificacionConsoIDDAL(nroTarja);
            planCons = JsonConvert.DeserializeObject<PlanificacionConsBO>(jsonPlan.Trim(new char[] { '[', ']' }));

            outstreem = new ZipFotoCons().crearZip(nroTarja);


            byte[] byteInfo = outstreem.ToArray();
            outstreem.Write(byteInfo, 0, byteInfo.Length);
            outstreem.Position = 0;
            Response.Buffer = true;

            string base64string = Convert.ToBase64String(byteInfo);

            return File(byteInfo, "application/gzip", planCons.Gls_contenedor + ".zip");
        }
        #endregion

    }
}