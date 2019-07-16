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
    public class MercanciaExpoDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_mercExpoDAL(string nroDoc, Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@nro_doc", SqlDbType.VarChar);
                parametros[numParam++].Value = nroDoc;
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_mercExpo", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_mercExpoDAL(MercanciaExpoBO mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_mercancia", SqlDbType.BigInt);
                parametros[numParam++].Value = mercancia.Cod_mercancia;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_mercanciaCons", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_mercExpoDAL(MercanciaExpoBO mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[13];
                parametros[numParam] = new SqlParameter("@cod_mercancia", SqlDbType.BigInt);
                parametros[numParam++].Value = mercancia.Cod_mercancia;
                parametros[numParam] = new SqlParameter("@nro_documento", SqlDbType.VarChar);
                parametros[numParam++].Value = mercancia.Nro_documento;
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = mercancia.Nro_tarja;
                parametros[numParam] = new SqlParameter("@gls_marca", SqlDbType.VarChar);
                parametros[numParam++].Value = mercancia.Gls_marca;
                parametros[numParam] = new SqlParameter("@gls_contenido", SqlDbType.VarChar);
                parametros[numParam++].Value = mercancia.Gls_contenido;
                parametros[numParam] = new SqlParameter("@n_bulto", SqlDbType.Int);
                parametros[numParam++].Value = mercancia.N_bulto;
                parametros[numParam] = new SqlParameter("@n_bulto_sec", SqlDbType.Int);
                parametros[numParam++].Value = mercancia.N_bulto_sec;
                parametros[numParam] = new SqlParameter("@f_peso", SqlDbType.Float);
                parametros[numParam++].Value = mercancia.F_peso;
                parametros[numParam] = new SqlParameter("@f_alto", SqlDbType.Float);
                parametros[numParam++].Value = mercancia.F_alto;
                parametros[numParam] = new SqlParameter("@f_ancho", SqlDbType.Float);
                parametros[numParam++].Value = mercancia.F_ancho;
                parametros[numParam] = new SqlParameter("@f_largo", SqlDbType.Float);
                parametros[numParam++].Value = mercancia.F_largo;
                parametros[numParam] = new SqlParameter("@n_cantidad", SqlDbType.Int);
                parametros[numParam++].Value = mercancia.N_cantidad;
                parametros[numParam] = new SqlParameter("@gls_observacion", SqlDbType.VarChar);
                parametros[numParam++].Value = mercancia.Gls_observacion;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_mercanciaCons", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_mercExpoDAL(MercanciaExpoBO mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[13];
                parametros[numParam] = new SqlParameter("@cod_mercancia", SqlDbType.BigInt);
                parametros[numParam++].Value = mercancia.Cod_mercancia;
                parametros[numParam] = new SqlParameter("@nro_documento", SqlDbType.VarChar);
                parametros[numParam++].Value = mercancia.Nro_documento;
                parametros[numParam] = new SqlParameter("@nro_tarja", SqlDbType.BigInt);
                parametros[numParam++].Value = mercancia.Nro_tarja;
                parametros[numParam] = new SqlParameter("@gls_marca", SqlDbType.VarChar);
                parametros[numParam++].Value = mercancia.Gls_marca;
                parametros[numParam] = new SqlParameter("@gls_contenido", SqlDbType.VarChar);
                parametros[numParam++].Value = mercancia.Gls_contenido;
                parametros[numParam] = new SqlParameter("@n_bulto", SqlDbType.Int);
                parametros[numParam++].Value = mercancia.N_bulto;
                parametros[numParam] = new SqlParameter("@n_bulto_sec", SqlDbType.Int);
                parametros[numParam++].Value = mercancia.N_bulto_sec;
                parametros[numParam] = new SqlParameter("@f_peso", SqlDbType.Float);
                parametros[numParam++].Value = mercancia.F_peso;
                parametros[numParam] = new SqlParameter("@f_alto", SqlDbType.Float);
                parametros[numParam++].Value = mercancia.F_alto;
                parametros[numParam] = new SqlParameter("@f_ancho", SqlDbType.Float);
                parametros[numParam++].Value = mercancia.F_ancho;
                parametros[numParam] = new SqlParameter("@f_largo", SqlDbType.Float);
                parametros[numParam++].Value = mercancia.F_largo;
                parametros[numParam] = new SqlParameter("@n_cantidad", SqlDbType.Int);
                parametros[numParam++].Value = mercancia.N_cantidad;
                parametros[numParam] = new SqlParameter("@gls_observacion", SqlDbType.VarChar);
                parametros[numParam++].Value = mercancia.Gls_observacion;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_mercanciaExpo", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_mercExpoIDDAL(Int64 cod_mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@cod_mercancia", SqlDbType.BigInt);
                parametros[numParam++].Value = cod_mercancia;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_mercExpo_01", parametros);
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

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_marcaMercExpo", parametros);

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
