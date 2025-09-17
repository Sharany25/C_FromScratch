namespace ControlFlowStatements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IfStatementExample();
            IfElseExample();
            SwichtStatementExample();
        }

        private static void IfStatementExample()
        {
            int number = 10;

            if (number > 5)
                Console.WriteLine("Number is greater than 5");
            else
                Console.WriteLine("Number is 5 or less");
        }

        private static void IfElseExample()
        {
            int number = 10;
            if (number > 10)
            {
                Console.WriteLine("Number is greater than 10");
            }
            else if (number == 10)
            {
                Console.WriteLine("Number is exactly 10");
            }
            else
            {
                Console.WriteLine("Number is less than 10");
            }
        }

        private static void SwichtStatementExample()
        {
            int day = 3;
            string dayName;
            switch (day)
            {
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                case 7:
                    dayName = "Sunday";
                    break;
                default:
                    dayName = "Invalid day";
                    break;
            }
            Console.WriteLine($"Day {day} is {dayName}");
        }
    }
}
