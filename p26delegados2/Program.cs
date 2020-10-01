/**
* Ejemplo de un delegado multicast (un delegado que invoca a varios métodos al mismo tiempo)
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 01-Oct-2020
* Zacatecas, MX
*/
using System;

namespace p26delegados2
{
    public delegate void Midelegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            Midelegado d1, d2, d3, d;
            d1 = Mensajes.Mensaje1;
            d2 = Mensajes.Mensaje2;
            d = d1 + d2;
            d("El peje");
            d3 = (string msj) => Console.WriteLine($"{msj} - paga todo que no pare la fiesta.");
            d += d3;
            d("El borolas");
            d -= d2;
            d("Peña");
            d -= d1;
            d("Tello");

        }
    }
}
