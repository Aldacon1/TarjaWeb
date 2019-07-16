using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBO
{
    public class MercanciasDescBO
    {
        public Int64 Cod_mercancia { get; set; }
        public Int64 Nro_tarja { get; set; }
        public string Desc_bulto { get; set; }
        public string Gls_marca { get; set; }
        public int N_cantidad { get; set; }
        public string Gls_retiro { get; set; }
        public string Gls_condicion { get; set; }
        public string Observacion { get; set; }
    }
}
