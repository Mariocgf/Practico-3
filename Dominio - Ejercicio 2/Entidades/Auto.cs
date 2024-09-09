using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio___Ejercicio_2.Entidades
{
    public class Auto
    {
        public Marca Marca {  get; set; }
        public string Modelo {  get; set; }
        public int Anio { get; set; }
        public bool Tipo { get; set; }
        public string Matricula {  get; set; }
        public DateTime FechaUltServicio { get; set; }

        public Auto(Marca marca, string modelo, int anio, bool tipo, string matricula, DateTime fechaUltServicio)
        {
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Tipo = tipo;
            Matricula = matricula;
            FechaUltServicio = fechaUltServicio;
        }
        private static void ValidarAnioYFechaUltServicio(int anio, DateTime fechaUltServicio)
        {
            if (anio > fechaUltServicio.Year)
            {
                throw new Exception("E-AnioAutoYServicio:El año del auto no puede ser mayor al año del ultimo servicio.");
            }
        }
        private static void ValidarMatricula(string matricula)
        {
            int contLength = 0;
            int contLetra = 0;
            foreach (char elem in matricula)
            {
                if ((elem >= 65) && (elem <= 90))
                {
                    contLength++;
                }
                if ((((int)elem >= 65) && ((int)elem <= 90)) || (((int)elem >= 97) && ((int)elem <= 122)))
                {
                    contLetra++;
                }
            }
            if (matricula.Length != 7 || contLetra != 3)
            {
                throw new Exception("E-MatriculaFormato:La matricula registrada no es valida, la matricula debe tener la fomra (ABC1234)");
            }
        }
        
        public static void Validar(string matricula, int anio, DateTime fechaUltServicio)
        {
            ValidarMatricula(matricula);
            ValidarAnioYFechaUltServicio(anio, fechaUltServicio);
        }

        

        public override string ToString()
        {
            return $"Vehiculo: {Marca.Nombre} ({Marca.PaisOrigen}) {Modelo} del {Anio} - {(Tipo ? "Nuevo" : "Usado")}\nMatricula: {Matricula}\nFecha del ultimo servicio: {FechaUltServicio.ToString("d")}";
        }
    }
}
