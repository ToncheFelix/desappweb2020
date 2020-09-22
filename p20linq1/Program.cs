/**
*   Linq1, Consultas por medio de Linq a arreglo de enteros con filtración de acuerdo a condiciones
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

namespace p20linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            // fuente de datos
            int[] numeros = new int[]{10,25,-1,10,0,320,22,65,800,-4,20,20,1000,2000,-233};
           
            IEnumerable<int> qrypares =
            from num in numeros 
            where (num%2)==0
            select num;

            //Ejecutar Consulta
            Console.WriteLine($"\nNúmeros pares {qrypares.Count()}");
            foreach (int n in qrypares)
            Console.Write ($"{n} ");

            // Crear consulta impares
           /* var qryimpares =
            from num in numeros
            where (num%2)!= 0
            select num;*/
            //Con var se toma como ienumerable
            //ahora to Array
            var qryimpares = (from num in numeros where (num%2)!=0 select num).ToArray();
            Console.WriteLine($"\nNúmeros impares {qryimpares.Count()}");
            for(int i=0; i<qryimpares.Count(); i++)
                    Console.Write($"{qryimpares[i]} ");

            // Crear consulta de números mayores a 100 y ponerlos en una lista
            var mayores = (from num in numeros where num>=100 select num).ToList();
            Console.WriteLine($"\nNúmeros mayores que 100 {mayores.Count()}");
            mayores.ForEach(n=>Console.Write($"{n} "));
            
        }
    }
}
