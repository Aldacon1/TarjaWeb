using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class FotoContenedorDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_fotoContDescDAL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_fotoContDesc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_fotoContFinDAL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_fotoFinDesc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_fotoConsoDAL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_fotoConso", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
