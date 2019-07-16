namespace TarjaAEP.Models
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
    public class Desconsolidado
    {
        public string ObtPlanDesco(ref GlobalResponse globalResponse, string terminal)
        {
            string planes = string.Empty;
            int cod_term = Convert.ToInt32(terminal);

            try
            {
                planes = new PlanificacionDescBLL().sp_sel_planDescBLL(cod_term);
            }
            catch(Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return planes;
        }

        public static void GuardarPlan(ref GlobalResponse globalResponse, string manifiesto, string bl, string mddt, string terminal, string contenedor, string nave, string viaje, string puertOr, string puerDest, string cliente, string iso, string sello, string fecha, string hInicio, string hTermino, string tarjador)
        {
            PlanificacionDescBO planDesc = new PlanificacionDescBO();
            
            planDesc.Cod_manifiesto = manifiesto;
            planDesc.Bl = bl;
            planDesc.Mddt = mddt;
            planDesc.Cod_agencia = Convert.ToInt32(terminal);
            planDesc.Cod_nave = nave;
            planDesc.Cod_viaje = Convert.ToInt32(viaje);
            planDesc.Pue_codO = puertOr;
            planDesc.Pue_codD = puerDest;
            planDesc.Rut_cliente = Convert.ToInt32(cliente);
            planDesc.Cod_contenedor = contenedor;
            planDesc.Cod_iso = iso;
            planDesc.Sello1 = sello;
            DateTime fch = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            planDesc.Fecha = fch;
            TimeSpan horaIn = TimeSpan.ParseExact(hInicio, @"h\:mm", CultureInfo.InvariantCulture);
            TimeSpan horaTer = TimeSpan.ParseExact(hTermino, @"h\:mm", CultureInfo.InvariantCulture);
            planDesc.HoraI = horaIn;
            planDesc.HoraT = horaTer;
            planDesc.Desbloqueo_sello = fch.Month.ToString() + "" + fch.Day.ToString();
            planDesc.Cod_manifiesto = manifiesto;
            planDesc.Estado_tarja = 1;
            planDesc.Rut_tarjador = Convert.ToInt32(tarjador);

            DataTable dt;

            try
            {
                dt = new PlanificacionDescBLL().sp_ins_planDescBLL(planDesc);   
            }
            catch(Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public static void EliminarPlan(ref GlobalResponse globalResponse, string corr_planificacion)
        {
            DataTable dt;

            try
            {
                dt = new PlanificacionDescBLL().sp_del_planDescBLL(corr_planificacion);
            }
            catch(Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public string EditarPlan(ref GlobalResponse globalResponse, string corr_planificacion)
        {
            string planes = string.Empty;

            try
            {
                planes = new PlanificacionDescBLL().sp_selPlanDescIDBLL(corr_planificacion);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return planes;
        }

        public static void GuardarPlanEdit(ref GlobalResponse globalResponse, string manifiesto, string bl, string mddt, string terminal, string contenedor, string nave, string viaje, string puertOr, string puerDest, string cliente, string iso, string sello, string fecha, string hInicio, string hTermino, string tarjador)
        {
            PlanificacionDescBO planDesc = new PlanificacionDescBO();

            planDesc.Cod_manifiesto = manifiesto;
            planDesc.Bl = bl;
            planDesc.Mddt = mddt;
            planDesc.Cod_agencia = Convert.ToInt32(terminal);
            planDesc.Cod_nave = nave;
            planDesc.Cod_viaje = Convert.ToInt32(viaje);
            planDesc.Pue_codO = puertOr;
            planDesc.Pue_codD = puerDest;
            planDesc.Rut_cliente = Convert.ToInt32(cliente);
            planDesc.Cod_contenedor = contenedor;
            planDesc.Cod_iso = iso;
            planDesc.Sello1 = sello;
            DateTime fch = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            planDesc.Fecha = fch;
            TimeSpan horaIn = TimeSpan.ParseExact(hInicio, @"h\:mm", CultureInfo.InvariantCulture);
            TimeSpan horaTer = TimeSpan.ParseExact(hTermino, @"h\:mm", CultureInfo.InvariantCulture);
            planDesc.HoraI = horaIn;
            planDesc.HoraT = horaTer;
            planDesc.Desbloqueo_sello = fch.Month.ToString() + "" + fch.Day.ToString();
            planDesc.Cod_manifiesto = manifiesto;
            planDesc.Estado_tarja = 1;
            planDesc.Rut_tarjador = Convert.ToInt32(tarjador);

            DataTable dt;

            try
            {
                dt = new PlanificacionDescBLL().sp_updt_planDescBLL(planDesc);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public string obtLinksVideo(ref GlobalResponse globalResponse, string contenedor)
        {
            string links = string.Empty;

            try
            {
                links = new VideosTarjaBLL().sp_sel_videosBLL(contenedor);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return links;
        }
    }
}