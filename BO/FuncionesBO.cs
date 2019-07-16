using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class FuncionesBO
    {
        public static int fun_cod_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["fun_cod_static"]); }
            set { HttpContext.Current.Session["fun_cod_static"] = value; }
        }

        private int fun_cod = -1,
            per_cod = -1;

        private string fun_nom = string.Empty;

        public int Fun_cod { get { return fun_cod; } set { fun_cod = value; } }
        public int Per_cod { get { return per_cod; } set { per_cod = value; } }
        public string Fun_nom { get { return fun_nom; } set { fun_nom = value; } }
    }
}
