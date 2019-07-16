using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAL
{
    public class FotoMercanciaDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_fotoMercDescDAL(Int64 cod_mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_mercancia", SqlDbType.BigInt);
                parametros[numParam++].Value = cod_mercancia;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_fotoMercDesc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_fotoMercExpoDAL(Int64 cod_mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_mercancia", SqlDbType.BigInt);
                parametros[numParam++].Value = cod_mercancia;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_fotoMercExpo", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
