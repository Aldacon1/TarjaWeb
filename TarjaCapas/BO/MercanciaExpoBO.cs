using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBO
{
    public class MercanciaExpoBO
    {
        public Int64 Cod_mercancia { get; set; }
        public string Nro_documento { get; set; }
        public Int64 Nro_tarja { get; set; }
        public string Gls_marca { get; set; }
        public string Gls_contenido { get; set; }
        public int N_bulto { get; set; }
        public int N_bulto_sec { get; set; }
        public decimal F_peso { get; set; }
        public decimal F_alto { get; set; }
        public decimal F_ancho { get; set; }
        public decimal F_largo { get; set; }
        public int N_cantidad { get; set; }
        public string Gls_observacion { get; set; }
    }
}
