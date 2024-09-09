using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio___Ejercicio_2.Entidades
{
    public class Marca
    {
        public int id { get; set; }
        private static int s_ultimaId;
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }

        public Marca(string nombre, string paisOrigen)
        {
            id = ++s_ultimaId;
            Nombre = nombre;
            PaisOrigen = paisOrigen;
        }
        private static void ValidarNombMarca(string marca)
        {
            int cont = 0;
            foreach (char elem in marca)
            {
                if ((((int)elem >= 65) && ((int)elem <= 90)) || (((int)elem >= 97) && ((int)elem <= 122)))
                {
                    cont++;
                }
            }
            if (cont < 3)
            {
                throw new Exception("E-MarcaTam:La marca no puede tener menos de tres letras");

            }
        }
        private static void ValidarTamanio(string palabra, int tamanio, string tipo)
        {
            int cont = 0;
            foreach (char elem in palabra)
            {
                if ((((int)elem >= 65) && ((int)elem <= 90)) || (((int)elem >= 97) && ((int)elem <= 122)))
                {
                    cont++;
                }
            }
            if (cont < 3)
            {
                throw new Exception($"E-{tipo}Tam:El {tipo.ToLower()} no puede tener menos de {tamanio} letras");

            }
        }
        public static void Validar(string marca, string pais)
        {
            ValidarTamanio(marca, 3, "Marca");
            ValidarTamanio(pais, 5, "Pais");
        }

        public override string ToString()
        {
            return $"Nombre de marca: {Nombre}\nPais de origen: {PaisOrigen}\n";
        }
    }
}
