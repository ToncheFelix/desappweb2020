using System;
using System.Collections.Generic;

namespace ExaPar1
{
    class Nodo{
          public string Ip{get; set;}
          public string Tipo{get; set;}
          public int Puertos{get; set;}
          public int Saltos{get; set;}
          public string So{get; set;}
          public List<Vulnerabilidad> vulnera{get; set;}
            public override string ToString() => 
        $"Ip: {Ip, -10}, Tipo: {Tipo, -15}, Puertos: {Puertos, -5}, Saltos: {Saltos, -5}, SO: {So, -8}, TotVul: {vulnera.Count, -8} ";//, Nodos {Saltos.Join(",",vulnera)}";
    }

}