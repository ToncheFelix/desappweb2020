using System;

namespace p15cuentabancariav1
{
    class Cliente{
        private string nombre;
        private CuentaBancaria cuenta;
        public Cliente(){}
        public Cliente(string nombre){
            this.nombre=nombre;
        }
        public string Nombre{
            get{return nombre;}
            set{nombre=value;}
        }
        public CuentaBancaria Cuenta{
            get {return cuenta;}
            set {cuenta=value;}
        }

    }//endclass Cliente

}