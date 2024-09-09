using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio___Ejercicio_3.Entidades
{
    public class Socio
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        private List<Deporte> _deportes = new List<Deporte>();

        public Socio(string nombre, string apellido, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
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
        public static void Validar(string nombre, string apellido, DateTime fechaNacimiento)
        {
            ValidarCaracteres(nombre, "Nombre");
            ValidarCaracteres(apellido, "Apellido");
            EsMayor(fechaNacimiento);
        }

        public void RegistrarADeporte(Deporte deporte)
        {
            if (deporte == null)
            {
                throw new Exception("E-DeporteInvalido:El deporte ingresado es invalido.");
            }else if(_deportes.Count == 2)
            {
                throw new Exception("E-DeporteTope:Ya esta registrado en 2 deporte, no pude registrarse en otro");
            }
            _deportes.Add(deporte);
        }
        public static void EsMayor(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.Month < fechaNacimiento.Month || (DateTime.Now.Month == fechaNacimiento.Month && DateTime.Now.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            if (edad < 18)
            {
                throw new Exception("E-Edad:La persona en menor, no se puede registrar.");
            }
        }
        public override string ToString()
        {
            string deporte = "";
            foreach(Deporte dep in _deportes)
            {
                deporte += $"{dep.Nombre} ";
            }
            return $"Nombre: {Nombre} {Apellido}\nFecha nacimiento: {fechaNacimiento.ToString("d")}\nDeporte/s: {deporte}";
        }
    }
}
