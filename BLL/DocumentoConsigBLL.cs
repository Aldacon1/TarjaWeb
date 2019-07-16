using CapaBO;
using CapaDAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBLL
{
    public class DocumentoConsigBLL
    {
        public string sp_sel_documentosBLL()
        {
            DataTable dt = new DataTable();

            try
            {

                dt = new DocumentoConsigDAL().sp_sel_documentosDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return JsonConvert.SerializeObject(dt);
        }

        public DataTable sp_del_documentoBLL(DocumentoConsigBO documento)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DocumentoConsigDAL().sp_del_documentoDAL(documento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_documentoBLL(DocumentoConsigBO documento)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DocumentoConsigDAL().sp_ins_documentoDAL(documento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_documentosBLL(DocumentoConsigBO documento)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DocumentoConsigDAL().sp_updt_documentosDAL(documento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string sp_sel_documentosIDBLL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DocumentoConsigDAL().sp_sel_documentosIDDAL(nroTarja);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return JsonConvert.SerializeObject(dt);

        }
    }
}
