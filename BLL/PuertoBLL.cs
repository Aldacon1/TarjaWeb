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
    public class PuertoBLL
    {
        public DataTable sp_sel_puertoBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PuertosDAL().sp_sel_puertoDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_puertoBLL(PuertosBO puerto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PuertosDAL().sp_del_puertoDAL(puerto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_puertoBLL(PuertosBO puerto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PuertosDAL().sp_ins_puertoDAL(puerto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_puertoBLL(PuertosBO puerto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PuertosDAL().sp_updt_puertoDAL(puerto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_puertoIDBLL(string cod_puerto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PuertosDAL().sp_sel_puertoIDDAL(cod_puerto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
