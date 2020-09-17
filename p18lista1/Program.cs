/**
* Listas Versión1, creación de lista de tipo string, agregar por elemento y por rango, y filtrado de elementos.
*
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 17-Sep-2020
* Zacatecas, MX
*/
using System;
using System.Collections.Generic;


namespace p18lista1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definir la lista con valores iniciales
            List<string> mats = new List<string>() {
                "Calculo I",
                "Redacción Avanzada",
                "Introducción a la Inteligencia"
            };
            // Agregar elementos a la lista
            mats.Add("Matemáticas Discretas");
            mats.Add("Compiladores e interpretadores");
            imprime(mats);

            // Agregar un rango de materias
            string[] mopt = {
                "Seguridad de Redes y Sitemas (op)",
                "Tópicos selectos de Redes (op)",
                "Criptografía Avanzada (op)"
            };
            mats.AddRange(mopt);
            imprime(mats);

            // Ordenar la lista
            mats.Sort();
            imprime(mats);

            // Invertir los elementos de la lista
            mats.Reverse();
            imprime(mats);

            // Buscar un elemento en la lista en base a una condición
            Console.WriteLine("Materias que tengan la palabra 'Discretas':");
            string mat = mats.Find(x=>x.Contains("Discretas"));
            Console.WriteLine(mat);

            // Buscar todas las materias en la lista, que son optativas
            Console.WriteLine("Materias Optativas");
            var ms  = mats.FindAll(x=>x.Contains("op")); // var recibe lo que sea y le da el tipo correcto
            imprime(ms);
        }
        

        static void imprime(List<string> lista){

            //foreach(string m in lista){    Console.WriteLine(m); }
            lista.ForEach(m=>Console.WriteLine(m));
            Console.WriteLine();
        }


    }
}
