/**
* Ejemplo de un delegado como parámetro
*
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 01-Oct-2020
* Zacatecas, MX
*/
using System;

namespace p29delegados5
{
    public delegate void MiDelegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1,d2,d3;
            d1 = ClaseA.MetodoA;
            d1("Tradicional A");
            Invocar(d1);

            d2 = ClaseB.MetodoB;
            d2("Tradicional B");
            Invocar(d2);

            d3 = (string msj) => Console.WriteLine($"Llamando método con expersión Lambada: {msj}");
            d3("Tradicional Lambada");
        }
        static void Invocar(MiDelegado del){
            del("Hola desde invocador: ");

       }
    }
    
    public class ClaseA {
        public static void MetodoA(string msj) => Console.WriteLine($"Llamando al MetodoA de la ClaseA: {msj}");
    }
    public class ClaseB {
        public static void MetodoB(string msj) => Console.WriteLine($"Llamando al MetodoB de la ClaseB: {msj}");
    }
}
