using Dominio___Ejercicio_2.Entidades;

namespace Dominio___Ejercicio_2
{
    public class Sistema
    {
        private List<Auto> _autos = new List<Auto>();
        private List<Marca> _marcas = new List<Marca>();


        public List<Auto> Autos { get { return _autos; } }
        public List<Marca> Marcas { get { return _marcas; } }

        private void EsUnicaMatricula(string matricula)
        {
            foreach (Auto auto in _autos)
            {
                if (auto.Matricula.Equals(matricula))
                {
                    throw new Exception($"E-MatriculaExistente:Esta matricula ({matricula}) ya esta asociada a un auto.");
                }
            }
        }
        public void AgregarMarca(string nombre, string pais)
        {
            Marca.Validar(nombre, pais);
            _marcas.Add(new Marca(nombre, pais));
        }
        public void AgregarAuto(Marca marca, string modelo, int anio, bool tipo, string matricula, DateTime fechaUltServicio)
        {
            if (marca == null)
            {
                throw new Exception("E-MarcaInvalida:La marca de ingresada es invalida.");
            }
            Auto.Validar(matricula, anio, fechaUltServicio);
            EsUnicaMatricula(matricula);
            _autos.Add(new Auto(marca, modelo, anio, tipo, matricula, fechaUltServicio));
        }
        public Marca ObtenerMarca(int id)
        {
            foreach (Marca marca in _marcas)
            {
                if (marca.id == id) return marca;
            }
            return null;
        }
        public string ProximoServicio(Auto auto)
        {

            return $"Proximo servicio: {auto.FechaUltServicio.Date.AddYears(1).ToString("d")}";
        }
    }
}
