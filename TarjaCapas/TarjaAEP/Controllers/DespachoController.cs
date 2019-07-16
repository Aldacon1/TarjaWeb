using System.Reflection;

namespace TarjaAEP.Controllers
{
    using CapaBLL;
    using CapaBO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    #region Usings
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Web.Mvc;
    using Tools;
    #endregion

    public class DespachoController : Controller
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

        #region Vista Despacho
        [HttpGet]
        public ActionResult ObtLisDesp()
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Despacho().ObtPlanDespacho(ref globalResponse, Singleton.RepositoryUsers.Find(u => u.RutUsuario == User.Identity.Name).CodTerminal);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtLisDocDesp(string nroTarja)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Despacho().ObtDocsConso(ref globalResponse, nroTarja);
            return Json(new
            {
                aaData = data,
                TieneError = globalResponse.HasError,
                Mensaje = globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarPlanDesp(string nroTarja, string terminal, string transporte, string vuelta, string puertOr, string puerDest, string cliente, string patente, string fecha, string tarjador)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Despacho.GuardarPlanDesp(ref globalResponse, nroTarja, terminal, transporte, vuelta, puertOr, puerDest, cliente, patente, fecha, tarjador);
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

        public ActionResult guardarDocDesp(string nroTarja, string nroDoc, string tipoDoc, string dres, string consignante, string consignatario, string despachante)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Despacho.GuardarDocCons(ref globalResponse, nroTarja, nroDoc, tipoDoc, dres, consignante, consignatario, despachante);
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

        public ActionResult GuardarMercDesp(string nroTarja, string nroDoc, string codMercancia, string marca, string contenido, string bultoPrin, string bultoSec, string alto, string largo, string ancho, string cantidad, string peso)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Despacho.GuardarMercCons(ref globalResponse, nroTarja, nroDoc, codMercancia, marca, contenido, bultoPrin, bultoSec, alto, largo, ancho, cantidad, peso);
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

        public ActionResult ObtLisMercDesp(string nroTarja, string nroDoc)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            var data = new Despacho().ObtLisMercCons(ref globalResponse, nroTarja, nroDoc);
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

            Despacho.EliminarDoc(ref globalResponse, nroDoc, nroTarja);
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

        public ActionResult EliminarMercDesp(string codMercancia)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Despacho.EliminarMercCons(ref globalResponse, codMercancia);
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

            var data = new Despacho().EditarPlan(ref globalResponse, nroTarja);

            return Json(new
            {
                aaData = data,
                globalResponse.HasError,
                globalResponse.Message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GuardarPlanEditDesp(string nroTarja, string terminal, string transporte, string vuelta, string puertOr, string puerDest, string cliente, string patente, string fecha, string tarjador)
        {
            GlobalResponse globalResponse = new GlobalResponse();

            Despacho.GuardarPlanEdit(ref globalResponse, nroTarja, terminal, transporte, vuelta, puertOr, puerDest, cliente, patente, fecha, tarjador);
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

        public ActionResult DownloadZip(string nro_tarja)
        {
            Int64 nroTarja = Convert.ToInt64(nro_tarja);
            string jsonPlan = string.Empty;
            PlanificacionDespBO planCons;

            MemoryStream outstreem = new MemoryStream();
            jsonPlan = new PlanificacionDespBLL().sp_sel_PlanificacionDespIDBLL(nroTarja);
            planCons = JsonConvert.DeserializeObject<PlanificacionDespBO>(jsonPlan.Trim(new char[] { '[', ']' }));

            outstreem = new ZipFotoDesp().crearZip(nroTarja);


            byte[] byteInfo = outstreem.ToArray();
            outstreem.Write(byteInfo, 0, byteInfo.Length);
            outstreem.Position = 0;
            Response.Buffer = true;

            string base64string = Convert.ToBase64String(byteInfo);

            return File(byteInfo, "application/gzip", planCons.Nro_tarja + ".zip");
        }
        #endregion
    }
}