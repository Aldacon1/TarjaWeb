using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class PuertosBO
    {
        public static string cod_puerto_static
        {
            get { return (HttpContext.Current.Session["cod_puerto_static"].ToString()); }
            set { HttpContext.Current.Session["cod_puerto_static"] = value; }
        }

        private string cod_puerto = string.Empty,
            gls_nombre_puerto = string.Empty;

        public string Cod_puerto { get { return cod_puerto; } set { cod_puerto = value; } }
        public string Gls_nombre_puerto { get { return gls_nombre_puerto; } set { gls_nombre_puerto = value; } }
    }
}
