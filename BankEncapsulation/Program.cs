namespace BankEncapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount();
            string choice;
            double amount;

            Console.WriteLine("Welcome to your bank account!");

            do
            {
                Console.WriteLine("Please enter 'D' to deposit, 'W' to withdraw, or 'Q' to quit:");
                choice = Console.ReadLine()?.ToUpper();

                switch (choice)
                {
                    case "D":
                        do
                        {
                            Console.Write("How much would you like to deposit? $");
                            if (!double.TryParse(Console.ReadLine(), out amount))
                            {
                                Console.WriteLine("Invalid amount entered. Please enter a valid number.");
                                continue;
                            }
                        } while (!double.TryParse(Console.ReadLine(), out amount));
                        
                        account.Deposit(amount);
                        Console.WriteLine($"Current balance is: ${account.GetBalance()}");
                        break;

                    case "W":
                        do
                        {
                            Console.Write("How much would you like to withdraw? $");
                            if (!double.TryParse(Console.ReadLine(), out amount))
                            {
                                Console.WriteLine("Invalid amount entered. Please try again.");
                                continue;
                            }
                            
                            if (amount <= account.GetBalance())
                            {
                                break;
                            }
                            
                            Console.WriteLine("Insufficient funds! Please enter a smaller amount.");
                        } while (true);
                        
                        account.Withdraw(amount);
                        Console.WriteLine($"Current balance is: ${account.GetBalance()}");
                        break;

                    case "Q":
                        Console.WriteLine("Thank you for using our banking services!");
                        return;
                }
            } while (choice != "Q");
        }
    }
}