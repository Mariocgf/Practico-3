using Dominio___Ejercicio_2;
using Dominio___Ejercicio_2.Entidades;
using System.Text.RegularExpressions;

namespace Ejercicio_2
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {

            _sistema.AgregarMarca("BMW", "Alemania"); // Marca de auto más corta
            _sistema.AgregarMarca("Toyota", "Japon"); // Pais de fabricante de auto más corta - Segun chatGPT
            _sistema.AgregarMarca("Audi", "Alemania");
            _sistema.AgregarMarca("Ford", "USA");
            _sistema.AgregarMarca("Lamborghini", "Italia");

            _sistema.AgregarAuto(_sistema.ObtenerMarca(1), "i8", 2020, false, "ABC7584", new DateTime(2022, 04, 15));
            _sistema.AgregarAuto(_sistema.ObtenerMarca(2), "Hailux", 2018, true, "ABC3164", new DateTime(2019, 10, 24));
            _sistema.AgregarAuto(_sistema.ObtenerMarca(3), "R8", 2018, true, "ABC1234", new DateTime(2023, 08, 12));
            _sistema.AgregarAuto(_sistema.ObtenerMarca(4), "GT", 2019, false, "ABC5678", new DateTime(2024, 02, 22));
            _sistema.AgregarAuto(_sistema.ObtenerMarca(5), "Urus", 2020, true, "ABC9123", new DateTime(2022, 05, 09));

            foreach (Auto auto in _sistema.Autos)
            {
                Console.WriteLine($"{auto}\n{_sistema.ProximoServicio(auto)}\n");
            }
        }

    }
}
