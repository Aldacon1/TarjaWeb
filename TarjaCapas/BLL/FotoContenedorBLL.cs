using CapaBO;
using CapaDAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaBLL
{
    public class FotoContenedorBLL
    {
        public List<FotoContenedorBO> sp_sel_fotoContDescBLL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();
            List<FotoContenedorBO> fotos = new List<FotoContenedorBO>();

            try
            {
                dt = new FotoContenedorDAL().sp_sel_fotoContDescDAL(nroTarja);

                string jsonFotos = JsonConvert.SerializeObject(dt);

                fotos = JsonConvert.DeserializeObject<List<FotoContenedorBO>>(jsonFotos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fotos;
        }

        public List<FotoContenedorBO> sp_sel_fotoContFinBLL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();
            List<FotoContenedorBO> fotos = new List<FotoContenedorBO>();

            try
            {
                dt = new FotoContenedorDAL().sp_sel_fotoContFinDAL(nroTarja);

                string jsonFotos = JsonConvert.SerializeObject(dt);
                fotos = JsonConvert.DeserializeObject<List<FotoContenedorBO>>(jsonFotos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fotos;
        }

        public List<FotoContenedorBO> sp_sel_fotoConsoBLL(Int64 nroTarja)
        {
            DataTable dt = new DataTable();
            List<FotoContenedorBO> fotos = new List<FotoContenedorBO>();

            try
            {
                dt = new FotoContenedorDAL().sp_sel_fotoConsoDAL(nroTarja);

                string jsonFotos = JsonConvert.SerializeObject(dt);
                fotos = JsonConvert.DeserializeObject<List<FotoContenedorBO>>(jsonFotos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fotos;
        }
    }
}
