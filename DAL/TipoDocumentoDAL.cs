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
    public class TipoDocumentoDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_tipoDocDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_tipoDoc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_tipoDocDAL(TipoDocumentoBO tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_tipo", SqlDbType.Int);
                parametros[numParam++].Value = tipo.Cod_tipo;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_tipoDoc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_tipoDocDAL(TipoDocumentoBO tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@cod_tipo", SqlDbType.Int);
                parametros[numParam++].Value = tipo.Cod_tipo;
                parametros[numParam] = new SqlParameter("@gls_desc_tipo", SqlDbType.VarChar);
                parametros[numParam++].Value = tipo.Gls_desc_tipo;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_tipoDoc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_tipoDocDAL(TipoDocumentoBO tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@cod_tipo", SqlDbType.Int);
                parametros[numParam++].Value = tipo.Cod_tipo;
                parametros[numParam] = new SqlParameter("@gls_desc_tipo", SqlDbType.VarChar);
                parametros[numParam++].Value = tipo.Gls_desc_tipo;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_tipoDoc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_tipoDocIDDAL(int cod_tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_tipo", SqlDbType.Int);
                parametros[numParam++].Value = cod_tipo;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_tipoDoc_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        } 
    }
}
