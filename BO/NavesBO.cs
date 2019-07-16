using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBO
{
    public class NavesBO
    {
        private string nav_cod = string.Empty,
            nav_nom = string.Empty;

        public string Nav_cod { get { return nav_cod; } set { nav_cod = value; } }
        public string Nav_nom { get { return nav_nom; } set { nav_nom = value; } }
    }
}
