using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A893092.Actividad03
{
    class Asiento
    {
        public Registro registroDebe = new Registro();

        public Registro registroHaber = new Registro();


        public Asiento(int numeroAsiento, DateTime fecha, int codigoCuentaDebe, int codigoCuentaHaber, decimal montoDebe, decimal montoHaber)
        {
            registroDebe.NroAsiento = numeroAsiento;
            registroDebe.Fecha = fecha;
            registroDebe.CodCuenta = codigoCuentaDebe;
            registroDebe.Debe = montoDebe;
            registroDebe.Haber = 0;

            registroHaber.NroAsiento = numeroAsiento;
            registroHaber.Fecha = fecha;
            registroHaber.CodCuenta = codigoCuentaHaber;
            registroHaber.Debe = 0;
            registroHaber.Haber = montoHaber;

        }

        public Asiento()
        {
        }

        public void MostrarDatos()
        {
            Console.WriteLine("Registro DEBE:");
            Console.WriteLine(registroDebe.ObtenerLineaDatos());

            Console.WriteLine("Registro HABER:");
            Console.WriteLine(registroHaber.ObtenerLineaDatos());
        }

        public bool ValidarDatos(Plan plan)
        {
            if (!plan.Existe(registroDebe.CodCuenta) || !plan.Existe(registroHaber.CodCuenta))
            {
                Console.WriteLine("El codigo ingresado no se encuentra en el Plan de Cuentas");
                return false;
            }

            if (registroDebe.Debe != registroHaber.Haber)
            {
                Console.WriteLine("El DEBE y HABER deben ser iguales");
                return false;
            }
            return true;
        }
    }
}
