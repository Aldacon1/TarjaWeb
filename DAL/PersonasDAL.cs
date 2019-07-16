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
    public class PersonasDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_personasDAL(string terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];

                parametros[numParam] = new SqlParameter("@TERMINAL", SqlDbType.VarChar);
                parametros[numParam++].Value = terminal;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_persona", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_tarjadorDAL(string terminal)
        {
            DataTable dt = new DataTable();
            try
            {
                parametros = new SqlParameter[1];

                parametros[numParam] = new SqlParameter("@TERMINAL", SqlDbType.VarChar);
                parametros[numParam++].Value = terminal;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_tarjador", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_del_personasDAL(PersonasBO persona)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@RUT", SqlDbType.Int);
                parametros[numParam++].Value = persona.Rut_persona;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_persona", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_personasDAL(PersonasBO persona)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[5];
                parametros[numParam] = new SqlParameter("@rut_persona", SqlDbType.Int);
                parametros[numParam++].Value = persona.Rut_persona;
                parametros[numParam] = new SqlParameter("@gls_nombre_pers", SqlDbType.VarChar);
                parametros[numParam++].Value = persona.Nom_persona;
                parametros[numParam] = new SqlParameter("@cod_funcion", SqlDbType.Int);
                parametros[numParam++].Value = persona.Fun_cod;
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.Int);
                parametros[numParam++].Value = persona.Age_cod;
                parametros[numParam] = new SqlParameter("@gls_password", SqlDbType.VarChar);
                parametros[numParam++].Value = persona.Pass_persona;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_personas", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_personasDAL(PersonasBO persona)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[5];
                parametros[numParam] = new SqlParameter("@rut_persona", SqlDbType.Int);
                parametros[numParam++].Value = persona.Rut_persona;
                parametros[numParam] = new SqlParameter("@gls_nombre_pers", SqlDbType.NVarChar);
                parametros[numParam++].Value = persona.Nom_persona;
                parametros[numParam] = new SqlParameter("@cod_funcion", SqlDbType.Int);
                parametros[numParam++].Value = persona.Fun_cod;
                parametros[numParam] = new SqlParameter("@cod_terminal", SqlDbType.NChar);
                parametros[numParam++].Value = persona.Age_cod;
                parametros[numParam] = new SqlParameter("@gls_password", SqlDbType.NVarChar);
                parametros[numParam++].Value = persona.Pass_persona;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_persona", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_personasIDDAL(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@RUT", SqlDbType.Int);
                parametros[numParam++].Value = rut_cliente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_persona_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public DataTable sp_sel_personasTarjaDAL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_personasTarja", parametros);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_sel_personasTarjaExpoDAL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_personasTarjaExpo", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
