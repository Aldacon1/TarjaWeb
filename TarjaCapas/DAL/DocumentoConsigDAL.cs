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
    public class DocumentoConsigDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_documentosDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_documentoConsig", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_documentoDAL(DocumentoConsigBO documento)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[2];
                parametros[numParam] = new SqlParameter("@NRO_DOC", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Nro_documento;
                parametros[numParam] = new SqlParameter("@NROTARJA", SqlDbType.BigInt);
                parametros[numParam++].Value = documento.Nro_tarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_documentoConsig", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_documentoDAL(DocumentoConsigBO documento)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[7];
                parametros[numParam] = new SqlParameter("@NRO_DOC", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Nro_documento;
                parametros[numParam] = new SqlParameter("@TIPO_DOC", SqlDbType.Int);
                parametros[numParam++].Value = documento.Tipo_documento;
                parametros[numParam] = new SqlParameter("@DRES", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Gls_dres;
                parametros[numParam] = new SqlParameter("@CONSIGNANTE", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Gls_consignante;
                parametros[numParam] = new SqlParameter("@CONSIGNATARIO", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Gls_consignatario;
                parametros[numParam] = new SqlParameter("@DESPACHANTE", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Gls_despachante;
                parametros[numParam] = new SqlParameter("@NROTARJA", SqlDbType.BigInt);
                parametros[numParam++].Value = documento.Nro_tarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_documentoConsig", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_documentosDAL(DocumentoConsigBO documento)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[7];
                parametros[numParam] = new SqlParameter("@NRO_DOC", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Nro_documento;
                parametros[numParam] = new SqlParameter("@TIPO_DOC", SqlDbType.Int);
                parametros[numParam++].Value = documento.Tipo_documento;
                parametros[numParam] = new SqlParameter("@DRES", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Gls_dres;
                parametros[numParam] = new SqlParameter("@CONSIGNANTE", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Gls_consignante;
                parametros[numParam] = new SqlParameter("@CONSIGNATARIO", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Gls_consignatario;
                parametros[numParam] = new SqlParameter("@DESPACHANTE", SqlDbType.VarChar);
                parametros[numParam++].Value = documento.Gls_despachante;
                parametros[numParam] = new SqlParameter("@NROTARJA", SqlDbType.BigInt);
                parametros[numParam++].Value = documento.Nro_tarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_documentoConsig", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_documentosIDDAL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@NROTARJA", SqlDbType.BigInt);
                parametros[numParam++].Value = nroTarja;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_documentoConsig_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
