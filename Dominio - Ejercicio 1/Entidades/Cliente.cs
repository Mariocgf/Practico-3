
namespace Dominio___Ejercicio_1.Entidades
{
    public class Cliente
    {
        public string Cedula { get; set; }
        public string NombreComp { get; set; }
        public CuentaCorriente CuentaCorriente { get; set; }

        public Cliente(string cedula, string nombreComp, CuentaCorriente cuentaCorriente)
        {
            Cedula = cedula;
            NombreComp = nombreComp;
            CuentaCorriente = cuentaCorriente;
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
        public static void ValidarFormatoCedula(string cedula)
        {
            int contNum = 0, contCaracteres = 0;
            foreach (char c in cedula)
            {
                if ((int)c >= 48 && (int)c <= 57)
                {
                    contNum++;
                    contCaracteres++;
                }
                else if ((int)c == 45)
                {
                    contCaracteres++;
                }
            }
            // Valida el formato de cedula -> 1234567-8
            if (contCaracteres != 9 || contNum != 8)
            {
                throw new Exception("E-CedulaFormato:Formato de la cedula no respetado.");
            }
        }
        public static void Verificar(string cedula, string nombre, string apellido)
        {
            ValidarFormatoCedula(cedula);
            ValidarCaracteres(nombre, "Nombre");
            ValidarCaracteres(apellido, "Apellido");
        }

        public override string ToString()
        {
            return $"Cliente: {NombreComp} - {Cedula}\n{CuentaCorriente}\n";
        }
    }
}
