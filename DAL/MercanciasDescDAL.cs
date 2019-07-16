using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class MercanciasDescDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_mercDescDAL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_mercDesc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string sp_sel_marcaMerc(Int64 cod_mercancia)
        {
            DataTable dt = new DataTable();
            string marca = string.Empty;

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_mercancia", SqlDbType.BigInt);
                parametros[numParam++].Value = cod_mercancia;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_marcaMerc", parametros);

                marca = dt.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marca;
        }
    }
}
