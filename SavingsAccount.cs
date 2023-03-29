namespace Bank
{
    public class SavingsAccount : Account
    {

        private static double interestRate = 0.05;

        public double InterestRate
        {
            get { return interestRate; }
        }


        public SavingsAccount(string accountNumber, string accountHolderName, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public override void Transfer(decimal amount, Account account)
        {
            if (account is CheckingAccount)
            {
                CheckingAccount checkingAccount = (CheckingAccount)account;
                Withdraw(amount);
                // checkingAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Invalid account type selected for transfer.");
            }
        }
    }
}