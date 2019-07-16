using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class PersonasBO
    {
        public static int rut_persona_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["rut_persona_static"]); }
            set { HttpContext.Current.Session["rut_persona_static"] = value; }
        }

        private int rut_persona = -1;
        private string fun_cod = string.Empty,
            age_cod = string.Empty;

        private string pass_persona = string.Empty;
        private string nom_persona = string.Empty;
        private string dv_persona = string.Empty;

        public int Rut_persona { get { return rut_persona; } set { rut_persona = value; } }
        public string Fun_cod { get { return fun_cod; } set { fun_cod = value; } }
        public string Age_cod { get { return age_cod; } set { age_cod = value; } }

        public string Pass_persona { get { return pass_persona; } set { pass_persona= value; } }
        public string Nom_persona { get { return nom_persona; } set { nom_persona = value; } }
        public string Dv_persona { get { return dv_persona; } set { dv_persona = value; } }
    }
}
