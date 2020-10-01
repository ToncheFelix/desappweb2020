/**
* Ejemplo de delegado simple - mensajes
* 
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 01-Oct-2020
* Zacatecas, MX
*/

using System;

namespace p25delegados1
{
    public delegate void MiDelegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MiDelegado d;
            d = Mensaje.Mensaje1;
            d("Juan");
            d = Mensaje.Mensaje2;
            d("Pepe");
            d = (string msj) => Console.WriteLine($"{msj} - paga todo que no pare la fiesta.");
            d("Carlos");
        }
    }

    public class Mensaje {

        public static void Mensaje1(string msj) => Console.WriteLine($"{msj} lleva el pastel");
        public static void Mensaje2(string msj) => Console.WriteLine($"{msj} - fue el culpable se cancela la fiesta");

    }


}
