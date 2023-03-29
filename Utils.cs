namespace Bank
{
    public class Utils
    {
        public static string chooseAccount()
        {


            Console.WriteLine("Select account (1- checking , 2- saving account): ");
            int? choice = int.TryParse(Console.ReadLine(), out int choiceValue) ? choiceValue : null;
            if (choice == 1)
            {
                return "checking";
            }
            else if (choice == 2)
            {
                return "saving";
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again! ");
                return chooseAccount();
            }

        }

        public static decimal getAmount()
        {
            Console.Write("Enter the amount: ");
            decimal? amount = decimal.TryParse(Console.ReadLine(), out decimal amountValue) ? amountValue : null;

            while (amount == null || amount <= 0)
            {
                Console.Write("Invalid amount. Please enter the amount: ");
                amount = decimal.TryParse(Console.ReadLine(), out amountValue) ? amountValue : null;
            }
            return amount.Value;
        }
    }
}