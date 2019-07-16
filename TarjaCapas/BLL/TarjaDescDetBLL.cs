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
    public class TarjaDescDetBLL
    {
        public DataTable sp_ins_tarjaDescDetBLL(string json)
        {
            DataTable dt = new DataTable();
            TarjaDescDetBO tarja = new TarjaDescDetBO();

            tarja = JsonConvert.DeserializeObject<TarjaDescDetBO>(json);

            try
            {
                dt = new TarjaDescDetDAL().sp_ins_tarjaDescDetDAL(tarja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public TarjaDescDetBO sp_sel_tarjaDescDetBLL(string manifiesto)
        {
            string json;

            try
            {
                json = new TarjaDescDetDAL().sp_sel_tarjaDescDetDAL(manifiesto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            TarjaDescDetBO tarja = new TarjaDescDetBO();

            tarja = JsonConvert.DeserializeObject<TarjaDescDetBO>(json.Trim(new char[] {'[',']' }));

            return tarja;
        }
    }
}
