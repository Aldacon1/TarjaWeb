using CapaBO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class PlanificacionDespDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;

        public DataTable sp_sel_PlanificacionDespDAL(int cod_term)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];

                parametros[numParam] = new SqlParameter("cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = cod_term;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_planDespacho_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_PlanificacionDespDAL(PlanificacionDespBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@NROTARJA", SqlDbType.BigInt);
                parametros[numParam++].Value = plan.Nro_tarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_planificacionDesp", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_PlanificacionDespDAL(PlanificacionDespBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[10];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = plan.Nro_tarja;
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = plan.Rut_cliente;
                parametros[numParam] = new SqlParameter("@fecha", SqlDbType.Date);
                parametros[numParam++].Value = plan.Fecha;
                parametros[numParam] = new SqlParameter("@cod_puerto_or", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_puerto_or;
                parametros[numParam] = new SqlParameter("@cod_puerto_dest", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_puerto_Dest;
                parametros[numParam] = new SqlParameter("@n_vuelta", SqlDbType.Int);
                parametros[numParam++].Value = plan.N_vuelta;
                parametros[numParam] = new SqlParameter("@cod_transporte", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_transporte;
                parametros[numParam] = new SqlParameter("@patente", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Patente;
                parametros[numParam] = new SqlParameter("@rut_tarjador", SqlDbType.Int);
                parametros[numParam++].Value = plan.Rut_tarjador;
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = plan.Cod_terminal;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_planDesp", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_PlanificacionConsoDAL(PlanificacionDespBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[10];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = plan.Nro_tarja;
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = plan.Rut_cliente;
                parametros[numParam] = new SqlParameter("@fecha", SqlDbType.Date);
                parametros[numParam++].Value = plan.Fecha;
                parametros[numParam] = new SqlParameter("@cod_puerto_or", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_puerto_or;
                parametros[numParam] = new SqlParameter("@cod_puerto_dest", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_puerto_Dest;
                parametros[numParam] = new SqlParameter("@n_vuelta", SqlDbType.Int);
                parametros[numParam++].Value = plan.N_vuelta;
                parametros[numParam] = new SqlParameter("@cod_transporte", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_transporte;
                parametros[numParam] = new SqlParameter("@patente", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Patente;
                parametros[numParam] = new SqlParameter("@rut_tarjador", SqlDbType.Int);
                parametros[numParam++].Value = plan.Rut_tarjador;
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = plan.Cod_terminal;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_planDesp", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_PlanificacionDespIDDAL(Int64 nro_tarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nro_tarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_planDespacho_02", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public DataTable sp_sel_PlanificacionDespCliente(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = rut_cliente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_planificacionDespCliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
