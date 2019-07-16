using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class ForwardersBO
    {
        public static int rut_cliente_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["rut_cliente_static"]); }
            set { HttpContext.Current.Session["rut_cliente_static"] = value; }
        }

        private int rut_cliente = -1,
            fono_cliente = -1;

        private string nombre_cliente = string.Empty;
        private string pass_cliente = string.Empty;
        private string email_cliente = string.Empty;
        private string dv_cliente = string.Empty;

        public int Rut_cliente { get { return rut_cliente; } set { rut_cliente = value; } }
        public int Fono_cliente { get { return fono_cliente; } set { fono_cliente = value; } }

        public string Nombre_cliente { get { return nombre_cliente; } set { nombre_cliente = value; } }
        public string Pass_cliente { get { return pass_cliente; } set { pass_cliente = value; } }
        public string Email_cliente { get { return email_cliente; } set { email_cliente = value; } }
        public string Dv_cliente { get { return dv_cliente; } set { dv_cliente = value; } }
    }
}
