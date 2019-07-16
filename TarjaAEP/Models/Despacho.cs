﻿namespace TarjaAEP.Models
{
    #region Usings
    using CapaBLL;
    using TarjaAEP.Tools;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using CapaBO;
    using System.Globalization;
    #endregion
    public class Despacho
    {
        public string ObtPlanDespacho(ref GlobalResponse globalResponse, string terminal)
        {
            string planes = string.Empty;
            int cod_term = Convert.ToInt32(terminal);

            try
            {
                planes = new PlanificacionDespBLL().sp_sel_PlanificacionDespBLL(cod_term);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return planes;
        }

        public static void GuardarPlanDesp(ref GlobalResponse globalResponse, string nroTarja, string terminal, string transporte, string vuelta, string puertOr, string puerDest, string cliente, string patente, string fecha, string tarjador)
        {
            PlanificacionDespBO planCons = new PlanificacionDespBO();

            planCons.Nro_tarja = Convert.ToInt64(nroTarja);
            planCons.Cod_terminal = Convert.ToInt32(terminal);
            planCons.Cod_transporte = transporte;
            planCons.N_vuelta = Convert.ToInt32(vuelta);
            planCons.Cod_puerto_or = puertOr;
            planCons.Cod_puerto_Dest = puerDest;
            planCons.Rut_cliente = Convert.ToInt32(cliente);
            planCons.Patente = patente;
            DateTime fch = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            planCons.Fecha = fch;
            planCons.N_estado = 1;
            planCons.Rut_tarjador = Convert.ToInt32(tarjador);

            DataTable dt;

            try
            {
                dt = new PlanificacionDespBLL().sp_ins_PlanificacionDespBLL(planCons);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public static void GuardarDocCons(ref GlobalResponse globalResponse, string nroTarja, string nroDoc, string tipoDoc, string dres, string consignante, string consignatario, string despachante)
        {
            DocumentoConsigBO doc = new DocumentoConsigBO();

            doc.Nro_tarja = Convert.ToInt64(nroTarja);
            doc.Nro_documento = nroDoc;
            doc.Tipo_documento = Convert.ToInt32(tipoDoc);
            doc.Gls_dres = dres;
            doc.Gls_consignante = consignante;
            doc.Gls_consignatario = consignatario;
            doc.Gls_despachante = despachante;

            DataTable dt;

            try
            {
                dt = new DocumentoConsigBLL().sp_ins_documentoBLL(doc);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public static void GuardarMercCons(ref GlobalResponse globalResponse, string nroTarja, string nroDoc, string codMercancia, string marca, string contenido, string bultoPrin, string bultoSec, string alto, string largo, string ancho, string cantidad, string peso)
        {
            MercanciaExpoBO merc = new MercanciaExpoBO();

            merc.Nro_tarja = Convert.ToInt64(nroTarja);
            merc.Nro_documento = nroDoc;
            merc.Cod_mercancia = Convert.ToInt64(codMercancia);
            merc.Gls_marca = marca;
            merc.Gls_contenido = contenido;
            merc.N_bulto = Convert.ToInt32(bultoPrin);
            merc.N_bulto_sec = Convert.ToInt32(bultoSec);
            merc.F_alto = Convert.ToDecimal(alto);
            merc.F_ancho = Convert.ToDecimal(ancho);
            merc.F_largo = Convert.ToDecimal(largo);
            merc.N_cantidad = Convert.ToInt32(cantidad);
            merc.F_peso = Convert.ToDecimal(peso);
            merc.Gls_observacion = string.Empty;

            DataTable dt;

            try
            {
                dt = new MercanciaExpoBLL().sp_ins_mercExpoBLL(merc);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public string ObtDocsConso(ref GlobalResponse globalResponse, string nroTarja)
        {
            string documentos = string.Empty;

            try
            {
                documentos = new DocumentoConsigBLL().sp_sel_documentosIDBLL(Convert.ToInt64(nroTarja));
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return documentos;
        }

        public string ObtLisMercCons(ref GlobalResponse globalResponse, string nroTarja, string nroDoc)
        {
            string mercancias = string.Empty;

            try
            {
                mercancias = new MercanciaExpoBLL().sp_sel_mercExpoBLL(nroDoc, Convert.ToInt64(nroTarja));
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return mercancias;
        }

        public static void EliminarDoc(ref GlobalResponse globalResponse, string nroDoc, string nroTarja)
        {
            DataTable dt = new DataTable();
            DocumentoConsigBO doc = new DocumentoConsigBO();

            doc.Nro_documento = nroDoc;
            doc.Nro_tarja = Convert.ToInt64(nroTarja);
            try
            {
                dt = new DocumentoConsigBLL().sp_del_documentoBLL(doc);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public static void EliminarMercCons(ref GlobalResponse globalResponse, string codMercancia)
        {
            DataTable dt = new DataTable();
            MercanciaExpoBO merc = new MercanciaExpoBO();

            merc.Cod_mercancia = Convert.ToInt64(codMercancia);
            try
            {
                dt = new MercanciaExpoBLL().sp_del_mercExpoBLL(merc);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public string EditarPlan(ref GlobalResponse globalResponse, string nroTarja)
        {
            string planes = string.Empty;

            try
            {
                planes = new PlanificacionDespBLL().sp_sel_PlanificacionDespIDBLL(Convert.ToInt64(nroTarja));
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return planes;
        }

        public static void GuardarPlanEdit(ref GlobalResponse globalResponse, string nroTarja, string terminal, string transporte, string vuelta, string puertOr, string puerDest, string cliente, string patente, string fecha, string tarjador)
        {
            PlanificacionDespBO planCons = new PlanificacionDespBO();

            planCons.Nro_tarja = Convert.ToInt64(nroTarja);
            planCons.Cod_terminal = Convert.ToInt32(terminal);
            planCons.Cod_transporte = transporte;
            planCons.N_vuelta = Convert.ToInt32(vuelta);
            planCons.Cod_puerto_or = puertOr;
            planCons.Cod_puerto_Dest = puerDest;
            planCons.Rut_cliente = Convert.ToInt32(cliente);
            planCons.Patente = patente;
            DateTime fch = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            planCons.Fecha = fch;
            planCons.N_estado = 1;
            planCons.Rut_tarjador = Convert.ToInt32(tarjador);

            DataTable dt;

            try
            {
                dt = new PlanificacionDespBLL().sp_updt_PlanificacionDespBLL(planCons);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }
    }
}
