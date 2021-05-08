using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A893092.Actividad03
{
    class Plan
    {
        public static List<Cuenta> cuentas = new List<Cuenta>();

        static Plan()
        {
            string ruta = @"C:\Users\i7Lenovo\source\repos\CAI\A893092.Actividad031\Plan de cuentas.txt";
            if (File.Exists(ruta))
            {
                using (var reader = new StreamReader(ruta))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var cuenta = new Cuenta(linea);
                        cuentas.Add(cuenta);
                    }
                }
            }
        }

        public void ListarPlan()
        {
            Console.WriteLine($" Codigo | Nombre | Tipo");
            foreach (Cuenta cuenta in cuentas)
            {

                Console.WriteLine($" {cuenta.Codigo} | {cuenta.Nombre} | {cuenta.Tipo}");
            }
        }

        public bool Existe(int codigoCuenta)
        {

            foreach (Cuenta cuenta in cuentas)
            {
                if (cuenta.Codigo == codigoCuenta)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
