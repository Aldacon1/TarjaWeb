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
    public class GruasDescBLL
    {
        public DataTable sp_sel_gruasBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new GruasDescDAL().sp_sel_gruasDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_gruasBLL(GruasDescBO gruas)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new GruasDescDAL().sp_del_gruasDAL(gruas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_gruasBLL(GruasDescBO gruas)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new GruasDescDAL().sp_ins_gruasDAL(gruas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_gruasBLL(GruasDescBO gruas)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new GruasDescDAL().sp_updt_gruasDAL(gruas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_funcionIDBLL(GruasDescBO gruas)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new GruasDescDAL().sp_sel_gruaIDDAL(gruas);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public string sp_sel_gruaExpoBLL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new GruasDescDAL().sp_sel_gruaExpoDAL(nroTarja);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string grua = dt.Rows[0].ItemArray[0].ToString();

            return grua;
        }
    }
}
