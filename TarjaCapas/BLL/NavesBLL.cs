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
    public class NavesBLL
    {
        public DataTable sp_sel_navesBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new NavesDAL().sp_sel_navesDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_navesBLL(NavesBO nave)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new NavesDAL().sp_del_navesDAL(nave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_navesBLL(NavesBO nave)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new NavesDAL().sp_ins_navesDAL(nave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_navesBll(NavesBO nave)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new NavesDAL().sp_updt_navesDAL(nave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_naveIDBLL(string nav_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new NavesDAL().sp_sel_naveIDDAL(nav_cod);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
