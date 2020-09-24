/**
*   Linq3, Consultas por medio de Linq, creación de clase estudiante y filtración de acuerdo a ciertas condiciones
*
* Felix Fernando Tonche Valadez
* Universidad Autónoma de Zacatecas
* Ingeniería en Computación - Desarrollo de Apps Web
* 22-Sep-2020
* Zacatecas, MX
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace p22linq3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> Estudiantes = new List<Estudiante>() {

                new Estudiante {Matricula=111, Nombre="Juan Perez", Domicilio= "Principal 123, Guadalupe", Calif=new List<float> {97,92,81,60} },
                new Estudiante {Matricula=111, Nombre="Maria Lopez", Domicilio= "Principal 126, Fresnillo", Calif=new List<float> {75,84,91,39} },
                new Estudiante {Matricula=444, Nombre="Felipe Valdez", Domicilio= "Calle Luis Moya 5, Rio Grande", Calif=new List<float> {88,94,65,91} },
                new Estudiante {Matricula=444, Nombre="Angel Sanchez", Domicilio= "Convento de San Agustin, Guadalupe", Calif=new List<float> {70,90,60,40} }
             };

                Estudiantes.Add(
                new Estudiante {Matricula=111, 
                Nombre="Pedro Salas", Domicilio= "Calle Principal 2, Guadalupe", Calif=new List<float> {70,88,55,80} } 
                );
            // Todos los registros sin consulta ni filtro
            Console.WriteLine("\nTodos los estudiantes: {0}",Estudiantes.Count());
            Estudiantes.ForEach(est=> Console.WriteLine(est.ToString()));

            // Filtrar los estudiantes que son de Zacatecas
            
            var estGuad = (from est in Estudiantes where est.Domicilio.Contains("Guadalupe") select est).ToList();
            Console.WriteLine("\nTodos los estudiantes de Guadalupe: {0}",estGuad.Count());
            estGuad.ForEach(est=> Console.WriteLine(est.ToString()));

            // filtrar estudiantes con promedio de 7, mostrar por orden descendente
            var Prom8 = (from est in Estudiantes
                where est.Calif.Average() >= 70
                orderby est.Nombre descending
                select est).ToList();
            Console.WriteLine("\nTodos los estudiantes con promedio de 8 en orden descendente por nombre: {0}",Prom8.Count());
            Prom8.ForEach(est=> Console.WriteLine(est.ToString()));

            // Consulta con datos agrupados
            var gpoest = from est in Estudiantes group est by est.Matricula;
            foreach (var gpo in gpoest){
                Console.WriteLine(gpo.Key);
                foreach(Estudiante est in gpo)
                    Console.WriteLine(est.ToString());
            }

            // Estudiantes y sus promedios
            Console.WriteLine("\nEstudiantes y sus promedios");
            var proms = (from est in Estudiantes
                select $"nombre{est.Nombre} prom={est.Calif.Average()}").ToList();
            proms.ForEach(p=>Console.WriteLine(p));
        }
    }
}
