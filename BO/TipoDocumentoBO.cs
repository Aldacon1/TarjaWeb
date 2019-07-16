using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class TipoDocumentoBO
    {
        public static int cod_tipo_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["cod_tipo_static"]); }
            set { HttpContext.Current.Session["cod_tipo_static"] = value; }
        }

        private int cod_tipo = -1;

        private string gls_desc_tipo = string.Empty;

        public int Cod_tipo { get { return cod_tipo; } set { cod_tipo = value; } }
        public string Gls_desc_tipo { get { return gls_desc_tipo; } set { gls_desc_tipo = value; } }
    }
}
