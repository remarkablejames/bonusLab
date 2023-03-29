namespace Bank
{
    // define a base class called Account which will be inherited by other classes like savings account, checking account etc.

    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }

        public virtual void Deposit(decimal amount, Account account)
        {

            if (account is SavingsAccount)
            {
                SavingsAccount savingsAccount = (SavingsAccount)account;
                Balance = Balance + amount + amount * (decimal)savingsAccount.InterestRate;
            }
            else
            {
                Balance += amount;
            }
        }

        public virtual void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        public abstract void Transfer(decimal amount, Account account);
    }
}