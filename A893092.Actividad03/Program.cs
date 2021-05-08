using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A893092.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            Libro libro = new Libro();
            Plan plan = new Plan();


            var opcion = "";
            do
            {
                Console.WriteLine();
                Console.WriteLine("INGRESO DE ASIENTOS");
                Console.WriteLine("--------------");

                Console.WriteLine("A. Agregar");
                Console.WriteLine("S. Salir");

                Console.WriteLine("Ingrese una opcion y presione [Enter]");

                opcion = Console.ReadLine();
                switch (opcion.ToUpper())
                {
                    case "A":
                        AgregarAsiento(plan, libro);
                        break;

                    case "S":
                        Salir(libro);
                        break;

                    default:
                        Console.WriteLine("No ha ingresado una opcion del menu.");
                        break;
                }

            } while (opcion != "S");
        }

        private static void AgregarAsiento(Plan plan, Libro libro)
        {

            Console.WriteLine("NUEVO ASIENTO");

            DateTime fecha = Validaciones.ValidarFecha("Ingrese la fecha del asiento");

            var numeroAsiento = libro.UltimoNumeroDeAsiento() + 1;
            var codigoCuentaDebe = Validaciones.ValidarCodigo("Ingrese el codigo de cuenta del debe");
            var montoDebe = Validaciones.ValidarMonto("Ingrese el monto del debe");
            var codigoCuentaHaber = Validaciones.ValidarCodigo("Ingrese el codigo de cuenta del haber");
            var montoHaber = Validaciones.ValidarMonto("Ingrese el monto del haber");

            Asiento asiento = new Asiento(numeroAsiento, fecha, codigoCuentaDebe, codigoCuentaHaber, montoDebe, montoHaber);

            asiento.MostrarDatos();

            bool asientoValido = asiento.ValidarDatos(plan);

            if (asientoValido)
            {
                Libro.Agregar(asiento.registroDebe);
                Libro.Agregar(asiento.registroHaber);
                Console.WriteLine("Asiento agregado correctamente");
            }
            else
            {
                Console.WriteLine("Asiento no valido");
            }

        }


        private static void Salir(Libro libro)
        {
            libro.Mostrar();
            libro.GrabarLibro();
        }
    }
}
