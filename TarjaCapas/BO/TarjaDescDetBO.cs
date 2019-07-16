using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class TarjaDescDetBO
    {
        public static Int64 nro_tarja_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["nro_tarja_static"]); }
            set { HttpContext.Current.Session["nro_tarja_static"] = value; }
        }

        private Int64 nro_tarja = -1;

        private string cod_manifiesto = string.Empty,
            grua_cod = string.Empty,
            observacion = string.Empty;

        public Int64 Nro_tarja { get { return nro_tarja; } set { nro_tarja = value; } }
        public string Cod_manifiesto { get { return cod_manifiesto; } set { cod_manifiesto = value; } }
        public string Grua_cod { get { return grua_cod; } set { grua_cod = value; } }
        public string Observacion { get { return observacion; } set { observacion = value; } }
    }
}
