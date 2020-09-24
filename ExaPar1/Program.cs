/**      Primer Examen Parcial
* Empresa  de  Seguridad  en  Redes | Sistema  para  almacenar  los  resultados  de  las pruebas de seguridad efectuadas a diferentes Nodos de una Red.
* Clases: Red, Nodo, Vulnerabilidades
* 
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 24-Sep-2020
* Zacatecas, MX
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaPar1
{
    class Program
    {
        static void Main(string[] args){      
        
        Red red1 = new Red { 
            Empresa="Red CompuNetwo, S.A. de C.V.",
            Propietario="Mr Felix Fernando Tonche",
            Domicilio="Principal 123, Guadalupe, Zacatecas, Mx.",       
            
            nodos = new List<Nodo>(){ 
                    new Nodo {Ip="192.168.0.10", Tipo="servidor", Puertos=5, Saltos=10, So="linux",
                            vulnera=new List<Vulnerabilidad>(){
                                    new Vulnerabilidad {Clave="CVE-2015-1635",Vendedor="microsoft",Descripcion="HTTP.sys permite a atacantes remotos ejecutar código arbitrario",Tipo="remota",Fecha=DateTime.Parse("2015-04-14")},
                                    new Vulnerabilidad {Clave="CVE-2017-0004",Vendedor="microsoft",Descripcion=" El  servicio  LSASS  permite causar una denegación de servicio",Tipo="local", Fecha=DateTime.Parse("2017-09-01")}
                            }
                    },
                    new Nodo {Ip="192.168.0.12",Tipo="equipoactivo",Puertos=2,Saltos=12,So="ios",
                            vulnera=new List<Vulnerabilidad>(){
                                    new Vulnerabilidad {Clave="CVE-2017-3847",Vendedor="cisco",Descripcion="Cisco Firepower Management Center XSS",Tipo="remota",Fecha=DateTime.Parse("2017-02-21")}
                            }
                    },
                    new Nodo {Ip="192.168.0.20",Tipo="computadora",Puertos=8,Saltos=5,So="windows",
                            vulnera=new List<Vulnerabilidad>(){
                                    new Vulnerabilidad {Clave="CVE-2009-2504",Vendedor="microsoft",Descripcion=" Múltiples desbordamientos de enteros en APIs Microsoft .NET 1.1",  Tipo="local",Fecha=DateTime.Parse("2009-08-13")},
                                    new Vulnerabilidad {Clave="CVE-2016-7271",Vendedor="microsoft",Descripcion=" Elevación  de  privilegios Kernel Segura en Windows 10 Gold",      Tipo="local",Fecha=DateTime.Parse("2016-09-20")},
                                    new Vulnerabilidad {Clave="CVE-2017-2996",Vendedor="adobe",    Descripcion=" Adobe  Flash  Player  24.0.0.194 corrupción de memoria explotable",Tipo="remota",Fecha=DateTime.Parse("2017-02-15")}
                            }
                    },
                    new Nodo {Ip="192.168.0.15",Tipo="servidor",Puertos=10,Saltos=22,So="linux",vulnera=new List<Vulnerabilidad>(){} }           
                    
            }//end nodos
        }; //end redes  
    
//Datos Generales de la red:
            Console.WriteLine("\n>> Datos Generales de la red:\n");
            Console.WriteLine($"Empresa:        { red1.Empresa}");
            Console.WriteLine($"Propietario:    { red1.Propietario}");
            Console.WriteLine($"Domicilio:      { red1.Domicilio}");

// Nodos en total, vulnerabilidades en total
            int contador=0;
            foreach (var n in red1.nodos){contador+=n.vulnera.Count();}
            var tnodos = red1.nodos.Count();

            Console.WriteLine("\nTotal nodos red:        {0}", tnodos);
            Console.WriteLine("Total vulnerabilidades: {0}", contador );

if (!red1.nodos.Any() == false){ // Verifica si existen nodos en la red

// Datos Generales de los nodos
            Console.WriteLine("\n>> Datos Generales de los nodos:");
            red1.nodos.ForEach(est=> Console.WriteLine(est.ToString()));

// Mayor y mínimo de saltos
            //encapsulado preferentemente
            var maximo = red1.nodos.Max(x => x.Saltos);
            var minimo = red1.nodos.Min(x => x.Saltos);
            Console.WriteLine("\nMayor número de saltos: {0} ",maximo);
            Console.WriteLine("Menor número de saltos: {0} ",minimo);

// Vulnerabilidades por nodo
            Console.WriteLine("\n>> Vulnerabilidades por nodo: ");
            foreach (var n in red1.nodos){
                    Console.WriteLine($"\n> IP: {n.Ip}, Tipo: {n.Tipo}");
                    
                        if (!n.vulnera.Any() == false){ // Verifica si existen vulnerabilidades en el nodo
                            Console.WriteLine("\nVulnerabilidades:\n");
                               foreach(var vul in n.vulnera){ 
                                    Console.WriteLine(vul.ToString());
                            }
                        }else
                         Console.WriteLine("\nNo tiene vulnerabilidades");
            }
}
else Console.WriteLine("\n>> No hay nodos");

        }//Main
    }
}