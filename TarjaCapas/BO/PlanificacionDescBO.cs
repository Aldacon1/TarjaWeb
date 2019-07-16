using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBO
{
    public class PlanificacionDescBO
    {
        private string bl = string.Empty,
            pue_codO = string.Empty,
            cod_contenedor = string.Empty,
            cod_iso = string.Empty,
            sello1 = string.Empty,
            sello2 = string.Empty,
            sello3 = string.Empty,
            mddt = string.Empty,
            cod_nave = string.Empty,
            pue_codD = string.Empty,
            cod_manifiesto = string.Empty,
            desbloqueo_sello = string.Empty,
            nombre_cliente = string.Empty,
            selloFis1 = string.Empty,
            selloFis2 = string.Empty,
            selloFis3 = string.Empty;

        private int rut_cliente = -1,
            cod_viaje = -1,
            cod_agencia = -1,
            estado_tarja = -1,
            rut_tarjador = -1;

        private double tara = -1,
            duracion = -1;

        private DateTime fecha = DateTime.Today;
        private DateTime fechaT = DateTime.Today;

        private TimeSpan horaI = new TimeSpan();
        private TimeSpan horaT = new TimeSpan();
        private TimeSpan horaIR = new TimeSpan();
        private TimeSpan horaTR = new TimeSpan();


        public string Bl { get { return bl; } set { bl = value; } }
        public string Pue_codO { get { return pue_codO; } set { pue_codO = value; } }
        public string Cod_contenedor { get { return cod_contenedor; } set { cod_contenedor = value; } }
        public string Cod_iso { get { return cod_iso; } set { cod_iso = value; } }
        public string Sello1 { get { return sello1; } set { sello1 = value; } }
        public string Sello2 { get { return sello2; } set { sello2 = value; } }
        public string Sello3 { get { return sello3; } set { sello3 = value; } }
        public string Mddt { get { return mddt; } set { mddt = value; } }
        public string Cod_nave { get { return cod_nave; } set { cod_nave = value; } }
        public string Pue_codD { get { return pue_codD; } set { pue_codD = value; } }
        public string Cod_manifiesto { get { return cod_manifiesto; } set { cod_manifiesto = value; } }
        public string Desbloqueo_sello { get { return desbloqueo_sello; } set { desbloqueo_sello = value; } }
        public string Nombre_cliente { get { return nombre_cliente; } set { nombre_cliente = value; } }
        public string SelloFis1 { get { return selloFis1; } set { selloFis1 = value; } }
        public string SelloFis2 { get { return selloFis2; } set { selloFis2 = value; } }
        public string SelloFis3 { get { return selloFis3; } set { selloFis3 = value; } }

        public int Rut_cliente { get { return rut_cliente; } set { rut_cliente = value; } }
        public int Cod_viaje { get { return cod_viaje; } set { cod_viaje = value; } }
        public int Cod_agencia { get { return cod_agencia; } set { cod_agencia = value; } }
        public int Estado_tarja { get { return estado_tarja; } set { estado_tarja = value; } }
        public int Rut_tarjador { get { return rut_tarjador; } set { rut_tarjador = value; } }

        public DateTime Fecha { get { return fecha; } set { fecha = value; } }
        public DateTime FechaT { get { return fechaT; } set { fechaT = value; } }

        public TimeSpan HoraI { get { return horaI; } set { horaI = value; } }
        public TimeSpan HoraT { get { return horaT; } set { horaT = value; } }
        public TimeSpan HoraIR { get { return horaIR; } set { horaIR = value; } }
        public TimeSpan HoraTR { get { return horaTR; } set { horaTR = value; } }

        public double Tara { get { return tara; } set { tara = value; } }
        public double Duracion { get { return duracion; } set { duracion = value; } }
    }
}
