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
    #endregion
    public class TipoDocumento
    {
        public List<TipoDocumentoBO> ObtTiposDocs(ref GlobalResponse globalResponse)
        {
            var tiposDoc = new List<TipoDocumentoBO>();

            try
            {
                var resultados = new TIpoDocumentoBLL().sp_sel_tipoDocBLL();
                tiposDoc.AddRange(from DataRow row in resultados.Rows select new TipoDocumentoBO { Cod_tipo = Convert.ToInt32(row[0].ToString()), Gls_desc_tipo = row[1].ToString() });
            }
            catch (Exception ex)
            {
                globalResponse.Message = ex.Message;
                globalResponse.HasError = true;
            }

            return tiposDoc;
        }
    }
}
