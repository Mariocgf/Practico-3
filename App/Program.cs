using Dominio;
using Dominio.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {

            bool exit = false;
            do
            {
                Console.WriteLine("1) Alta de cliente\n2) Listar clientes\n3) Depositar\n4) Retirar");
                switch (InputNumber("Seleccione una opcion ó 0 para salir"))
                {
                    case 1:
                        AgregarCliente();
                        break;
                    case 2:
                        Console.Clear();
                        MostrarClientes();
                        break;
                    case 3:
                        Console.Clear();
                        Depositar();
                        break;
                    case 4:
                        Console.Clear();
                        Retirar();
                        break;
                    case 0:
                        exit = true;
                        break;
                }
            }
            while (!exit);

        }

        public static void AgregarCliente()
        {
            string cedula, nombre, apellido, tipoMoneda, codeError = "";
            bool ok = false;
            Console.Clear();
            Console.WriteLine("--- ALTA DE CLIENTE ---");
            cedula = InputString("Ingrese la cedula del cliente - Formato (1234567-8)");
            nombre = InputString("Ingrese el nombre del cliente");
            apellido = InputString("Ingrese el apellido del cliente");
            tipoMoneda = SeleccionarOpcion("Tipos de moneda", new string[] { "UYU", "USD", "ARS" });

            do
            {
                try
                {
                    switch (codeError)
                    {
                        case "E-CedulaFormato":
                            cedula = InputString("Ingrese la cedula del cliente - Formato (1234567-8)");
                            break;
                        case "E-CedulaExistente":
                            cedula = InputString("Ingrese la cedula del cliente");
                            break;
                        case "E-CaracterNombre":
                            nombre = InputString("Ingrese el nombre del cliente");
                            break;
                        case "E-CaracterApellido":
                            apellido = InputString("Ingrese el apellido del cliente");
                            break;
                        case "E-TipoMoneda":
                            tipoMoneda = SeleccionarOpcion("Tipos de moneda", new string[] { "UYU", "USD", "ARS" });
                            break;
                    }
                    _sistema.AgregarCliente(cedula, nombre, apellido, tipoMoneda);
                    Console.Clear();
                    Mensaje("Cliente ingresado correctamente!", "OK");
                    ok = true;
                }
                catch (Exception error)
                {
                    codeError = error.Message.Split(":")[0];
                    Mensaje(error.Message.Split(":")[1], "ERROR");
                }
            }
            while (!ok);


        }
        public static void MostrarClientes()
        {
            foreach (Cliente cliente in _sistema.Clientes)
            {
                Console.WriteLine(cliente);
            }
        }
        public static void Depositar()
        {
            int nroCuenta;
            decimal monto;
            string codeError = "";
            bool ok = false, existe = true;
            nroCuenta = InputNumber("Ingrese el numero de cuenta");
            monto = InputNumber("Ingrese el monto a depositar");
            do
            {
                try
                {
                    switch (codeError)
                    {
                        case "E-MontoNegativo":
                            monto = InputNumber("Ingrese el monto a depositar");
                            break;
                        case "E-NroCuentaNoReg":
                            existe = false;
                            break;
                    }
                    if (existe)
                    {
                        _sistema.Depositar(nroCuenta, monto);
                        Mensaje("Deposito realizado correctamente!", "OK");
                    }
                    ok = true;
                }
                catch (Exception error)
                {
                    codeError = error.Message.Split(':')[0];
                    Mensaje(error.Message.Split(":")[1], "ERROR");
                }
            }
            while (!ok);
        }
        public static void Retirar()
        {
            int nroCuenta;
            decimal monto;
            string codeError = "";
            bool ok = false, existe = true;
            nroCuenta = InputNumber("Ingrese el numero de cuenta");
            monto = InputNumber("Ingrese el monto a retirar");
            do
            {
                try
                {
                    switch (codeError)
                    {
                        case "E-MontoNegativo":
                            monto = InputNumber("Ingrese el monto a retirar");
                            break;
                        case "E-MontoSuperior":
                            monto = InputNumber("Ingrese el monto a retirar");
                            break;
                        case "E-NroCuentaNoReg":
                            existe = false;
                            break;
                    }
                    if (existe)
                    {
                        _sistema.Retirar(nroCuenta, monto, "");
                        Mensaje("Retiro realizado correctamente!", "OK");
                    }
                    ok = true;
                }
                catch (Exception error)
                {
                    codeError = error.Message.Split(':')[0];
                    Mensaje(error.Message.Split(":")[1], "ERROR");
                }
            }
            while (!ok);
        }

        // Metodos de entrada
        public static string SeleccionarOpcion(string msj, string[] opciones)
        {
            int cont = 0;
            Console.WriteLine($"{msj} :");
            foreach (string opcion in opciones)
            {
                Console.WriteLine($"{++cont}) {opcion}");
            }
            do
            {
                try
                {
                    return opciones[InputNumber("Seleccione una opcion") - 1];

                }
                catch (Exception)
                {
                    Mensaje("Valor ingresado incorrecto", "ERROR");
                }
            }
            while (true);
        }
        public static string InputString(string msg)
        {
            Console.Write($"{msg}: ");
            return Console.ReadLine();
        }
        public static int InputNumber(string msj)
        {
            int number;
            do
            {
                try
                {
                    Console.Write($"{msj}: ");
                    number = int.Parse(Console.ReadLine());
                    return number;
                }
                catch (Exception)
                {
                    Mensaje("Valor incorrecto, debe ingresar un numero", "ERROR");
                }
            }
            while (true);
        }

        // Metodo de salida
        public static void Mensaje(string msj, string tipo)
        {
            switch (tipo)
            {
                case "OK":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(msj);
                    Console.ResetColor();
                    break;
                case "ERROR":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msj);
                    Console.ResetColor();
                    break;
            }
        }
    }
}
