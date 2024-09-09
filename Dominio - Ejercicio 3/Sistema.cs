using Dominio___Ejercicio_3.Entidades;

namespace Dominio___Ejercicio_3
{
    public class Sistema
    {
        private List<Socio> _socios = new List<Socio> ();
        private List<Deporte> _deporte = new List<Deporte> ();

        public List<Socio> Socios { get { return _socios; } }
        public List<Deporte> Deportes { get { return _deporte; } }

        public void RegistrarSocio(string nombre, string apellido, DateTime fechaNacimiento)
        {
            Socio.Validar(nombre, apellido, fechaNacimiento);
            _socios.Add(new Socio(nombre, apellido, fechaNacimiento));
        }
        public void RegistrarDeporte(string nombre, bool esGrupal, int cantProfesores)
        {
            Deporte.Validar(nombre, cantProfesores);
            _deporte.Add(new Deporte(nombre, esGrupal, cantProfesores));
        }
    }
}
