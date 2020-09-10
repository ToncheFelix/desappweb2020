/**
* Programa de Control Bancario V1
* Clase cuenta bancaria
* Clase cliente
* 
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 10-Sep-2020
* Zacatecas, MX
*/
using System;

namespace p15cuentabancariav1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco mibanco = new Banco("BANKTONCH", "Felix Tonche");
            mibanco.AgregarCliente(new Cliente("Pedro Perez"));
            mibanco.AgregarCliente(new Cliente("Juan Hernandez"));
            mibanco.AgregarCliente(new Cliente("Felipe Valdez"));
            mibanco.AgregarCliente(new Cliente("Maria García"));

            mibanco.Clientes[0].Cuenta = new CuentaBancaria(100);
            mibanco.Clientes[1].Cuenta = new CuentaBancaria(200);
            mibanco.Clientes[2].Cuenta = new CuentaBancaria(300);
            mibanco.Clientes[3].Cuenta = new CuentaBancaria(0);

            mibanco.Clientes[2].Cuenta.Retira(100);
            mibanco.Clientes[3].Cuenta.Deposita(50);


            Console.WriteLine("######### Reporte General #########\n");
            Console.WriteLine($"Banco {mibanco.Nombre} propiedad de {mibanco.Propietario} \n");
            
            foreach(Cliente cte in mibanco.Clientes){
                Console.WriteLine($"El cliente de nombre {cte.Nombre}");
                Console.WriteLine($"Tiene una cuenta con saldo de {cte.Cuenta.Saldo}\n");
            }
        }
    }
}
