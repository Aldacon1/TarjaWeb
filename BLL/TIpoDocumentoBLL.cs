using CapaBO;
using CapaDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBLL
{
    public class TIpoDocumentoBLL
    {
        public DataTable sp_sel_tipoDocBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TipoDocumentoDAL().sp_sel_tipoDocDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_tipoDocBLL(TipoDocumentoBO tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TipoDocumentoDAL().sp_del_tipoDocDAL(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_tipoDocBLL(TipoDocumentoBO tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TipoDocumentoDAL().sp_ins_tipoDocDAL(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_tipoDocBLL(TipoDocumentoBO tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TipoDocumentoDAL().sp_updt_tipoDocDAL(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string sp_sel_tipoDocIDBLL(int cod_tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TipoDocumentoDAL().sp_sel_tipoDocIDDAL(cod_tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt.Rows[0].ItemArray[1].ToString();

        } 
    }
}
