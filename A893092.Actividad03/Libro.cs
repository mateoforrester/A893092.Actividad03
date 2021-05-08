using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A893092.Actividad03
{
    class Libro
    {
        public static List<Registro> registros = new List<Registro>();


        const string ruta = @"C:\Users\i7Lenovo\source\repos\CAI\A893092.Actividad031\Diario.txt";
        static Libro()
        {

            if (File.Exists(ruta))
            {
                using (var reader = new StreamReader(ruta))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var registro = new Registro(linea);
                        registros.Add(registro);
                    }
                }
            }
        }

        public static void Agregar(Registro registro)
        {
            registros.Add(registro);
        }

        public void GrabarLibro()
        {
            using (var writer = new StreamWriter(ruta, append: false))
            {
                writer.WriteLine("NroAsiento|Fecha|CodigoCuenta|Debe|Haber");

                foreach (var registro in registros)
                {
                    var linea = registro.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }
            }
        }

        public int UltimoNumeroDeAsiento()
        {
            int longitudLibro = registros.Count();
            if (longitudLibro == 0)
            {
                return 0;
            }
            return registros.ElementAt(longitudLibro - 1).NroAsiento;
        }

        public void Mostrar()
        {
            Console.WriteLine("NroAsiento|Fecha|CodigoCuenta|Debe|Haber");
            foreach (var registro in registros)
            {
                Console.WriteLine(registro.ObtenerLineaDatos());

            }
        }
    }
}
