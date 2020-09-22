using System;
using System.Collections.Generic;

namespace p22linq3
{
    class Estudiante {
          public int Matricula{get; set;}
          public string Nombre{get; set;}
          public string Domicilio{get; set;}
          public List<float> Calif;
        public override string ToString() => 
        $"Matricula:{Matricula}, Nombre: {Nombre}, Domicilio: {Domicilio}, Calificación {string.Join(",",Calif)}";
    }
}