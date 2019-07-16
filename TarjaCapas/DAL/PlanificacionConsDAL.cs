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
    public class PlanificacionConsDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;

        public DataTable sp_sel_PlanificacionConsDAL(int cod_term)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];

                parametros[numParam] = new SqlParameter("cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = cod_term;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_PlanificacionCons", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_PlanificacionConsDAL(PlanificacionConsBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@NROTARJA", SqlDbType.BigInt);
                parametros[numParam++].Value = plan.Nro_tarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_planificacionCons", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_PlanificacionConsDAL(PlanificacionConsBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[14];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = plan.Nro_tarja;
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = plan.Rut_cliente;
                parametros[numParam] = new SqlParameter("@fecha", SqlDbType.Date);
                parametros[numParam++].Value = plan.Fecha;
                parametros[numParam] = new SqlParameter("@gls_reserva", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Gls_reserva;
                parametros[numParam] = new SqlParameter("@cod_puerto_or", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_puerto_or;
                parametros[numParam] = new SqlParameter("@cod_puerto_dest", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_puerto_dest;
                parametros[numParam] = new SqlParameter("@n_viaje", SqlDbType.Int);
                parametros[numParam++].Value = plan.N_viaje;
                parametros[numParam] = new SqlParameter("@cod_nave", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_nave;
                parametros[numParam] = new SqlParameter("@cod_iso", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Cod_iso;
                parametros[numParam] = new SqlParameter("@gls_contenedor", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Gls_contenedor;
                parametros[numParam] = new SqlParameter("@f_capacidad", SqlDbType.Float);
                parametros[numParam++].Value = plan.F_capacidad;
                parametros[numParam] = new SqlParameter("@gls_sello", SqlDbType.VarChar);
                parametros[numParam++].Value = plan.Gls_sello;
                parametros[numParam] = new SqlParameter("@rut_tarjador", SqlDbType.Int);
                parametros[numParam++].Value = plan.Rut_tarjador;
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = plan.Cod_terminal;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_planConso", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_PlanificacionConsoDAL(PlanificacionConsBO planBO)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[14];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = planBO.Nro_tarja;
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = planBO.Rut_cliente;
                parametros[numParam] = new SqlParameter("@fecha", SqlDbType.Date);
                parametros[numParam++].Value = planBO.Fecha;
                parametros[numParam] = new SqlParameter("@gls_reserva", SqlDbType.VarChar);
                parametros[numParam++].Value = planBO.Gls_reserva;
                parametros[numParam] = new SqlParameter("@cod_puerto_or", SqlDbType.VarChar);
                parametros[numParam++].Value = planBO.Cod_puerto_or;
                parametros[numParam] = new SqlParameter("@cod_puerto_dest", SqlDbType.VarChar);
                parametros[numParam++].Value = planBO.Cod_puerto_dest;
                parametros[numParam] = new SqlParameter("@n_viaje", SqlDbType.Int);
                parametros[numParam++].Value = planBO.N_viaje;
                parametros[numParam] = new SqlParameter("@cod_nave", SqlDbType.VarChar);
                parametros[numParam++].Value = planBO.Cod_nave;
                parametros[numParam] = new SqlParameter("@cod_iso", SqlDbType.VarChar);
                parametros[numParam++].Value = planBO.Cod_iso;
                parametros[numParam] = new SqlParameter("@gls_contenedor", SqlDbType.VarChar);
                parametros[numParam++].Value = planBO.Gls_contenedor;
                parametros[numParam] = new SqlParameter("@f_capacidad", SqlDbType.Float);
                parametros[numParam++].Value = planBO.F_capacidad;
                parametros[numParam] = new SqlParameter("@gls_sello", SqlDbType.VarChar);
                parametros[numParam++].Value = planBO.Gls_sello;
                parametros[numParam] = new SqlParameter("@rut_tarjador", SqlDbType.Int);
                parametros[numParam++].Value = planBO.Rut_tarjador;
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = planBO.Cod_terminal;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_planificacionConso", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_PlanificacionConsoIDDAL(Int64 nro_tarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nro_tarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_planificacionConso_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public DataTable sp_sel_PlanificacionConsCliente(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@rut_cliente", SqlDbType.Int);
                parametros[numParam++].Value = rut_cliente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_planificacionConsCliente", parametros);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
