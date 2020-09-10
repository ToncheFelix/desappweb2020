using System;

namespace p15cuentabancariav1
{
    class CuentaDeCheques :CuentaBancaria {
        private double proteccionsobregiro;
        public CuentaDeCheques(double saldo, double proteccionsobregiro)
            : base(saldo)
        {
            this.proteccionsobregiro=proteccionsobregiro;
        }
        public override bool Retira(double cantidad){ //sobrecarga el método Retira
            bool resultado = true;
            double proteccionrequerida = cantidad - saldo;
            if (proteccionsobregiro < proteccionrequerida) 
            {
                return false;
            }
            else {
                saldo = 0.0;
                proteccionsobregiro-=proteccionrequerida;    
            }
            return resultado;
        }

    }

}