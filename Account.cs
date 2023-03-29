namespace Bank
{
    // define a base class called Account which will be inherited by other classes like savings account, checking account etc.

    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }

        public virtual void Deposit(double amount, double interestRate = 1)
        {
            if (interestRate > 1)
            {
                Balance += amount * interestRate;
            }
            else
            {
                Balance += amount;
            }
        }

        public virtual void Withdraw(double amount)
        {
            Balance -= amount;
        }

        public abstract void Transfer(double amount, Account account);
    }
}