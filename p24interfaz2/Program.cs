/**
*   Interfaces: implementacion de 3 interfaces (Canino,Pajaro,Animales)
*   con herencia de una clase Organismo.
*
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 29-Sep-2020
* Zacatecas, MX
*/
using System;

namespace p24interfaz2
{
    public class Organismo
    {
        public void Respiracion() => Console.WriteLine("Respira");
        public void Movimiento() => Console.WriteLine("Se mueve");
        public void Crecimiento() => Console.WriteLine("Crece");
    }
    public interface IAnimales {
        void Multicelular();
        void Sangrecaliente();
    }
    public interface ICanino: IAnimales {
        void Correr();
        void Cuatropatas();
    }
    public interface IPajaro: IAnimales{
        void Volar();
        void Dospatas();
    }

    public class Perro: Organismo, ICanino {
        public Perro(string nombre) => Nombre = nombre;
        public string Nombre { get; set; }

        public void Multicelular() => Console.WriteLine("\nMulticelular perro");
        public void Sangrecaliente() => Console.WriteLine("Sangrecaliente perro");

        public void Correr() => Console.WriteLine("Correr Perro");
        public void Cuatropatas() => Console.WriteLine("CuatroPatas perro");
    }
    public class Perico: Organismo, IPajaro { 
        public Perico(string nombre) => Nombre = nombre;
        public string Nombre { get; set; }

        public void Multicelular() => Console.WriteLine("\nMulticelular perico");
        public void Sangrecaliente() => Console.WriteLine("Sangrecaliente perico");

        public void Volar() => Console.WriteLine("Volar perico");
        public void Dospatas() => Console.WriteLine("DosPatas perico");
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Segundo ejemplo de interfaces");

            Perro miperro = new Perro("Danndy");
            Console.WriteLine("\n ### Características del Perro ###");
            Console.WriteLine($"El perro: {miperro.Nombre}");
            miperro.Respiracion();
            miperro.Movimiento();
            miperro.Crecimiento();
            miperro.Multicelular();
            miperro.Sangrecaliente();
            miperro.Correr();
            miperro.Cuatropatas();

            Perico miperico = new Perico("Merlin");
            Console.WriteLine("\n ### Características del Perico ###");
            Console.WriteLine($"El perico: {miperico.Nombre}");
            miperico.Respiracion();
            miperico.Movimiento();
            miperico.Crecimiento();
            miperico.Multicelular();
            miperico.Sangrecaliente();
            miperico.Volar();
            miperico.Dospatas();

        }
    }
}
