/**
* Programa que genera dos vectores aleatorios de 15 elementos y los suma en un tercer vector
* 
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 08-Sep-2020
* Zacatecas, MX
*/
using System;

namespace p09vectoraleatorio
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] A = new int[15];
            int[] B = new int[15];
            int[] C = new int[15];

            Random rnd = new Random();

            for(int i=0; i<A.Length; i++){
                A[i] = rnd.Next(1,100);
                B[i] = rnd.Next(1,100);
                C[i] = A[i] + B[i];
            }
            Console.WriteLine("\nElementos de A"); imprime(A);
            Console.WriteLine("\nElementos de A"); imprime(B);
            Console.WriteLine("\nElementos de A"); imprime(C);

            static void imprime(int[] v){
                for(int i=0; i<v.Length; i++){
                    Console.Write($"{v[i]} ");
                }
            }
        }
    }
}
