using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAL
{
    public class VideosTarjaDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_videosDAL(string gls_contenedor)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@contenedor", SqlDbType.VarChar);
                parametros[numParam++].Value = gls_contenedor;

                dt = new AccesoBDVideosDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_NombreVideo_tarja", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
