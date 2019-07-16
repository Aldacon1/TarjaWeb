using CapaDAL;
using Newtonsoft.Json;
using System;
using System.Data;

namespace CapaBLL
{
    public class VideosTarjaBLL
    {
        public string sp_sel_videosBLL(string gls_contenedor)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new VideosTarjaDAL().sp_sel_videosDAL(gls_contenedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string json = JsonConvert.SerializeObject(dt);

            return json;
        }
    }
}
