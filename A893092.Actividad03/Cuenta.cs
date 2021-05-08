using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A893092.Actividad03
{
    class Cuenta
    {
        public int Codigo { get; }
        public string Nombre { get; }
        public string Tipo { get; }


        public Cuenta(string linea)
        {
            var datos = linea.Split('|');
            Codigo = int.Parse(datos[0]);
            Nombre = (datos[1]);
            Tipo = (datos[2]);
        }

        public Cuenta()
        {

        }

    }
}
