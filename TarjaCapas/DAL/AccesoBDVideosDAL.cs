using System;
using System.Data;
using System.Data.SqlClient;
using configuraciones = System.Configuration.ConfigurationManager;

namespace CapaDAL
{
    class AccesoBDVideosDAL
    {
        private string conexionString = configuraciones.AppSettings["Videos.cnx"];

        public DataTable mtdEjecutaProcedimientoAlmacenadoSel(string nombreProcedimiento, SqlParameter[] sqlParametros)
        {
            DataSet dsDatosRetorno = null;
            SqlConnection sqlConector = null;
            SqlCommand sqlComando = null;
            SqlDataAdapter sqlAdaptador = null;
            try
            {
                sqlConector = new SqlConnection(conexionString);
                sqlConector.Open();
                sqlComando = new SqlCommand(nombreProcedimiento, sqlConector);
                sqlComando.CommandType = CommandType.StoredProcedure;
                if (sqlParametros != null)
                {
                    for (int a = 0; a < sqlParametros.Length; a++)
                    {
                        sqlComando.Parameters.AddWithValue(sqlParametros[a].ParameterName, sqlParametros[a].SqlValue);
                    }
                }
                sqlAdaptador = new SqlDataAdapter(sqlComando);
                dsDatosRetorno = new DataSet();
                sqlAdaptador.Fill(dsDatosRetorno);
                sqlConector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConector.Dispose();
                sqlComando.Dispose();
                sqlAdaptador.Dispose();
            }
            return dsDatosRetorno.Tables[0];
        }

        public DataSet mtdEjecutaProcedimientoAlmacenadoSelDS(string nombreProcedimiento, SqlParameter[] sqlParametros)
        {
            DataSet dsDatosRetorno = null;
            SqlConnection sqlConector = null;
            SqlCommand sqlComando = null;
            SqlDataAdapter sqlAdaptador = null;
            try
            {
                sqlConector = new SqlConnection(conexionString);
                sqlConector.Open();
                sqlComando = new SqlCommand(nombreProcedimiento, sqlConector);
                sqlComando.CommandType = CommandType.StoredProcedure;
                if (sqlParametros != null)
                {
                    for (int a = 0; a < sqlParametros.Length; a++)
                    {
                        sqlComando.Parameters.AddWithValue(sqlParametros[a].ParameterName, sqlParametros[a].SqlValue);
                    }
                }
                sqlAdaptador = new SqlDataAdapter(sqlComando);
                dsDatosRetorno = new DataSet();
                sqlAdaptador.Fill(dsDatosRetorno);
                sqlConector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConector.Dispose();
                sqlComando.Dispose();
                sqlAdaptador.Dispose();
            }
            return dsDatosRetorno;
        }
    }
}
