/**
*   Linq2, Uso de Linq para filtrar información de un arreglo de strings
*
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 22-Sep-2020
* Zacatecas, MX
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace p21linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] frutas = new string[] 
            {"pera", "melón", "sandía", "durazno", "manzana", "platano", "kiwi", "naranja"};


            // Consulta de frutas que comienzan con la letra m 
            var mfrutas = from f in frutas where f.StartsWith('m') select f; 
            Console.WriteLine($"\n Frutas que inician con la letra m: {mfrutas.Count()}");
            foreach(var f in mfrutas) Console.WriteLine($"{f} ");

            // Consulta de frutas que comienzan con la letra m 
            var xfrutas = (from f in frutas where f.Contains("an") select f).ToArray(); 
            Console.WriteLine($"\n Frutas que contienen las letras an: {xfrutas.Count()}");
            foreach(string f in xfrutas) Console.WriteLine($"{f} ");

            // Consulta de frutas que comienzan con la letra m 
            var yfrutas = (from f in frutas where f.EndsWith('a') select f).ToList(); 
            Console.WriteLine($"\n Frutas que terminan con la letra a: {yfrutas.Count()}");
            yfrutas.ForEach(f=>Console.WriteLine($"{f} "));




        }
    }
}
