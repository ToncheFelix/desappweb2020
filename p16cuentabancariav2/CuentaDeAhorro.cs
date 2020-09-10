using System;

namespace p15cuentabancariav1
{
    class CuentaDeAhorro : CuentaBancaria{
        private double tasadeinteres;
        public CuentaDeAhorro(double saldo, double tasadeinteres)
            : base(saldo) //llamada explicita al constructor base
                {
                    this.tasadeinteres=tasadeinteres;
                }
        public void CalcularInteres(){
            saldo+=(saldo*tasadeinteres);
        }
        
    }
}