using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class IsoDescBO
    {
        public static string cod_bulto_static
        {
            get { return HttpContext.Current.Session["cod_bulto_static"].ToString(); }
            set { HttpContext.Current.Session["cod_bulto_static"] = value; }
        }

        private string iso_cod = string.Empty;
        private string iso_nom = string.Empty;

        private double iso_tara = -1;

        public string Iso_cod { get { return iso_cod; } set { iso_cod = value; } }
        public string Iso_nom { get { return iso_nom; } set { iso_nom = value; } }

        public double Iso_tara { get { return iso_tara; } set { iso_tara = value; } }
    }
}
