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
    public class TerminalesDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_terminalesDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_terminal", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_terminalesDAL(TerminalesBO terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = terminal.Age_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_terminal", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_terminalesDAL(TerminalesBO terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = terminal.Age_cod;
                parametros[numParam] = new SqlParameter("@gls_nombre_terminal", SqlDbType.NVarChar);
                parametros[numParam++].Value = terminal.Age_nom;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_terminal", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_terminalesDAL(TerminalesBO terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = terminal.Age_cod;
                parametros[numParam] = new SqlParameter("@gls_nombre_terminal", SqlDbType.NVarChar);
                parametros[numParam++].Value = terminal.Age_nom;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_terminal", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_terminalIDDAL(int age_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = age_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_terminal_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
