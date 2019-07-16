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
    public class FotoMercanciaBLL
    {
        public List<FotoMercanciaBO> sp_sel_fotoMercDescBLL(Int64 cod_mercancia)
        {
            DataTable dt = new DataTable();
            List<FotoMercanciaBO> fotos = new List<FotoMercanciaBO>();

            try
            {
                dt = new FotoMercanciaDAL().sp_sel_fotoMercDescDAL(cod_mercancia);

                string jsonFoto = JsonConvert.SerializeObject(dt);
                fotos = JsonConvert.DeserializeObject<List<FotoMercanciaBO>>(jsonFoto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fotos;
        }

        public List<FotoMercanciaBO> sp_sel_fotoMercExpoBLL(Int64 cod_mercancia)
        {
            DataTable dt = new DataTable();
            List<FotoMercanciaBO> fotos = new List<FotoMercanciaBO>();

            try
            {
                dt = new FotoMercanciaDAL().sp_sel_fotoMercExpoDAL(cod_mercancia);

                string jsonFoto = JsonConvert.SerializeObject(dt);
                fotos = JsonConvert.DeserializeObject<List<FotoMercanciaBO>>(jsonFoto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fotos;
        }
    }
}
