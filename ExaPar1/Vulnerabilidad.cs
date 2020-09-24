using System;
using System.Collections.Generic;

namespace ExaPar1
{
    class Vulnerabilidad{
          public string Clave{get; set;}
          public string Vendedor{get; set;}
          public string Descripcion{get; set;}
          public string Tipo{get; set;}
          public DateTime Fecha{get; set;}

          public override string ToString() => 
        $"\nClave: {Clave}, Vendedor: {Vendedor, -10}, Descripción: {Descripcion}, Tipo: {Tipo}, Fecha: {Fecha:d}, Antiguedad: {Math.Floor((DateTime.Today - Fecha).TotalDays/ 365.25)}";
    }
}