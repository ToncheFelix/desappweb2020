/**
* Programa que lee 2 vectores A y B de tamaño n, multiplicar el primer elemento de A
* con el último de B
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 08-Sep-2020
* Zacatecas, MX
*/
using System;
namespace p13vectormultiplica
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 3;
            double[] A = new double[MAX];
            double[] B = new double[MAX];
            double[] C = new double[MAX];

            Console.WriteLine("\nDame los elemento de A"); leer(A);
            Console.WriteLine("\nDame los elemento de B"); leer(B);
            for(int i=0; i<MAX; i++)
                C[i] = A[i] * B[(MAX-1)-i];

            Console.WriteLine("Los 3 valores son: ");
            imprime(A);
            imprime(B);
            imprime(C);

        }
        static void leer(double[] v){
            for (int i = 0; i<v.Length; i++){
            Console.Write($"Elemento[{i}]= ");
            v[i] = double.Parse(Console.ReadLine());   
            }
        }
        static void imprime(double[] v){
            
            for(int i=0; i<v.Length; i++)
             Console.Write($"{v[i]} ");
            Console.WriteLine();
        }
        
    }
}
