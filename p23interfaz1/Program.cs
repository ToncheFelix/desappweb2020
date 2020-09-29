/**
*   Interfaces: implementacion de 1 interfaz (IAnimal).
*
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 29-Sep-2020
* Zacatecas, MX
*/
using System;

namespace p23interfaz1
{
    public interface IAnimal {
        string Nombre {get; set;}
        void Llorar();
    }
    class Perro : IAnimal
    {
        public Perro(string nombre) => Nombre = nombre;
        public string Nombre { get; set; }
        public void Llorar() => Console.WriteLine("Woff Woff");
    }
    class Gato : IAnimal
    {
        public Gato(string nombre) => Nombre = nombre;
        public string Nombre { get; set; }
        public void Llorar() => Console.WriteLine("Miauu");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primer ejemplo de uso de interfaces\n");
            Perro miperro = new Perro("Danddy");
            Console.WriteLine($"El perro {miperro.Nombre}");
            miperro.Llorar();
            Gato migato = new Gato("Newton");
            Console.WriteLine($"El Gato {migato.Nombre}");
            migato.Llorar();
        }
    }
}
