using System.Windows.Markup;

namespace Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable declaration
            int number;
            string name;

            // Variable initializacion
            number = 10;
            name = "Diego Osorio";

            // Implicity type Variable
            var isActive = true;
            var pi = 3.14;
            var city = "New York";

            Console.WriteLine($"Number: {number}, Name : {name}");
        }
    }
}
