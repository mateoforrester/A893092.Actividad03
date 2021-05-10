using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A893092.Actividad03
{
    class Validaciones
    {
        public static DateTime ValidarFecha(string titulo)
        {

            bool Flag = false;
            DateTime fecha;
            do
            {
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();

                if (!DateTime.TryParse(ingreso, out fecha))
                {
                    Console.WriteLine("No es una fecha valida");
                    continue;
                }

                if (fecha > DateTime.Now)
                {
                    Console.WriteLine("La fecha debe ser menor a la actual.");
                    continue;
                }

                Flag = true;

            } while (Flag == false);

            return fecha;
        }

        public static int ValidarCodigo(string titulo)
        {
            int codigo;
            bool Flag = false;
            do
            {
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();

                if (!int.TryParse(ingreso, out codigo))
                {
                    Console.WriteLine("Debe ingresar un vaolr numerico");
                    continue;
                }
                if (codigo <= 0)
                {
                    Console.WriteLine("El codigo ingresado debe ser mayor a 0");
                    continue;
                }

                Flag = true;

            } while (Flag == false);

            return codigo;

        }

        public static decimal ValidarMonto(string titulo)
        {
            decimal monto;
            bool Flag = false;

            do
            {
                Console.WriteLine(titulo);
                if (!decimal.TryParse(Console.ReadLine(), out monto))
                {
                    Console.WriteLine("Debe ingresar un valor numerico");
                }
                if (monto <= 0)
                {
                    Console.WriteLine("El monto ingresado debe ser mayor a 0");
                }

                Flag = true;

            } while (Flag == false);

            return monto;
        }
    }
}
