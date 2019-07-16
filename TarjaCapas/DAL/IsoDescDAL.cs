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
    public class IsoDescDAL
    {
        SqlParameter[] parametros = null;
        Int32 numParam = 0;


        public DataTable sp_sel_isoDAL()
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = null;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_iso", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_isoDAL(IsoDescBO iso)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.VarChar);
                parametros[numParam++].Value = iso.Iso_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_del_iso", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_isoDAL(IsoDescBO iso)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[3];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.VarChar);
                parametros[numParam++].Value = iso.Iso_cod;
                parametros[numParam] = new SqlParameter("@NOMBRE", SqlDbType.VarChar);
                parametros[numParam++].Value = iso.Iso_nom;
                parametros[numParam] = new SqlParameter("@TARA", SqlDbType.Int);
                parametros[numParam++].Value = iso.Iso_tara;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_add_iso", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_isoDAL(IsoDescBO iso)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[3];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.VarChar);
                parametros[numParam++].Value = iso.Iso_cod;
                parametros[numParam] = new SqlParameter("@NOMBRE", SqlDbType.VarChar);
                parametros[numParam++].Value = iso.Iso_nom;
                parametros[numParam] = new SqlParameter("@TARA", SqlDbType.Int);
                parametros[numParam++].Value = iso.Iso_tara;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_upd_iso", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_isoIDDAL(string iso_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                parametros = new SqlParameter[1];
                parametros[numParam] = new SqlParameter("@CODIGO", SqlDbType.NVarChar);
                parametros[numParam++].Value = iso_cod;

                dt = new AccesoBDDAL().mtdEjecutaProcedimientoAlmacenadoSel("sp_sel_iso_01", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        } 
    }
}
