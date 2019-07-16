using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBO
{
    public class GruasDescBO
    {
        private string grua_cod = string.Empty,
            patente = string.Empty,
            marcamod = string.Empty;

        private int cod_term = -1;

        public string Grua_cod { get { return grua_cod; } set { grua_cod = value; } }
        public string Patente { get { return patente; } set { patente = value; } }
        public string MarcaMod { get { return marcamod; } set { marcamod = value; } }
        public int Cod_term { get { return cod_term; } set { cod_term = value; } }
    }
}
