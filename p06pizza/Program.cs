/**
* Programa que  permita al usuario comprar una pizza eligiendo sus características según El Menu disponible
* 
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 01-Sep-2020
* Zacatecas, MX
*/
using System;

namespace p06pizza
{
    class Program
    {
        static int Main(string[] args)
        {
            // variables para recibir los parametros
            char tam, cub, don;
            string[] ings;
            // variables para guardar la elección del usuario
            string tamaño, ingredientes="", cubierta, donde;
            
            //Mostrar menu en caso de no ingresar nada
            Console.Clear();
            if(args.Length==0){ 
            Menu();
            return 1;
            }

            //Elegir Tamaño
            tam = char.Parse(args[0].ToUpper());
            if (tam=='P') tamaño="Pequeña";
            else if (tam=='M') tamaño ="Mediana";
            else tamaño = "Grande";

            //Elegir ingredientes
            ings = args[1].Split("+"); //Separa los ingredientes en base al signo +
            foreach(string i in ings){
                switch(char.Parse(i.ToUpper())){
                    case 'E': ingredientes+="Extraqueso "; break;
                    case 'C': ingredientes+="Champiñones "; break;
                    case 'P': ingredientes+="Piña "; break;
                }
            }
            //Elegir Tipo de Cubierta
            cub = char.Parse(args[2].ToUpper());
            cubierta = cub == 'D' ? "Delgada" :  "Gruesa";
            
            //Elegir Tipo de Cubierta
            don = char.Parse(args[3].ToUpper());
            donde = don == 'A' ? "Aqui" : "Llevar";

            //Mostrando el resumen
            Console.WriteLine("La pizza que pediste es la siguiente: ");
            Console.WriteLine($" Tamaño: {tamaño}");
            Console.WriteLine($" Ingredientes: {ingredientes}");
            Console.WriteLine($" Cubierta: {cubierta}");
            Console.WriteLine($" Donde: {donde}");
            return 0;
        }

        static void Menu(){ 
            Console.Clear();
            Console.WriteLine("Elije las opciones según desea tu pizza");
            Console.WriteLine("Tamaño: (P)equeña (M)ediana (G)rande");
            Console.WriteLine("Ingredientes: (E)xtra queso (C)hampiñones (P)iña unidos por +");
            Console.WriteLine("Cubierta: (D)elgada (G)ruesa");
            Console.WriteLine("Donde: (A)qui (L)levar");
        }//endMenu

    }
}
