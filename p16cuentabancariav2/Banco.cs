using System;
using System.Collections.Generic;
namespace p15cuentabancariav1
{
    class Banco{
        private string nombre;
        private string propietario;
        private List<Cliente> clientes;
        public Banco(string nombre, string propietario){
            this.nombre=nombre;
            this.propietario=propietario;
            clientes = new List<Cliente>();  // crear espacio en memoria para la lista
        }
        public string Nombre{                //agregar nombre y leer nombre del banco
            get {return nombre;}
            set {nombre=value;}
        }
        public string Propietario{
            get {return propietario;}
            set {propietario=value;}
        }
        public List<Cliente> Clientes {
            get {return clientes;}
        }
        public void AgregarCliente (Cliente cte){
            clientes.Add(cte);
        }
        public void CalcularIntereses(){
            foreach(Cliente cte in clientes){
                foreach(CuentaBancaria cta in cte.Cuentas){
                    if(cta is CuentaDeAhorro)
                        (cta as CuentaDeAhorro).CalcularInteres();
                }
            }
        }


    }
}