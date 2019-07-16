using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaBO;
using CapaDAL;
using Newtonsoft.Json;

namespace CapaBLL
{
    public class ForwardersBLL
    {
        public DataTable sp_sel_ForwarderBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersDAL().sp_sel_ForwardersDescDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_del_ForwarderBLL(ForwardersBO forwarder)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersDAL().sp_del_ForwarderDAL(forwarder);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_inst_ForwarderBLL(ForwardersBO forwarder)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersDAL().sp_ins_ForwarderDAL(forwarder);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_updt_ForwarderBLL(ForwardersBO forwarder)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersDAL().sp_updt_ForwarderDAL(forwarder);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable sp_selPlanDesc_forwarderBLL(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersDAL().sp_selPlanDesc_ForwarderDAL(rut_cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return dt;
        }
    }
}
