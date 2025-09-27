using System;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Person person1 = new Person("Bob", 30, "Ally", null, new DateTime(1993, 1, 1));
            Person person2 = new Person("Bob2", 31, "Ally", null, new DateTime(1993, 1, 1));
            Person person3 = new Person("Alice", 28, "Ally", null, new DateTime(1995, 5, 5));
            Person person4 = new Person("Charlie", 35, "Ally", null, new DateTime(1988, 10, 10));

            person1.Introduce();
            person2.Introduce();
            person3.Introduce();
            person4.Introduce();*/

            // Instancia de un único empleado con todos los argumentos de la imagen
            Employee empleado1 = new Employee("Homero", 89, "Toperochito", 1, new DateTime(1995, 5, 15), "Fisico", 200m);
            
            empleado1.Introduce();

            Console.WriteLine("\nValidación de salario mínimo:");
            MostrarSiGanaMenos(empleado1);
        }

        static void MostrarSiGanaMenos(Employee empleado)
        {
            if (empleado.Salary < Employee.MinimumSalary)
            {
                Console.WriteLine($"{empleado.Name} gana ${empleado.Salary:0.00} — gana menos del salario mínimo.");
            }
            else
            {
                 Console.WriteLine($"{empleado.Name} gana ${empleado.Salary:0.00} — cumple o supera el salario mínimo ({Employee.MinimumSalary:0.00}).");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; } = string.Empty;

        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La edad no puede ser negativa.");
                }
                _age = value;
            }
        }

        public string Nickname { get; set; } = "Sin apodo";

        public int? Couple { get; set; } = null;

        public DateTime BirthDate { get; }

        public static int Population { get; private set; } = 0;

        public Person(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
                this.Name = "Desconocido";
            else
                this.Name = name;

            Age = age;
            BirthDate = DateTime.Now;

            Population++;
        }

        public Person(string name, int age, string nickname, int? couple, DateTime birthDate) : this(name, age)
        {
            Nickname = nickname;
            Couple = couple;
            // BirthDate = birthDate;
        }
        
        public Person(string name, int age, string nickname, int? couple, DateTime birthDate, bool fullInit)
        {
            if (string.IsNullOrEmpty(name))
                this.Name = "Desconocido";
            else
                this.Name = name;
            Age = age;

            Nickname = nickname;
            Couple = couple;
            BirthDate = birthDate;
            
            Population++;
        }


        public virtual void Introduce()
        {
            Console.WriteLine($"Hola, me llamo {Name} y tengo {Age} años.");
        }
    }

    //Herencia
    // Validacion para el salario menor al minimo
    public class Employee : Person
    {
        public string position { get; set; } = "Desempleado";

        private decimal _salary;

        //No sea menor al salario mínimo
        public const decimal MinimumSalary = 300m;

        public decimal Salary
        {
            get => _salary;
            set => _salary = value;
        }

0        public Employee(string name, int age, string nickname, int? couple, DateTime birthDate, string position, decimal salary) 
            : base(name, age, nickname, couple, birthDate, true)
        {
            this.position = position;
            Salary = salary;
        }

        public override void Introduce()
        {
            base.Introduce();
            Console.WriteLine($"Trabajo como {position} y gano ${Salary:0.00} diarios.");
        }
    }
}
