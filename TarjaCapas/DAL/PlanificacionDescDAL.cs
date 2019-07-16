using System;
using CapaBO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDAL
{
    public class PlanificacionDescDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_planDescDAL(int cod_term)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];

                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = cod_term;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_planTarjaDesc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_planDescDAL(PlanificacionDescBO planDesc)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[20];
                parametros[numParam] = new SqlParameter("@corr_planificacion", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Cod_manifiesto;
                parametros[numParam] = new SqlParameter("@gls_bl", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Bl;
                parametros[numParam] = new SqlParameter("@cod_puerto_or", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Pue_codO;
                parametros[numParam] = new SqlParameter("@cod_puerto_dest", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Pue_codD;
                parametros[numParam] = new SqlParameter("@gls_contenedor", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Cod_contenedor;
                parametros[numParam] = new SqlParameter("@cod_iso", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Cod_iso;
                parametros[numParam] = new SqlParameter("@gls_sello1", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Sello1;
                parametros[numParam] = new SqlParameter("@gls_sello2", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Sello2;
                parametros[numParam] = new SqlParameter("@gls_sello3", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Sello3;
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Rut_cliente;
                parametros[numParam] = new SqlParameter("@fecha", SqlDbType.Date);
                parametros[numParam++].Value = planDesc.Fecha;
                parametros[numParam] = new SqlParameter("@hora_in", SqlDbType.Time);
                parametros[numParam++].Value = planDesc.HoraI;
                parametros[numParam] = new SqlParameter("@hora_term", SqlDbType.Time);
                parametros[numParam++].Value = planDesc.HoraT;
                parametros[numParam] = new SqlParameter("@gls_mano_trabajo", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Mddt;
                parametros[numParam] = new SqlParameter("@cod_nave", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Cod_nave;
                parametros[numParam] = new SqlParameter("@n_viaje", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Cod_viaje;
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Cod_agencia;
                parametros[numParam] = new SqlParameter("@n_estado", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Estado_tarja;
                parametros[numParam] = new SqlParameter("@gls_desbloqueo_sello", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Desbloqueo_sello;
                parametros[numParam] = new SqlParameter("@rut_tarjador", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Rut_tarjador;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_planDesco", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_planDescDAL(string cod_manifiesto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CORR_PLAN", SqlDbType.NVarChar);
                parametros[numParam++].Value = cod_manifiesto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_planificacionDesc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_planDescDAL(PlanificacionDescBO planDesc)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[20];
                parametros[numParam] = new SqlParameter("@corr_planificacion", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Cod_manifiesto;
                parametros[numParam] = new SqlParameter("@gls_bl", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Bl;
                parametros[numParam] = new SqlParameter("@cod_puerto_or", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Pue_codO;
                parametros[numParam] = new SqlParameter("@cod_puerto_dest", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Pue_codD;
                parametros[numParam] = new SqlParameter("@gls_contenedor", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Cod_contenedor;
                parametros[numParam] = new SqlParameter("@cod_iso", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Cod_iso;
                parametros[numParam] = new SqlParameter("@gls_sello1", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Sello1;
                parametros[numParam] = new SqlParameter("@gls_sello2", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Sello2;
                parametros[numParam] = new SqlParameter("@gls_sello3", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Sello3;
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Rut_cliente;
                parametros[numParam] = new SqlParameter("@fecha", SqlDbType.DateTime);
                parametros[numParam++].Value = planDesc.Fecha;
                parametros[numParam] = new SqlParameter("@hora_in", SqlDbType.Time);
                parametros[numParam++].Value = planDesc.HoraI;
                parametros[numParam] = new SqlParameter("@hora_term", SqlDbType.Time);
                parametros[numParam++].Value = planDesc.HoraT;
                parametros[numParam] = new SqlParameter("@gls_mano_trabajo", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Mddt;
                parametros[numParam] = new SqlParameter("@cod_nave", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Cod_nave;
                parametros[numParam] = new SqlParameter("@n_viaje", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Cod_viaje;
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Cod_agencia;
                parametros[numParam] = new SqlParameter("@n_estado", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Estado_tarja;
                parametros[numParam] = new SqlParameter("@gls_desbloqueo_sello", SqlDbType.VarChar);
                parametros[numParam++].Value = planDesc.Desbloqueo_sello;
                parametros[numParam] = new SqlParameter("@rut_tarjador", SqlDbType.Int);
                parametros[numParam++].Value = planDesc.Rut_tarjador;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_planificacionDesco", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_selPlanDescIDDAL(string cod_manifiesto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@corr_plan", SqlDbType.VarChar);
                parametros[numParam++].Value = cod_manifiesto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_planTarjaDescID", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public DataTable sp_selPlanDescCliente(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = rut_cliente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_planTarjaDesc_cliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
