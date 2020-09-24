using System;
using System.Collections.Generic;

namespace ExaPar1
{
    class Red{
          public string Empresa{get; set;}
          public string Propietario{get; set;}
          public string Domicilio{get; set;}
          public List<Nodo> nodos{get; set;}

          public override string ToString() => 
        $"Empresa:{Empresa}, Propietario: {Propietario}, Domicilio: {Domicilio}, Nodos {string.Join(",",nodos)}";
    }
}