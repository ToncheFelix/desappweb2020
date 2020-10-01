/**
* Ejemplo de un delegado multicast con parámetros
*
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 01-Oct-2020
* Zacatecas, MX
*/
using System;

namespace p27delegados3
{
    public delegate int MiDelegado(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1 = A.MetodoA;
            MiDelegado d2 = B.MetodoB;
            Console.WriteLine($"La suma es {d1(10,20)}");
            Console.WriteLine($"La multiplicación es {d2(10,20)}");
            MiDelegado d = d1 + d2;
            Console.WriteLine($"El resultado es: {d(5,2)}");
        }
    }
    public class A{
        public static int MetodoA(int a, int b) => a + b;
    }
    public class B{
        public static int MetodoB(int a, int b) => a * b;
    }

}
