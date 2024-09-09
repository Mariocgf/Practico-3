
using System.Reflection.Metadata.Ecma335;

namespace Dominio___Ejercicio_3.Entidades
{
    public class Deporte
    {
        public string Nombre { get; set; }
        public bool EsGrupal { get; set; }
        public int CantProfesores { get; set; }

        public Deporte(string nombre, bool esGrupal, int cantProfesores)
        {
            Nombre = nombre;
            EsGrupal = esGrupal;
            CantProfesores = cantProfesores;
        }
        public static void ValidarCaracteres(string letra, string tipo)
        {
            // 65-90 97-122 caracteres (mayusculas y minusculas)
            // (225-233-237-243-250) = á, é, í, ó, ú
            // (193-201-205-211-218) =  Á, É, Í, Ó, Ú

            int[] caracteresEspeciales = new int[] { 193, 201, 205, 211, 218, 225, 233, 237, 243, 250 };
            int cont = 0;
            foreach (char c in letra)
            {
                if (caracteresEspeciales.Contains((int)c) || ((int)c >= 65 && (int)c <= 90) || ((int)c >= 97 && (int)c <= 122))
                {
                    cont++;
                }
            }
            if (cont != letra.Length)
            {
                throw new Exception($"E-Caracter{tipo}:{tipo} con caracter/es invalido/s");
            }
        }
        public static void Validar(string nombre, int cantProfesores)
        {
            ValidarCaracteres(nombre, "Nombre");
            if (cantProfesores < 0)
            {
                throw new Exception("E-CantProf:El deporte debe tener al menos un profesor");
            }
        }

        public int CosteDeporte()
        {
            return CantProfesores * 1500;
        }
    }
}
