using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLINQApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Lista de números
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // LINQ Query Syntax
            var evenNumbersQuery = from num in numbers
                                   where num % 2 == 0
                                   select num;

            Console.WriteLine("Even Numbers (Query Syntax):");
            foreach (var num in evenNumbersQuery)
            {
                Console.WriteLine(num);
            }

            // LINQ Method Syntax con estudiantes
            var evenNumbersMethod = numbers.Where(num => num % 2 == 0);

            Console.WriteLine("Even Numbers (Method Syntax):");
            foreach (var num in evenNumbersMethod)
            {
                Console.WriteLine(num);
            }

            List<Student> students = new List<Student>
            {
                new Student("Alice", 20),
                new Student("Bob", 22),
                new Student("Charlie", 23),
                new Student("Diana", 21),
                new Student("Sofi", 24)
            };

            var orderedStudents = students.OrderBy(s => s.Name).ThenBy(s => s.Age).ToList();
            var orderedStudentsDesc = students.OrderByDescending(s => s.Name).ThenByDescending(s => s.Age).ToList();
            var groupedStudents = students.GroupBy(s => s.Age).ToList();

            Console.WriteLine("\n\n\nStudents grouped by Age: \n");
            foreach (var group in groupedStudents)
            {
                Console.WriteLine($"Age Group: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($" - {student.Name}, Age: {student.Age}");
                }
            }
        }

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Student() { }

            public Student(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }
}
