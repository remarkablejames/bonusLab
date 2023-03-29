namespace Bank
{
    public class CheckingAccount : Account
    {
        private static decimal dailyLimit = 3000;
        public CheckingAccount(string accountNumber, string accountHolderName, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public override void Transfer(decimal amount, Account account)
        {
            if (account is SavingsAccount)
            {
                SavingsAccount savingsAccount = (SavingsAccount)account;
                // Withdraw(amount);
                // savingsAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Invalid account type selected for transfer.");
            }
        }

        public override void Withdraw(decimal amount, Account account)
        {
            if (account is CheckingAccount)
            {
                CheckingAccount checkingAccount = (CheckingAccount)account;

                if (amount > Balance)
                {
                    Console.WriteLine("You cannot withdraw more than your balance");
                }
                else if (amount > dailyLimit)
                {
                    Console.WriteLine("You cannot withdraw more than your daily limit");
                }
                else
                {
                    Balance -= amount;
                    Console.WriteLine($"You have withdrawn {amount} from your {account} account");
                }
            }
            else
            {
                Console.WriteLine("Invalid account type selected for transfer.");
            }
        }
    }
}