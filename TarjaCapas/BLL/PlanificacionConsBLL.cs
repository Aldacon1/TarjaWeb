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
    public class PlanificacionConsBLL
    {
        public string sp_sel_PlanificacionConsBLL(int cod_term)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionConsDAL().sp_sel_PlanificacionConsDAL(cod_term);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return JsonConvert.SerializeObject(dt);
        }

        public DataTable sp_del_PlanificacionConsBLL(PlanificacionConsBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionConsDAL().sp_del_PlanificacionConsDAL(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_PlanificacionConsBLL(PlanificacionConsBO plan)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionConsDAL().sp_ins_PlanificacionConsDAL(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_PlanificacionConsoBLL(PlanificacionConsBO planBO)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionConsDAL().sp_updt_PlanificacionConsoDAL(planBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string sp_sel_PlanificacionConsoIDDAL(Int64 nro_tarja)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionConsDAL().sp_sel_PlanificacionConsoIDDAL(nro_tarja) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return JsonConvert.SerializeObject(dt);

        }

        public string sp_sel_PlanificacionConsCliente(int rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new PlanificacionConsDAL().sp_sel_PlanificacionConsCliente(rut_cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return JsonConvert.SerializeObject(dt);
        }
    }
}
