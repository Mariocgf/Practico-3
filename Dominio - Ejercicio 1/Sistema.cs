
using Dominio___Ejercicio_1.Entidades;

namespace Dominio___Ejercicio_1
{
    public class Sistema
    {
        private List<Cliente> _clientes = new List<Cliente>();
        private List<CuentaCorriente> _cuentaCorrientes = new List<CuentaCorriente>();

        public List<Cliente> Clientes { get { return _clientes; } }
        public List<CuentaCorriente> CuentasCorrientes { get { return _cuentaCorrientes; } }

        private void ValidarCedulaUnica(string cedula)
        {
            foreach (Cliente cliente in _clientes)
            {
                if (cliente.Cedula.Equals(cedula))
                {
                    throw new Exception("E-CedulaExistente:La cedula ingresada ya esta registrada.");
                }
            }
        }
        private CuentaCorriente GenerarCuenta(string moneda)
        {
            int numeroCuenta;
            bool ok;
            Random rnd = new Random();
            do
            {
                ok = true;
                numeroCuenta = rnd.Next(1, 100);
                foreach (CuentaCorriente cuenta in _cuentaCorrientes)
                {
                    if (cuenta.NumeroCuenta == numeroCuenta)
                    {
                        ok = false;
                    }
                }
            }
            while (!ok);

            switch (moneda)
            {
                case "UYU":
                    return new CuentaCorriente(numeroCuenta, Divisa.UYU);
                case "USD":
                    return new CuentaCorriente(numeroCuenta, Divisa.USD);
                case "ARS":
                    return new CuentaCorriente(numeroCuenta, Divisa.ARS);
                default:
                    throw new Exception("E-TipoMoneda:Tipo de moneda no valido");
            }
        }
        private CuentaCorriente ObtenerCuenta(int nroCuenta)
        {
            foreach (CuentaCorriente cuenta in _cuentaCorrientes)
            {
                if (cuenta.NumeroCuenta == nroCuenta)
                {
                    return cuenta;
                }
            }
            throw new Exception("E-NroCuentaNoReg:El numero de cuenta no registrado.");
        }
        public void AgregarCliente(string cedula, string nombre, string apellido, string tipoMoneda)
        {
            CuentaCorriente cuenta;
            Cliente.Verificar(cedula, nombre, apellido);
            ValidarCedulaUnica(cedula);
            cuenta = GenerarCuenta(tipoMoneda);
            _cuentaCorrientes.Add(cuenta);
            _clientes.Add(new Cliente(cedula, $"{nombre} {apellido}", cuenta));
        }
        public void Depositar(int nroCuenta, decimal monto)
        {
            CuentaCorriente cuenta = ObtenerCuenta(nroCuenta);
            if (monto < 0)
            {
                throw new Exception("E-MontoNegativo:El monto ingresado es incorrecto, no puede ser negativo.");
            }
            cuenta.Saldo += monto;
            cuenta.MovDeposito++;
            if (cuenta.MovDeposito > 3)
            {
                switch (cuenta.TipoMoneda)
                {
                    case Divisa.UYU:
                        cuenta.Saldo -= 100;
                        break;
                    case Divisa.USD:
                        cuenta.Saldo -= 100 / 41.6m;
                        break;
                    case Divisa.ARS:
                        cuenta.Saldo -= 100 / 0.0346m;
                        break;
                }
            }
        }
        public void Retirar(int nroCuenta, decimal monto, string moneda)
        {
            CuentaCorriente cuenta = ObtenerCuenta(nroCuenta);
            if (monto < 0)
            {
                throw new Exception("E-MontoNegativo:El monto ingresado es incorrecto, no puede ser negativo.");
            }
            else if (monto > cuenta.Saldo)
            {
                throw new Exception("E-MontoSuperior:El monto ingresado es mayor al saldo.");
            }
            cuenta.Saldo -= monto;
        }


    }
}
