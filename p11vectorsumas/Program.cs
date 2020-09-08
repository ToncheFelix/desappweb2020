/**
* Programa que genera números aleatorios en un vector, calcula positivos, negativos, cero y la sumas de los mismos
* 
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 08-Sep-2020
* Zacatecas, MX
*/
using System;

namespace p11vectorsumas
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] A = new double[30];
            int pos=0,neg=0,cer=0;
            double spos=0, sneg=0;
            Random rnd = new Random();

            for (int i=0; i<A.Length; i++){
                A[i] = rnd.Next(-10,100);
                Console.Write($"{A[i]} ");
                if(A[i]>0){
                    pos++; spos+=A[i];
                } else if(A[i]<0){
                    neg++; sneg+=A[i];
                } else cer++;
            }
            Console.WriteLine($"\nPositivos:    {pos}, suma: {spos}");
            Console.WriteLine($"Negativos:      {neg}, suma: {sneg}");
            Console.WriteLine($"Ceros:          {cer}");
        }
    }
}
