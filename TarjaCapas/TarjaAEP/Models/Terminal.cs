using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    using Newtonsoft.Json;
    #endregion
    public class Terminal
    {
        public List<TerminalesBO> ObtTerminales(ref GlobalResponse globalResponse)
        {
            var terminales = new List<TerminalesBO>();

            try
            {
                var resultados = new TerminalesBLL().sp_sel_terminalesBLL();
                terminales.AddRange(from DataRow row in resultados.Rows select new TerminalesBO { Age_cod = Convert.ToInt32(row[0].ToString()), Age_nom = row[1].ToString() });
            }
            catch(Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return terminales;
        }

        public string EditarTerminales(ref GlobalResponse globalResponse, string codigo)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new TerminalesBLL().sp_sel_terminalIDBLL(Convert.ToInt32(codigo));
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return JsonConvert.SerializeObject(dt);
        }

        public static void EliminarTerminal(ref GlobalResponse globalResponse, string codigo)
        {
            TerminalesBO terminal = new TerminalesBO();

            terminal.Age_cod = Convert.ToInt32(codigo);

            DataTable dt = new DataTable();

            try
            {
                dt = new TerminalesBLL().sp_del_terminalesBLL(terminal);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public static void GuardarTerminal(ref GlobalResponse globalresponse, string codigo, string descripcion)
        {
            TerminalesBO terminal = new TerminalesBO();

            terminal.Age_cod = Convert.ToInt32(codigo);
            terminal.Age_nom = descripcion;

            DataTable dt = new DataTable();

            try
            {
                dt = new TerminalesBLL().sp_ins_terminalesBLL(terminal);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }

        public static void GuardarTerminalEdit(ref GlobalResponse globalresponse, string codigo, string descripcion)
        {
            TerminalesBO terminal = new TerminalesBO();

            terminal.Age_cod = Convert.ToInt32(codigo);
            terminal.Age_nom = descripcion;

            DataTable dt = new DataTable();

            try
            {
                dt = new TerminalesBLL().sp_updt_terminalesBLL(terminal);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }
    }
}
