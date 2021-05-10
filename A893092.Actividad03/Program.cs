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

            } while (opcion.ToUpper() != "S");
        }

        private static void AgregarAsiento(Plan plan, Libro libro)
        {
            Console.WriteLine("NUEVO ASIENTO");

            DateTime fecha = Validaciones.ValidarFecha("Ingrese la fecha del asiento");

            var numeroAsiento = libro.UltimoNumeroDeAsiento() + 1;

            bool Flag1 = false;
            bool Flag2 = false;

            var codigoCuentaDebe = 0;
            var codigoCuentaHaber = 0;
            decimal montoDebe = 0;
            decimal montoHaber = 0;



            do
            {
                codigoCuentaDebe = Validaciones.ValidarCodigo("Ingrese el codigo de cuenta del debe");
                if (!plan.Existe(codigoCuentaDebe))
                {
                    Console.WriteLine("El codigo ingresado no se encuentra en el Plan de Cuentas");
                }
                else
                {
                    Flag1 = true;
                }
            } while (Flag1 == false);

            
            do
            {
                codigoCuentaHaber = Validaciones.ValidarCodigo("Ingrese el codigo de cuenta del haber");
                if (!plan.Existe(codigoCuentaHaber))
                {
                    Console.WriteLine("El codigo ingresado no se encuentra en el Plan de Cuentas");
                }
                else
                {
                    if (codigoCuentaHaber == codigoCuentaDebe)
                    {
                        Console.WriteLine("Debe ingresar una cuenta distinta a la del debe");
                    }
                    else
                    {
                        Flag2 = true;
                    }
                    
                }
            } while (Flag2 == false);


            do
            {
                montoDebe = Validaciones.ValidarMonto("Ingrese el monto del debe");
                montoHaber = Validaciones.ValidarMonto("Ingrese el monto del haber");

                if (montoDebe != montoHaber)
                {
                    Console.WriteLine("El monto del DEBE y del HABER deben ser iguales");
                    continue;
                }
                break;


            } while (true);

         
     

            Asiento asiento = new Asiento(numeroAsiento, fecha, codigoCuentaDebe, codigoCuentaHaber, montoDebe, montoHaber);

            asiento.MostrarDatos();

            bool asientoValido = asiento.RevalidarDatos(plan);

            if (asientoValido)
            {
                Libro.Agregar(asiento.registroDebe);
                Libro.Agregar(asiento.registroHaber);
                Console.WriteLine();
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
