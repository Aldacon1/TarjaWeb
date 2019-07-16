using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBO
{
    public class PlanificacionConsBO
    {
        private Int64 nro_tarja = -1;
        private int rut_cliente = -1,
            n_viaje = -1,
            rut_tarjador = -1,
            cod_estado_tarja = -1,
            cod_terminal = -1,
            cod_estado_sinc = -1;

        private string cod_puerto_or = string.Empty,
            cod_puerto_dest = string.Empty,
            cod_nave = string.Empty,
            gls_contenedor = string.Empty,
            cod_iso = string.Empty,
            gls_sello = string.Empty,
            gls_reserva = string.Empty,
            observacion = string.Empty;

        private decimal f_capacidad = -1,
            duracion = -1;

        private DateTime fecha = new DateTime(),
            fecha_termino = new DateTime();

        private TimeSpan hora_inicio = new TimeSpan(),
            hora_termino = new TimeSpan();


        public Int64 Nro_tarja { get { return nro_tarja; } set { nro_tarja = value; } }
        public int Rut_cliente { get { return rut_cliente; } set { rut_cliente = value; } }
        public int N_viaje { get { return n_viaje; } set { n_viaje = value; } }
        public int Rut_tarjador { get { return rut_tarjador; } set { rut_tarjador = value; } }
        public int Cod_estado_tarja { get { return cod_estado_tarja; } set { cod_estado_tarja = value; } }
        public int Cod_terminal { get { return cod_terminal; } set { cod_terminal = value; } }
        public int Cod_estado_sinc { get { return cod_estado_sinc; } set { cod_estado_sinc = value; } }
        public string Cod_puerto_or { get { return cod_puerto_or; } set { cod_puerto_or = value; } }
        public string Cod_puerto_dest { get { return cod_puerto_dest; } set { cod_puerto_dest = value; } }
        public string Cod_nave { get { return cod_nave; } set { cod_nave = value; } }
        public string Gls_contenedor { get { return gls_contenedor; } set { gls_contenedor = value; } }
        public string Cod_iso { get { return cod_iso; } set { cod_iso = value; } }
        public string Gls_sello { get { return gls_sello; } set { gls_sello = value; } }
        public string Gls_reserva { get { return gls_reserva; } set { gls_reserva = value; } }
        public string Observacion { get { return observacion; } set { observacion = value; } }
        public decimal F_capacidad { get { return f_capacidad; } set { f_capacidad = value; } }
        public decimal Duracion { get { return duracion; } set { duracion = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }
        public DateTime Fecha_termino { get { return fecha_termino; } set { fecha_termino = value; } }
        public TimeSpan Hora_inicio { get { return hora_inicio; } set { hora_inicio = value; } }
        public TimeSpan Hora_termino { get { return hora_termino; } set { hora_termino = value; } }
    }
}
