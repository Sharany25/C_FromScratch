using System;
using System.Collections.Generic;

namespace CursosEstudiantes
{
    // Clase abstracta Persona
    abstract class Persona
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public abstract void MostrarInfo();
    }

    // Clase estudiantes heredada
    class Estudiante : Persona
    {
        public decimal Promedio { get; set; }

        public override void MostrarInfo()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Promedio: " + Promedio);
            Console.WriteLine("----------------------------");
        }
    }

    // Clase Curso
    class Curso
    {
        public string NombreCurso { get; set; }
        public List<Estudiante> ListaEstudiantes { get; set; }

        public Curso(string nombreCurso)
        {
            NombreCurso = nombreCurso;
            ListaEstudiantes = new List<Estudiante>();
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            ListaEstudiantes.Add(estudiante);
        }

        public void MostrarEstudiantes()
        {
            Console.WriteLine("Estudiantes del curso: " + NombreCurso);
            foreach (var estudiante in ListaEstudiantes)
            {
                estudiante.MostrarInfo();
            }
        }

        public List<Estudiante> ObtenerMejoresEstudiantes(decimal minimo = 8m)
        {
            List<Estudiante> mejores = new List<Estudiante>();
            foreach (var est in ListaEstudiantes)
            {
                if (est.Promedio >= minimo)
                {
                    mejores.Add(est);
                }
            }
            return mejores;
        }

        public List<Estudiante> ObtenerEstudiantesReprobados(decimal minimo = 8m)
        {
            List<Estudiante> reprobados = new List<Estudiante>();
            foreach (var est in ListaEstudiantes)
            {
                if (est.Promedio < minimo)
                {
                    reprobados.Add(est);
                }
            }
            return reprobados;
        }

        public decimal PromedioGrupo()
        {
            if (ListaEstudiantes.Count == 0) return 0;

            decimal suma = 0;
            foreach (var est in ListaEstudiantes)
            {
                suma += est.Promedio;
            }
            return suma / ListaEstudiantes.Count;
        }

        public void MostrarPromedioGrupo()
        {
            decimal promedio = PromedioGrupo();
            Console.WriteLine("Promedio del grupo: " + promedio);

            Console.WriteLine("Estudiantes con promedio >= al promedio del grupo:");
            foreach (var est in ListaEstudiantes)
            {
                if (est.Promedio >= promedio)
                {
                    est.MostrarInfo();
                }
            }
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            Curso curso = new Curso("Programación en C#");

            Estudiante e1 = new Estudiante { Nombre = "Diego Osorio", Edad = 21, Promedio = 9.9m };
            Estudiante e2 = new Estudiante { Nombre = "Ana Gómez", Edad = 22, Promedio = 7.5m };

            curso.AgregarEstudiante(e1);
            curso.AgregarEstudiante(e2);


            curso.MostrarEstudiantes();

            Console.WriteLine("\nMejores estudiantes (>= 8):");
            foreach (var est in curso.ObtenerMejoresEstudiantes())
            {
                est.MostrarInfo();
            }

            Console.WriteLine("\nEstudiantes reprobados (< 8):");
            foreach (var est in curso.ObtenerEstudiantesReprobados())
            {
                est.MostrarInfo();
            }

            Console.WriteLine("\nPromedio del grupo:");
            curso.MostrarPromedioGrupo();

            Console.WriteLine("\n--- Fin del programa ---");
        }
    }
}