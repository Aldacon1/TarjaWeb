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
    public class Isos
    {
        public List<IsoDescBO> ObtIso(ref GlobalResponse globalResponse)
        {
            var isos = new List<IsoDescBO>();

            try
            {
                var resultados = new IsoDescBLL().sp_sel_isoBLL();
                isos.AddRange(from DataRow row in resultados.Rows select new IsoDescBO { Iso_cod = row[0].ToString(), Iso_nom = row[1].ToString()});
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return isos;
        }
    }
}
