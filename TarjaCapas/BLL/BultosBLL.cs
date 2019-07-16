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
    public class BultosBLL
    {
        public DataTable sp_sel_bultosBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new BultosDAL().sp_sel_bultosDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_del_bultoBLL(BultosBO bulto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new BultosDAL().sp_del_bultosDAL(bulto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_ins_bultosBLL(BultosBO bulto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new BultosDAL().sp_ins_bultosDAL(bulto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_updt_bultosBLL(BultosBO bulto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new BultosDAL().sp_updt_bultosDAL(bulto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_sel_bultosIDBLL(int cod_bulto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new BultosDAL().sp_sel_bultoIDDAL(cod_bulto);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return dt;
        }
    }
}
