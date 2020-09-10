
using System;

namespace p15cuentabancariav1
{
    class CuentaBancaria 
    {
        protected double saldo; // protejido para poder ser accedido por las clases que lo hereden
        public CuentaBancaria(double saldo){ // constructor
            this.saldo = saldo;
            }
        public double Saldo {
            get { return saldo;}
        }

        public void Deposita(double cant){
            saldo+=cant;
        }
        public virtual bool Retira(double cant){        //permite sobrecargar este método 
            if(saldo>=cant){
                saldo-=cant;
                return true;
            }else return false;
        }
        
        }//endclass
}