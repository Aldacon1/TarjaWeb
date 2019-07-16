namespace TarjaAEP.Models
{
    #region Usings
    using CapaBO;
    using CapaBLL;
    using Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    #endregion
    public class Nave
    {
        public List<NavesBO> ObtNaves(ref GlobalResponse globalResponse)
        {
            var naves = new List<NavesBO>();
            try
            {
                var resultados = new NavesBLL().sp_sel_navesBLL();
                naves.AddRange(from DataRow row in resultados.Rows select new NavesBO { Nav_cod = row[0].ToString(), Nav_nom = row[1].ToString() });
            }
            catch(Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return naves;
        }

        public NavesBO EditarNaves(ref GlobalResponse globalResponse, string codigo)
        {
            DataTable dt = new DataTable();
            NavesBO nave = new NavesBO();

            try
            {
                dt = new NavesBLL().sp_sel_naveIDBLL(codigo);

                nave.Nav_cod = dt.Rows[0].ItemArray[0].ToString();
                nave.Nav_nom = dt.Rows[0].ItemArray[1].ToString();
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return nave;
        }

        public static void EliminarNave(ref GlobalResponse globalResponse, string codigo)
        {
            NavesBO nave = new NavesBO();

            nave.Nav_cod = codigo;

            DataTable dt = new DataTable();

            try
            {
                dt = new NavesBLL().sp_del_navesBLL(nave);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public static void GuardarNave(ref GlobalResponse globalresponse, string codigo, string descripcion)
        {
            NavesBO nave= new NavesBO();

            nave.Nav_cod = codigo;
            nave.Nav_nom = descripcion;

            DataTable dt = new DataTable();

            try
            {
                dt = new NavesBLL().sp_ins_navesBLL(nave);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }

        public static void GuardarNaveEdit(ref GlobalResponse globalresponse, string codigo, string descripcion)
        {
            NavesBO nave = new NavesBO();

            nave.Nav_cod = codigo;
            nave.Nav_nom = descripcion;

            DataTable dt = new DataTable();

            try
            {
                dt = new NavesBLL().sp_updt_navesBll(nave);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }
    }
}
