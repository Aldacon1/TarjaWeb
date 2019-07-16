using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class LoginBO
    {
        public static int rut_persona_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["rut_persona_static"]); }
            set { HttpContext.Current.Session["rut_persona_static"] = value; }
        }

        private int rut_persona = -1;

        private string dv_persona = string.Empty;
        private string nom_persona = string.Empty;
        private string funcion = string.Empty;
        private string desTerminal = string.Empty;
        private string codTerminal = string.Empty;
        private string esValido = string.Empty;

        public int Rut_persona { get { return rut_persona; } set { rut_persona = value; } }

        public string Dv_persona { get { return dv_persona; } set { dv_persona = value; } }
        public string Nom_persona { get { return nom_persona; } set { nom_persona = value; } }
        public string Funcion { get { return funcion; } set { funcion = value; } }
        public string DesTerminal { get { return desTerminal; } set { desTerminal = value; } }
        public string CodTerminal { get { return codTerminal; } set { codTerminal = value; } }
        public string EsValido { get { return esValido; } set { esValido = value; } }
    }
}
