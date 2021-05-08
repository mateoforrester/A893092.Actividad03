using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A893092.Actividad03
{
    class Registro
    {
        public int CodCuenta { get; set; }
        public int NroAsiento { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }


        public Registro(string linea)
        {
            var datos = linea.Split('|');
            NroAsiento = int.Parse(datos[0]);
            Fecha = DateTime.Parse(datos[1]);
            CodCuenta = int.Parse(datos[2]);
            Debe = decimal.Parse(datos[3]);
            Haber = decimal.Parse(datos[4]);
        }

        public Registro()
        {
        }

        public string ObtenerLineaDatos()
        {
            return $"{NroAsiento}|{Fecha}|{CodCuenta}|{Debe}|{Haber}";
        }
    }
}
