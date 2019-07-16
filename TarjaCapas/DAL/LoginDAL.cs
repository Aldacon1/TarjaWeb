using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class LoginDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_loginDAL(int rut, string pass)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];

                parametros[numParam] = new SqlParameter("@usuario",SqlDbType.Int);
                parametros[numParam++].Value = rut;
                parametros[numParam] = new SqlParameter("@password", SqlDbType.NVarChar);
                parametros[numParam++].Value = pass;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_login", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
