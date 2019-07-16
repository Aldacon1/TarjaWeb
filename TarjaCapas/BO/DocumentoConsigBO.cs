using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBO
{
    public class DocumentoConsigBO
    {
        public string Nro_documento { get; set; }
        public int Tipo_documento { get; set; }
        public Int64 Nro_tarja { get; set; }
        public string Gls_dres { get; set; }
        public string Gls_consignante { get; set; }
        public string Gls_consignatario { get; set; }
        public string Gls_despachante { get; set; }
        public int n_estado_doc { get; set; }
    }
}
