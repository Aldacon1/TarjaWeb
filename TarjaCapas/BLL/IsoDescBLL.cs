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
    public class IsoDescBLL
    {
        public DataTable sp_sel_isoBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new IsoDescDAL().sp_sel_isoDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_isoBLL(IsoDescBO iso)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new IsoDescDAL().sp_del_isoDAL(iso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_isoBLL(IsoDescBO iso)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new IsoDescDAL().sp_ins_isoDAL(iso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_isoBLL(IsoDescBO iso)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new IsoDescDAL().sp_updt_isoDAL(iso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_isoIDBLL(string iso_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new IsoDescDAL().sp_sel_isoIDDAL(iso_cod);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        } 
    }
}
