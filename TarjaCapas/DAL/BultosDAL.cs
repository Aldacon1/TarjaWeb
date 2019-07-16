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
    public class BultosDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_bultosDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_bulto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_bultosDAL(BultosBO bulto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.Int);
                parametros[numParam++].Value = bulto.Cod_bulto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_bulto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_bultosDAL(BultosBO bulto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.Int);
                parametros[numParam++].Value = bulto.Cod_bulto;
                parametros[numParam] = new SqlParameter("@NOMBRE", SqlDbType.VarChar);
                parametros[numParam++].Value = bulto.Desc_bulto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_bultos", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_bultosDAL(BultosBO bulto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.Int);
                parametros[numParam++].Value = bulto.Cod_bulto;
                parametros[numParam] = new SqlParameter("@NOMBRE", SqlDbType.VarChar);
                parametros[numParam++].Value = bulto.Desc_bulto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_bulto", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_bultoIDDAL(int cod_bulto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.Int);
                parametros[numParam++].Value = cod_bulto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_bulto_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }       
    }
}
