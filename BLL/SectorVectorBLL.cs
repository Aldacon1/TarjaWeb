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
    public class SectorVectorBLL
    {
        public DataTable sp_sel_sectorVectorBLL()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new SectorVectorDAL().sp_sel_sectorVectorDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable sp_del_sectorVectorBLL(SectorVectorBO sectorVector)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new SectorVectorDAL().sp_del_sectorVectorDAL(sectorVector);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string sp_sel_sectorVectorIDDAL(Int64 nro_tarja)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new SectorVectorDAL().sp_sel_sectorVectorIDDAL(nro_tarja);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string jsonSector = JsonConvert.SerializeObject(dt);

            return jsonSector;

        }
    }
}
