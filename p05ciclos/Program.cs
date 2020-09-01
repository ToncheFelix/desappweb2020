/**
* Programa que utiliza ciclos para mostrar sucesión 
* de números de acuerdo a un menu de opciones.
* 
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 01-Sep-2020
* Zacatecas, MX
*/
using System;

namespace p05ciclos
{
    class Program
    {
        static int Main(string[] args)
        {
            int op, c=0, suma = 0;
            Console.Clear();
             
            if(args.Length==0){ //verifica que se hayan pasado argumentos de linea de comando
                Menu();
                return 1;
            }
            op = int.Parse(  args[0] ) ; // toma el primer argumento de la linea de comando

            switch (op){
                case 1: { //números del 1 al 100 con ciclo while
                    c=1; suma=0;
                    Console.WriteLine(" [1] Números del 1 al 100 con ciclo while \n");
                    while (c<=100){
                        Console.Write($"{c} ");
                        suma+=c;
                        c++;
                    }
                    Console.Write($"\n\nLa suma es: {suma}");
                }break;
                case 2: { // números del 100 a 1 do-while
                    c=100; suma=0;
                    Console.WriteLine(" [2] Números del 100 al 1 con ciclo do .. while");
                    do {
                        Console.Write($"{c} ");
                        suma+=c;
                        c--;
                    }while (c>=1);
                    Console.Write($" \n La suma es: {suma} ");
                }break;
                case 3: { // números del 50 al 200 for
                    c=50; suma=0;
                    Console.WriteLine(" [3] Números del 50 al 200 con ciclo for");
                    for(int i=50; i<= 200; i++){
                        Console.Write($"{c} ");
                        suma+=c;
                        c++;
                    }
                     Console.Write($" \n La suma es: {suma} ");
                }break;
                case 4: { //números del 2 al 100 los pares for
                    suma=0;
                    Console.WriteLine(" [4] Números del 2 al 100 solo los pares con ciclo for");
                    for(int i=2; i<= 100; i+=2){
                        Console.Write($"{i} ");
                        suma+=i;
                    }
                     Console.Write($" \n La suma es: {suma} ");
                }break;      
                case 5: { // números del 99 al 1 impares for
                    suma=0;
                    Console.WriteLine(" [5] Números del 99 al 1 solo los impares con ciclo for");
                    for(int i=99; i>= 1; i-=2){
                        Console.Write($"{i} ");
                        suma+=i;
                    }
                     Console.Write($" \n La suma es: {suma} ");
                }break;
                case 6: { // números del 272 a 40 decrementos con while
                    c=272; suma=0;
                    Console.WriteLine(" [6] Números del 272 al 40 en decrementos de 4 con ciclo while");
                    while( c >= 40) {
                        Console.Write($"{c} ");
                        suma+=c;
                        c-=4;
                    }
                    Console.Write($" \n La suma es: {suma} ");
                }break;
            }
            
            return 0;
        }
        static void Menu(){
            Console.Clear();
            Console.WriteLine("|================================================================|");
            Console.WriteLine("|================================================================|");
            Console.WriteLine("|###               Uso de ciclos en Lenguaje C#               ###|");
            Console.WriteLine("=================================================================|");
            Console.WriteLine("=================================================================|");
            Console.WriteLine("| [1] Números del 1 al 100 con ciclo while                       |");
            Console.WriteLine("| [2] Números del 100 al 1 con ciclo do .. while                 |");
            Console.WriteLine("| [3] Números del 50 al 200 con ciclo for                        |");
            Console.WriteLine("| [4] Números del 2 al 100 solo los pares con ciclo for          |");
            Console.WriteLine("| [5] Números del 99 al 1 solo los impares con ciclo for         |");
            Console.WriteLine("| [6] Números del 272 al 40 en decrementos de 4 con ciclo while  |");
            Console.WriteLine("|================================================================|");
            Console.WriteLine("|================================================================|");
           
        }

    }
}
