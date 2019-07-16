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
    public class PlanificacionDescBLL
    {
        public string sp_sel_planDescBLL(int cod_term)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDescDAL().sp_sel_planDescDAL(cod_term);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string json = JsonConvert.SerializeObject(dt);

            return json;
        }

        public DataTable sp_ins_planDescBLL(PlanificacionDescBO planDesc)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDescDAL().sp_ins_planDescDAL(planDesc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_planDescBLL(string cod_manifiesto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDescDAL().sp_del_planDescDAL(cod_manifiesto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_planDescBLL(PlanificacionDescBO planDesc)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDescDAL().sp_updt_planDescDAL(planDesc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string sp_selPlanDescIDBLL(string cod_manifiesto)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDescDAL().sp_selPlanDescIDDAL(cod_manifiesto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string json = JsonConvert.SerializeObject(dt.Rows[0].Table);

            return json.Trim(new char[] { '[', ']'});

        }

        public string sp_selPlanDescCliente(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDescDAL().sp_selPlanDescCliente(rut_cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return JsonConvert.SerializeObject(dt);
        }
    }
}
