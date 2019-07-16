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
    public class MercanciaExpoBLL
    {
        public string sp_sel_mercExpoBLL(string nroDoc, Int64 nroTarja)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new MercanciaExpoDAL().sp_sel_mercExpoDAL(nroDoc, nroTarja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return JsonConvert.SerializeObject(dt);
        }

        public DataTable sp_del_mercExpoBLL(MercanciaExpoBO mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new MercanciaExpoDAL().sp_del_mercExpoDAL(mercancia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_ins_mercExpoBLL(MercanciaExpoBO mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new MercanciaExpoDAL().sp_ins_mercExpoDAL(mercancia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_updt_mercExpoBLL(MercanciaExpoBO mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new MercanciaExpoDAL().sp_updt_mercExpoDAL(mercancia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_sel_mercExpoIDBLL(Int64 cod_mercancia)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new MercanciaExpoDAL().sp_sel_mercExpoIDDAL(cod_mercancia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public string sp_sel_marcaMercBLL(Int64 cod_mercancia)
        {
            string marca = string.Empty;

            try
            {
                marca = new MercanciaExpoDAL().sp_sel_marcaMerc(cod_mercancia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marca;
        }
    }
}
