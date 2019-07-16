namespace TarjaAEP.Models
{
    #region Usings
    using CapaBO;
    using CapaBLL;
    using Tools;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using Newtonsoft.Json;
    #endregion
    public class Clientes
    {
        public List<ForwardersBO> ObtClientes(ref GlobalResponse globalResponse)
        {
            var clientes = new List<ForwardersBO>();

            try
            {
                var resultados = new ForwardersBLL().sp_sel_ForwarderBLL();
                clientes.AddRange(from DataRow row in resultados.Rows select new ForwardersBO { Rut_cliente = Convert.ToInt32(row[0].ToString()), Nombre_cliente = row[1].ToString(), Dv_cliente = row[5].ToString(), Pass_cliente = row[2].ToString() });
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return clientes;
        }

        public string ObtPlanDesco(ref GlobalResponse globalResponse, int rut_cliente)
        {
            string planes = string.Empty;

            try
            {
                planes = new PlanificacionDescBLL().sp_selPlanDescCliente(rut_cliente);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return planes;
        }

        public string ObtPlanConso(ref GlobalResponse globalResponse, int rut_cliente)
        {
            string planes = string.Empty;

            try
            {
                planes = new PlanificacionConsBLL().sp_sel_PlanificacionConsCliente(rut_cliente);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return planes;
        }

        public string ObtPlanDespacho(ref GlobalResponse globalResponse, int rut_cliente)
        {
            string planes = string.Empty;

            try
            {
                planes = new PlanificacionDespBLL().sp_sel_PlanificacionDespCliente(rut_cliente);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return planes;
        }

        public string EditarCliente(ref GlobalResponse globalResponse, string rut_cliente)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersBLL().sp_selPlanDesc_forwarderBLL(Convert.ToInt32(rut_cliente));
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return JsonConvert.SerializeObject(dt);
        }

        public static void EliminarCliente(ref GlobalResponse globalResponse, string rut)
        {
            ForwardersBO cliente = new ForwardersBO();

            string rut_cliente = rut.Remove(rut.Length - 2, 2);

            cliente.Rut_cliente = Convert.ToInt32(rut_cliente);

            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersBLL().sp_del_ForwarderBLL(cliente);
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }
        }

        public static void GuardarCliente(ref GlobalResponse globalresponse, string rut, string nombre, string password, string mail, string fono)
        {
            ForwardersBO cliente = new ForwardersBO();

            cliente.Rut_cliente = Convert.ToInt32(rut);
            cliente.Nombre_cliente = nombre;
            cliente.Pass_cliente = password;
            cliente.Email_cliente = mail;
            cliente.Fono_cliente = Convert.ToInt32(fono);

            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersBLL().sp_inst_ForwarderBLL(cliente);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }

        public static void GuardarEditCliente(ref GlobalResponse globalresponse, string rut, string nombre, string mail, string password, string fono)
        {
            ForwardersBO cliente = new ForwardersBO();

            cliente.Rut_cliente = Convert.ToInt32(rut);
            cliente.Nombre_cliente = nombre;
            cliente.Pass_cliente = password;
            cliente.Email_cliente = mail;
            cliente.Fono_cliente = Convert.ToInt32(fono);

            DataTable dt = new DataTable();

            try
            {
                dt = new ForwardersBLL().sp_updt_ForwarderBLL(cliente);
            }
            catch (Exception ex)
            {
                globalresponse.Message = ex.Message;
                globalresponse.HasError = true;
            }
        }
    }
}
