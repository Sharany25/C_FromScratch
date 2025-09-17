namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            PrintSum();
        }

        // Metodo para sumar dos numeros
        private static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public static void PrintSum()
        {
            int sum = AddNumbers(5, 10);
            Console.WriteLine($"This sum is: {sum}");
        }
    }
}
