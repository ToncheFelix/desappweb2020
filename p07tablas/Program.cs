/**
* Programa que imprime las tablas de multiplicar
* 
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 01-Sep-2020
* Zacatecas, MX
*/
using System;

namespace p07tablas
{
    class Program
    {
        static int Main(string[] args)
        {
            //Variables necesarias para mostrar las tablas de multiplicación
            int op, tab, ini, fin;

            if(args.Length==0){ 
                Menu(); 
                return 1;
            }

            op  = int.Parse(args[0]); // opción del menu
            tab = int.Parse(args[1]); // tabla
            ini = int.Parse(args[2]); // inicio
            fin = int.Parse(args[3]); // fin

            switch(op){ //Switch necesario para verificar la opción seleccionada
                case 1: { // Opción 1  (ej. la tabla del 5 , del 1 al 10)
                        Console.WriteLine($"_______________________"); //Encabezado de salida
                        Console.WriteLine($"|    Tabla del: {tab}     |");
                        Console.WriteLine($"|_____________________|");
                    for (int i = ini; i<= fin; i++){
                        Console.WriteLine($"|    {tab} x {i} = {tab*i}");}
                    Console.WriteLine($"|______________________");
                }break;

                case 2: { // Opción 2  (ej. las tablas hasta el 5 , del 1 al 10)
                    for (int t=1; t<=tab; t++){
                        Console.WriteLine($"_______________________"); //Encabezado de salida
                        Console.WriteLine($"|    Tabla del: {t}     |");
                        Console.WriteLine($"|_____________________|");
                        for (int i = ini; i<= fin; i++){
                            Console.WriteLine($"|    {t} x {i} = {t*i} ");
                         }  Console.WriteLine($"|______________________"); 
                    }
                }break;
            }//EndSwitch
        return 0;
        }//EndMain

        static void Menu(){
        Console.Clear();
        Console.WriteLine(" [1] Imprime la tabla que quieras hasta el número que desees (ej. 5 1 10)");
        Console.WriteLine(" [2] Imprime todas las tablas hasta donde quieras (ej. 5 1 10)");
        }//EndMenu
    }
}
