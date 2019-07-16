namespace TarjaAEP.Models
{
    #region Usings
    using CapaBLL;
    using TarjaAEP.Tools;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using CapaBO;
    using System.Globalization;
    using Newtonsoft.Json;
    #endregion
    public class TipoBulto
    {

        public List<BultosBO> ObtTiposBultos(ref GlobalResponse globalResponse)
        {
            var tipoBultos = new List<BultosBO>();

            try
            {
                var resultados = new BultosBLL().sp_sel_bultosBLL();
                tipoBultos.AddRange(from DataRow row in resultados.Rows select new BultosBO { Cod_bulto = Convert.ToInt32(row[0].ToString()), Desc_bulto = row[1].ToString() });
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return tipoBultos;
        }

        public static void GuardarBulto(ref GlobalResponse globalresponse, string codigo, string descripcion)
        {
            BultosBO bulto = new BultosBO();

            bulto.Cod_bulto = Convert.ToInt32(codigo);
            bulto.Desc_bulto = descripcion;

            DataTable dt = new DataTable();

            try
            {
                dt = new BultosBLL().sp_ins_bultosBLL(bulto);
            }
            catch(Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }

        public static void EliminarBulto(ref GlobalResponse globalResponse, string codigo)
        {
            BultosBO bulto = new BultosBO();

            bulto.Cod_bulto = Convert.ToInt32(codigo);

            DataTable dt = new DataTable();

            try
            {
                dt = new BultosBLL().sp_del_bultoBLL(bulto);
            }
            catch(Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public string EditarBultos(ref GlobalResponse globalResponse, string codigo)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new BultosBLL().sp_sel_bultosIDBLL(Convert.ToInt32(codigo));
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return JsonConvert.SerializeObject(dt);
        }

        public static void GuardarBultoEdit(ref GlobalResponse globalresponse, string codigo, string descripcion)
        {
            BultosBO bulto = new BultosBO();

            bulto.Cod_bulto = Convert.ToInt32(codigo);
            bulto.Desc_bulto = descripcion;

            DataTable dt = new DataTable();

            try
            {
                dt = new BultosBLL().sp_updt_bultosBLL(bulto);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }
    }
}
