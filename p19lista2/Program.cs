/**
* Listas Versión2, creación de lista de una clase, insertar elementos, eliminar elementos y filtrado de elementos por condiciones.
*                  sobrecarga con método para impresión de elementos de la lista.
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 17-Sep-2020
* Zacatecas, MX
*/
using System;
using System.Collections.Generic;

namespace p19lista2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista con elementos de tipo Pieza
            List<Pieza> mp = new List<Pieza>();
            // Agregar piezas a la lista
            mp.Add(new Pieza(254, "Llave perica"));
            mp.Add(new Pieza(220, "Martillo"));
            mp.Add(new Pieza(132, "Clavo de concreto 1/2 p"));

            // Agregar un rango de piezas
            var proveedor = new List<Pieza> (){
                new Pieza(223 , "Martillo Truper"),
                new Pieza(133,  "Clavos de concreto 1 p"),
                new Pieza(552 , "Taquetes dobles para madera")
            };
            mp.AddRange(proveedor);

            // Usar el método foreach integrado a la lista para imprimir 
            Console.WriteLine("\n....... Impresión...........");
            mp.ForEach(p=>Console.WriteLine(p.ToString()));
            Console.WriteLine("....... Impresión...........");

            // Eliminar el último elemento de la lista
            Console.WriteLine("\nElimina último elemento");
            mp.RemoveAt(mp.Count-1);
            mp.ForEach(p=>Console.WriteLine(p.ToString()));

            //Insertar un elemento en la 2da posición
            Console.WriteLine("\nInsertar elemento en posición 2:");
            mp.Insert(1,new Pieza (134, "Clavos de Concreto 3/4 p"));
            mp.ForEach(p=>Console.WriteLine(p.ToString()));
            
            // Buscar todas las ocurrencias  de la palabra Clavos
            Console.WriteLine("\nPiezas que contienen la palabra Clavos");
            var pzas =mp.FindAll(p=>p.Nombre.Contains("Clavos"));
            pzas.ForEach(p=>Console.WriteLine(p.ToString()));

            // Buscar las piezas cuyo Id sea menor que 200
            Console.WriteLine("\nPiezas con Id < 200");
            var pzas2 = mp.FindAll(p=>p.Id<200);
            pzas2.ForEach(p=>Console.WriteLine(p.ToString()));
        }
    }
}
