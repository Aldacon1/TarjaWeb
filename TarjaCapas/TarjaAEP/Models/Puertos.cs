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

    public class Puertos
    {
        public List<PuertosBO> ObtPuertos(ref GlobalResponse globalResponse)
        {
            var puertos = new List<PuertosBO>();

            try
            {
                var resultados = new PuertoBLL().sp_sel_puertoBLL();
                puertos.AddRange(from DataRow row in resultados.Rows select new PuertosBO { Cod_puerto = row[0].ToString(), Gls_nombre_puerto = row[1].ToString() });
            }
            catch(Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return puertos;
        }
    }
}
