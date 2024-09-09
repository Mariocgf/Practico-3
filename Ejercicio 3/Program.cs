using Dominio___Ejercicio_3;
using Dominio___Ejercicio_3.Entidades;

namespace Ejercicio_3
{
    internal class Program
    {
        static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            _sistema.RegistrarSocio("Juan", "Perez", new DateTime(2002,08,15));
            _sistema.RegistrarSocio("Ana", "Lopez", new DateTime(2006,05,20));
            _sistema.RegistrarSocio("Sofia", "Lopez", new DateTime(2005,04,10));
            _sistema.RegistrarDeporte("Futbol", true, 3);
            _sistema.RegistrarDeporte("Tenis", true, 1);
            _sistema.RegistrarDeporte("Golf", false, 1);
            _sistema.RegistrarDeporte("Natacion", true, 2);
            Socio s1 = _sistema.Socios[0];
            Socio s2 = _sistema.Socios[1];
            Socio s3 = _sistema.Socios[2];
            s1.RegistrarADeporte(_sistema.Deportes[1]);
            s1.RegistrarADeporte(_sistema.Deportes[2]);
            s2.RegistrarADeporte(_sistema.Deportes[0]);
            s2.RegistrarADeporte(_sistema.Deportes[1]);
            s3.RegistrarADeporte(_sistema.Deportes[3]);

            foreach(Socio socio in _sistema.Socios)
            {
                Console.WriteLine(socio);
            }
        }
    }
}
