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
    #endregion
    public class Funciones
    {
        public List<FuncionesBO> obtFunciones(ref GlobalResponse globalResponse)
        {
            var funciones = new List<FuncionesBO>();

            try
            {
                var resultados = new FuncionesBLL().sp_sel_funcionesBLL();
                funciones.AddRange(from DataRow row in resultados.Rows select new FuncionesBO { Fun_cod = Convert.ToInt32(row[0].ToString()), Fun_nom = row[1].ToString() });
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return funciones;
        }
    }
}