/**
* Ejemplo de un delegado genérico
*
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 01-Oct-2020
* Zacatecas, MX
*/
using System;

namespace p28delegados4
{
    public delegate T Suma<T>(T p1, T p2);

    class Program
    {
        static void Main(string[] args)
        {
            Suma<int> d1 = Sumar;
            Suma<string> d2 = Concatenar;
           // Suma<string> d3 = NoSePuede; <-- Esto no se puede porque hay diferentes tipos en los parámetros.
            Console.WriteLine($"La suma es {d1(20,30)}");
            Console.WriteLine($"La concatenación es {d2("Hola mundo"," hermoso")}");
            Console.WriteLine($"Diferentes tipos de parámetros {NoSePuede("Parametro a",100)}");


        }
        public static int Sumar(int a, int b) => a + b;
        public static string Concatenar(string a, string b) => a + b;
        public static string NoSePuede(string a, int b) => $"{a} - {b.ToString()}";


    }
}
