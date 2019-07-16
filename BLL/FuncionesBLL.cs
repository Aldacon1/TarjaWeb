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
    public class FuncionesBLL
    {
        public DataTable sp_sel_funcionesBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new FuncionesDAL().sp_sel_funcionesDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_funcionesBLL(FuncionesBO funciones)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new FuncionesDAL().sp_del_funcionesDAL(funciones);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_funcionesBLL(FuncionesBO funciones)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new FuncionesDAL().sp_ins_funcionesDAL(funciones);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_funcionesBLL(FuncionesBO funciones)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new FuncionesDAL().sp_updt_funcionesDAL(funciones);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_funcionIDBLL(int fun_cod)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new FuncionesDAL().sp_sel_funcionIDDAL(fun_cod);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }
    }
}
