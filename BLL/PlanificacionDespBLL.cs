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
    public class PlanificacionDespBLL
    {
        public string sp_sel_PlanificacionDespBLL(int cod_term)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDespDAL().sp_sel_PlanificacionDespDAL(cod_term);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return JsonConvert.SerializeObject(dt);
        }

        public DataTable sp_del_PlanificacionDespBLL(PlanificacionDespBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDespDAL().sp_del_PlanificacionDespDAL(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_PlanificacionDespBLL(PlanificacionDespBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDespDAL().sp_ins_PlanificacionDespDAL(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_PlanificacionDespBLL(PlanificacionDespBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDespDAL().sp_updt_PlanificacionConsoDAL(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string sp_sel_PlanificacionDespIDBLL(Int64 nro_tarja)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDespDAL().sp_sel_PlanificacionDespIDDAL(nro_tarja);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return JsonConvert.SerializeObject(dt);

        }

        public string sp_sel_PlanificacionDespCliente(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionDespDAL().sp_sel_PlanificacionDespCliente(rut_cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return JsonConvert.SerializeObject(dt);
        }

    }
}
