using System;
using Bank;
namespace BankApplication
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank Application");
            // prompt the user to enter their name and make sure its not empty or null or any other invalid value
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.Write("Invalid name. Please enter your name: ");
                name = Console.ReadLine();
            }

            // prompt the user to choose from the available options: deposit, withdraw, transfer,account activity, check balance, exit. use loop to keep prompting the user until they choose to exit

            while (true)
            {
                Console.WriteLine("Choose from the following options:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Account Activity Enquiry");
                Console.WriteLine("5. Balance Enquiry");
                Console.WriteLine("6. Exit");
                Console.Write("Please enter your selection (1 to 6): ");
                int? choice = int.TryParse(Console.ReadLine(), out int choiceValue) ? choiceValue : null;
                while (choice == null || choice < 1 || choice > 6)
                {
                    Console.Write("Invalid choice. Please enter your choice: ");
                    choice = int.TryParse(Console.ReadLine(), out choiceValue) ? choiceValue : null;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Deposit");
                        break;
                    case 2:
                        Console.WriteLine("Withdraw");
                        break;
                    case 3:
                        Console.WriteLine("Transfer");
                        break;
                    case 4:
                        Console.WriteLine("Account Activity Enquiry");
                        break;
                    case 5:
                        Console.WriteLine("Balance Enquiry");
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using the Bank Application. Goodbye!");
                        return;
                }


            }
        }
    }
}

