namespace CustomExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount("123456", 1000);

                Console.WriteLine($"Original Balance: {account.Balance}");

                Console.WriteLine($"I'm going to buy flowers: {account.Withdraw(500)}");
                Console.WriteLine($"I'm going to take her to the cinema Cinepolis: {account.Withdraw(450)}");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Custom Exception Caught: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Exception Caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception Caught: {ex.Message}");
            } finally
            {
                Console.WriteLine("Thank you for using our banking services.");
            }
        }
    }

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() : base("Insufficient balance for the transaction.") { }

        public InsufficientBalanceException(string message) : base(message) { }

        public InsufficientBalanceException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public string Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientBalanceException($"Attempted to withdraw {amount}, but the available balance is {Balance}.");
            }

            Balance -= amount;
            return $"Withdrew {amount} from account {AccountNumber}. New balance is {Balance}.";
        }
    }
}
