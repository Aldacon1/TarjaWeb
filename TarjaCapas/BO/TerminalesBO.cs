using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class TerminalesBO
    {
        public static int age_cod_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["age_cod_static"]); }
            set { HttpContext.Current.Session["age_cod_static"] = value; }
        }

        private int age_cod = -1;

        private string age_nom = string.Empty;

        public int Age_cod { get { return age_cod; } set { age_cod = value; } }
        public string Age_nom { get { return age_nom; } set { age_nom = value; } }
    }
}
