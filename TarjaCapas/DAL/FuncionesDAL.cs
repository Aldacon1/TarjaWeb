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
    public class FuncionesDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_funcionesDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_funcion", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_funcionesDAL(FuncionesBO funciones)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.Int);
                parametros[numParam++].Value = funciones.Fun_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_funcion", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_funcionesDAL(FuncionesBO funciones)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[3];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.Int);
                parametros[numParam++].Value = funciones.Fun_cod;
                parametros[numParam] = new SqlParameter("@NOMBRE", SqlDbType.VarChar);
                parametros[numParam++].Value = funciones.Fun_nom;
                parametros[numParam] = new SqlParameter("@PERMISO", SqlDbType.Int);
                parametros[numParam++].Value = funciones.Per_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_funcion", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_funcionesDAL(FuncionesBO funciones)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[3];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.Int);
                parametros[numParam++].Value = funciones.Fun_cod;
                parametros[numParam] = new SqlParameter("@NOMBRE", SqlDbType.VarChar);
                parametros[numParam++].Value = funciones.Fun_nom;
                parametros[numParam] = new SqlParameter("@PERMISO", SqlDbType.Int);
                parametros[numParam++].Value = funciones.Per_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_funcion", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_funcionIDDAL(int fun_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.Int);
                parametros[numParam++].Value = fun_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_funcion_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
