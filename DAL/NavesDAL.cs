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
    public class NavesDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_navesDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_nave", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_navesDAL(NavesBO nave)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.VarChar);
                parametros[numParam++].Value = nave.Nav_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_nave", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_navesDAL(NavesBO nave)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.VarChar);
                parametros[numParam++].Value = nave.Nav_cod;
                parametros[numParam] = new SqlParameter("@NOMBRE", SqlDbType.VarChar);
                parametros[numParam++].Value = nave.Nav_nom;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_naves", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_navesDAL(NavesBO nave)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.NVarChar);
                parametros[numParam++].Value = nave.Nav_cod;
                parametros[numParam] = new SqlParameter("@NOMBRE", SqlDbType.NVarChar);
                parametros[numParam++].Value = nave.Nav_nom;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_nave", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_naveIDDAL(string nav_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.VarChar);
                parametros[numParam++].Value = nav_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_nave_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
