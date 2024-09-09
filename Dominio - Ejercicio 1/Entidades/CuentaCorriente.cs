using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio___Ejercicio_1.Entidades
{
    public enum Divisa
    {
        UYU = 858,
        USD = 840,
        ARS = 032
    }
    public class CuentaCorriente
    {
        public int NumeroCuenta { get; set; }
        public Divisa TipoMoneda { get; set; }
        public decimal Saldo { get; set; }
        public int MovDeposito { get; set; }

        public CuentaCorriente(int numeroCuenta, Divisa tipoMoneda)
        {
            NumeroCuenta = numeroCuenta;
            TipoMoneda = tipoMoneda;
            Saldo = 0;
        }

        public override string ToString()
        {
            return $"Numero de cuenta: {NumeroCuenta}\nTipo de moneda: {TipoMoneda}\nSaldo: {Saldo}";
        }
    }
}
