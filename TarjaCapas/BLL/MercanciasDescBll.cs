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
    public class MercanciasDescBll
    {
        public List<MercanciasDescBO> sp_sel_mercDescBLL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();
            List<MercanciasDescBO> mercancias = new List<MercanciasDescBO>();
            try
            {
                dt = new MercanciasDescDAL().sp_sel_mercDescDAL(nroTarja);

                string jsonMercs = JsonConvert.SerializeObject(dt);

                mercancias = JsonConvert.DeserializeObject<List<MercanciasDescBO>>(jsonMercs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mercancias;
        }

        public string sp_sel_marcaMercBLL(Int64 cod_mercancia)
        {
            string marca = string.Empty;

            try
            {
                marca = new MercanciasDescDAL().sp_sel_marcaMerc(cod_mercancia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return marca;
        }
    }
}
