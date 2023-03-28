namespace Bank
{
    // define a base class called Account which will be inherited by other classes like savings account, checking account etc.

    public class Account
    {
        // define the properties of the class
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }

        // define a constructor
        public Account(string accountNumber, string accountName, double balance)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            Balance = balance;
        }

        // define a method to deposit money
        public void Deposit(double amount, double intrestRate = 1)
        {
            // calculate the intrest and add it to the amount
            if (intrestRate > 1)
            {
                double intrest = amount * intrestRate / 100;
                amount += intrest;
                Balance += amount;
            }
            else
            {
                Balance += amount;
            }
        }

        // define a method to withdraw money
        public void Withdraw(double amount)
        {
            Balance -= amount;
        }
    }
}