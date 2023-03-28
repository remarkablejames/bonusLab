using System;

namespace BankApplication
{
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }

        public virtual void Deposit(double amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            Balance -= amount;
        }

        public abstract void Transfer(double amount, Account account);
    }

    public class CheckingAccount : Account
    {
        public CheckingAccount(string accountNumber, string accountHolderName, double balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public override void Transfer(double amount, Account account)
        {
            if (account is SavingsAccount)
            {
                SavingsAccount savingsAccount = (SavingsAccount)account;
                Withdraw(amount);
                savingsAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Invalid account type selected for transfer.");
            }
        }
    }

    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, string accountHolderName, double balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public override void Transfer(double amount, Account account)
        {
            if (account is CheckingAccount)
            {
                CheckingAccount checkingAccount = (CheckingAccount)account;
                Withdraw(amount);
                checkingAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Invalid account type selected for transfer.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank Application");
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();

            CheckingAccount checkingAccount = new CheckingAccount("123456", name, 5000);
            SavingsAccount savingsAccount = new SavingsAccount("789012", name, 10000);

            Console.WriteLine("Which account do you want to use? Enter 1 for checking or 2 for savings:");
            int accountChoice = int.Parse(Console.ReadLine());

            Account account = accountChoice == 1 ? (Account)checkingAccount : savingsAccount;

            Console.WriteLine("What operation do you want to perform? Enter 1 for deposit, 2 for withdraw, or 3 for transfer:");
            int operationChoice = int.Parse(Console.ReadLine());

            switch (operationChoice)
            {
                case 1:
                    Console.WriteLine("Enter amount to deposit: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    Console.WriteLine($"New balance: {account.Balance:C}");
                    break;
                case 2:
                    Console.WriteLine("Enter amount to withdraw: ");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    Console.WriteLine($"New balance: {account.Balance:C}");
                    break;
                case 3:
                    Console.WriteLine("Enter amount to transfer: ");
                    double transferAmount = double.Parse(Console.ReadLine());
                    Console.WriteLine("Which account do you want to transfer to? Enter 1 for checking or 2 for savings:");
                    int transferAccountChoice = int.Parse(Console.ReadLine());
                    Account transferAccount = transferAccountChoice == 1 ? (Account)checkingAccount : savingsAccount;
                    account.Transfer(transferAmount,
                        transferAccount);
                    Console.WriteLine($"New balance: {account.Balance:C}");
                    break;
                default:
                    Console.WriteLine("Invalid operation selected.");
                    break;
            }
        }
    }
}

