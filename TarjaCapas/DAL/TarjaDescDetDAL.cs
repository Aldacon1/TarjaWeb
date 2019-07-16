using CapaBO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class TarjaDescDetDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;

        public DataTable sp_ins_tarjaDescDetDAL(TarjaDescDetBO tarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[4];
                parametros[numParam] = new SqlParameter("@nroTarja", SqlDbType.BigInt);
                parametros[numParam++].Value = tarja.Nro_tarja;
                parametros[numParam] = new SqlParameter("@corr_plan", SqlDbType.VarChar);
                parametros[numParam++].Value = tarja.Cod_manifiesto;
                parametros[numParam] = new SqlParameter("@grua", SqlDbType.VarChar);
                parametros[numParam++].Value = tarja.Grua_cod;
                parametros[numParam] = new SqlParameter("@obs", SqlDbType.VarChar);
                parametros[numParam++].Value = tarja.Observacion;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_detalleTarjaDesc", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string sp_sel_tarjaDescDetDAL(string manifiesto)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@corr_plan", SqlDbType.VarChar);
                parametros[numParam++].Value = manifiesto;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_tarjaDescDet", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return JsonConvert.SerializeObject(dt);
        }
    }
}
