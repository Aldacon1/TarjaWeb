using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaBO
{
    public class PermisosBO
    {
        public static int per_cod_static
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["per_cod_static"]); }
            set { HttpContext.Current.Session["per_cod_static"] = value; }
        }

        private int per_cod = -1;

        private string permiso = string.Empty;

        private bool web = false;
        private bool movil = false;

        public int Per_cod { get { return per_cod; } set { per_cod = value; } }
        public string Permiso { get { return permiso; } set { permiso = value; } }

        public bool Web { get { return web; } set { web = value; } }
        public bool Movil { get { return movil; } set { movil = value; } }
    }
}
