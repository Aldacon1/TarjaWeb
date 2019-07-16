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
    public class PuertosDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_puertoDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_puerto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_puertoDAL(PuertosBO puerto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_puerto", SqlDbType.VarChar);
                parametros[numParam++].Value = puerto.Cod_puerto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_puerto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_puertoDAL(PuertosBO puerto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@cod_puerto", SqlDbType.VarChar);
                parametros[numParam++].Value = puerto.Cod_puerto;
                parametros[numParam] = new SqlParameter("@gls_nombre_puerto", SqlDbType.VarChar);
                parametros[numParam++].Value = puerto.Gls_nombre_puerto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_puerto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_puertoDAL(PuertosBO puerto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@cod_puerto", SqlDbType.VarChar);
                parametros[numParam++].Value = puerto.Cod_puerto;
                parametros[numParam] = new SqlParameter("@gls_nombre_puerto", SqlDbType.VarChar);
                parametros[numParam++].Value = puerto.Gls_nombre_puerto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_puerto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_puertoIDDAL(string cod_puerto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_puerto", SqlDbType.VarChar);
                parametros[numParam++].Value = cod_puerto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_puerto_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
