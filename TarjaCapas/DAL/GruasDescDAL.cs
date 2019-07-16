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
    public class GruasDescDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_gruasDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_grua", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_gruasDAL(GruasDescBO gruas)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@PATENTE", SqlDbType.NVarChar);
                parametros[numParam++].Value = gruas.Patente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_grua", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_gruasDAL(GruasDescBO gruas)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[3];
                parametros[numParam] = new SqlParameter("@PATENTE", SqlDbType.VarChar);
                parametros[numParam++].Value = gruas.Patente;
                parametros[numParam] = new SqlParameter("@MARCA", SqlDbType.VarChar);
                parametros[numParam++].Value = gruas.MarcaMod;
                parametros[numParam] = new SqlParameter("@TERMINAL", SqlDbType.Int);
                parametros[numParam++].Value = gruas.Cod_term;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_grua", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_gruasDAL(GruasDescBO gruas)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[3];
                parametros[numParam] = new SqlParameter("@PATENTE", SqlDbType.VarChar);
                parametros[numParam++].Value = gruas.Patente;
                parametros[numParam] = new SqlParameter("@MARCA", SqlDbType.VarChar);
                parametros[numParam++].Value = gruas.MarcaMod;
                parametros[numParam] = new SqlParameter("@TERMINAL", SqlDbType.Int);
                parametros[numParam++].Value = gruas.Cod_term;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_grua", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_gruaIDDAL(GruasDescBO gruas)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@PATENTE", SqlDbType.VarChar);
                parametros[numParam++].Value = gruas.Patente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_grua_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public DataTable sp_sel_gruaExpoDAL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_gruaExpo", parametros);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
