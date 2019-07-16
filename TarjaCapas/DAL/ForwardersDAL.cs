using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaBO;

namespace CapaDAL
{
    public class ForwardersDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_ForwardersDescDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_cliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_ForwarderDAL(ForwardersBO forwarder)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@RUT", SqlDbType.Int);
                parametros[numParam++].Value = forwarder.Rut_cliente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_cliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_ForwarderDAL(ForwardersBO forwarder)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[5];
                parametros[numParam] = new SqlParameter("@RUT", SqlDbType.Int);
                parametros[numParam++].Value = forwarder.Rut_cliente;
                parametros[numParam] = new SqlParameter("@RAZON", SqlDbType.NVarChar);
                parametros[numParam++].Value = forwarder.Nombre_cliente;
                parametros[numParam] = new SqlParameter("@PASSWORD", SqlDbType.NChar);
                parametros[numParam++].Value = forwarder.Pass_cliente;
                parametros[numParam] = new SqlParameter("@TELEFONO", SqlDbType.Int);
                parametros[numParam++].Value = forwarder.Fono_cliente;
                parametros[numParam] = new SqlParameter("@EMAIL", SqlDbType.NVarChar);
                parametros[numParam++].Value = forwarder.Email_cliente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_cliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_ForwarderDAL(ForwardersBO forwarder)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[5];
                parametros[numParam] = new SqlParameter("@RUT", SqlDbType.Int);
                parametros[numParam++].Value = forwarder.Rut_cliente;
                parametros[numParam] = new SqlParameter("@RAZON", SqlDbType.NVarChar);
                parametros[numParam++].Value = forwarder.Nombre_cliente;
                parametros[numParam] = new SqlParameter("@PASSWORD", SqlDbType.NChar);
                parametros[numParam++].Value = forwarder.Pass_cliente;
                parametros[numParam] = new SqlParameter("@TELEFONO", SqlDbType.Int);
                parametros[numParam++].Value = forwarder.Fono_cliente;
                parametros[numParam] = new SqlParameter("@EMAIL", SqlDbType.NVarChar);
                parametros[numParam++].Value = forwarder.Email_cliente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_cliente", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_selPlanDesc_ForwarderDAL(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@RUT", SqlDbType.Int);
                parametros[numParam++].Value = rut_cliente;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_cliente_01", parametros);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
            
        } 
        
        public DataTable sp_login_clienteDAL(int rut, string pass)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];

                parametros[numParam] = new SqlParameter("@rut", SqlDbType.Int);
                parametros[numParam++].Value = rut;
                parametros[numParam] = new SqlParameter("@pass", SqlDbType.VarChar);
                parametros[numParam++].Value = pass;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_login_cliente", parametros);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }       
    }
}
