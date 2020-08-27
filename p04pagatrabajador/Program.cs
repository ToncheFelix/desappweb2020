using System;
// Programa que calcula la paga de un trabajador, dado el nombre, horas, paga y tasa de impuesto
//Felix Tonche Valadez
namespace p04pagatrabajador
{
    class Program
    {
        static void Main(string[] args)
        {

            string nombre;
            int horas;
            float paga, tasa=0.10f;

            float impuesto, pagabruta, paganeta;



            Console.WriteLine("Calculando la paga de un trabajador");
            Console.WriteLine("Ingresa el nombre del trabajador: "); nombre = Console.ReadLine();
            Console.WriteLine("Ingresa las horas trabajadas: "); horas = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la paga "); paga = float.Parse(Console.ReadLine());

            pagabruta = horas * paga;
            impuesto = pagabruta * tasa;
            paganeta = pagabruta - impuesto;

            Console.WriteLine($"El trabajador de nombre {nombre}");
            Console.WriteLine($"Trabajo {horas}");
            Console.WriteLine($"Con paga de {paga} pesos");
            Console.WriteLine($"Por lo cual recibe una paga bruta de  {pagabruta} pesos");
            Console.WriteLine($"Esto genera un impuesto  de {impuesto} pesos");
            Console.WriteLine($"Su pago final es de {paganeta} pesos");
        }
    }
}
