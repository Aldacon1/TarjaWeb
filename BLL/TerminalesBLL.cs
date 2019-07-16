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
    public class TerminalesBLL
    {
        public DataTable sp_sel_terminalesBLL()
        {
            DataTable dt = new DataTable();

            try
            {

                dt = new TerminalesDAL().sp_sel_terminalesDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_terminalesBLL(TerminalesBO terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TerminalesDAL().sp_del_terminalesDAL(terminal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_terminalesBLL(TerminalesBO terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TerminalesDAL().sp_ins_terminalesDAL(terminal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_terminalesBLL(TerminalesBO terminal)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TerminalesDAL().sp_updt_terminalesDAL(terminal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_terminalIDBLL(int age_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TerminalesDAL().sp_sel_terminalIDDAL(age_cod);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
