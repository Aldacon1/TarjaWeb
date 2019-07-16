using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBO
{
    public class PlanificacionDespBO
    {
        public Int64 Nro_tarja { get; set; }
        public int Rut_cliente { get; set; }
        public string Cod_puerto_or { get; set; }
        public string Cod_puerto_Dest { get; set; } 
        public string Cod_transporte { get; set; }
        public int N_vuelta { get; set; }
        public string Patente { get; set; }
        public int Rut_tarjador { get; set; }
        public DateTime Fecha { get; set; }
        public int N_estado { get; set; }
        public int Cod_terminal { get; set; }
        public TimeSpan Hora_inicio { get; set; }
        public TimeSpan Hora_termino { get; set; }
        public DateTime Fecha_termino { get; set; }
        public string Observacion { get; set; }
        public Decimal Duracion { get; set; }
        public string Guia { get; set; }
    }
}
