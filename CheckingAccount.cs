namespace Bank
{
    public class CheckingAccount : Account
    {
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
                Withdraw(amount);
                // savingsAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Invalid account type selected for transfer.");
            }
        }
    }
}