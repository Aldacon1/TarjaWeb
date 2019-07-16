using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class BultosBO
    {
        public static int cod_bulto_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["cod_bulto_static"]); }
            set { HttpContext.Current.Session["cod_bulto_static"] = value; }
        }

        private int cod_bulto = -1;

        private string desc_bulto = string.Empty;

        public int Cod_bulto { get { return cod_bulto; } set { cod_bulto = value; } }
        public string Desc_bulto { get { return desc_bulto; } set { desc_bulto = value; } }
    }
}
