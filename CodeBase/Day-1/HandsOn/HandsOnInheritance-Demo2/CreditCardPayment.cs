namespace HandsOnInheritance_Demo2
{
    public class CreditCardPayment : Payment
    {
        private string cardNumber;
        private decimal balance;

        public CreditCardPayment(string cardNumber, decimal balance)
        {
            this.cardNumber = cardNumber;
            this.balance = balance;
        }

        public override void Pay(decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Payment failed: insufficient balance!");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Payment successful: {amount:C} paid using card {cardNumber}. Remaining balance: {balance:C}");
            }
        }

        public decimal Balance => balance;
    }

}
