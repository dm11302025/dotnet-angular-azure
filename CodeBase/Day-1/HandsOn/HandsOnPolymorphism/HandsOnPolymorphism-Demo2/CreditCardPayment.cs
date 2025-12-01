namespace HandsOnPolymorphism_Demo2
{
    using System;

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
                Console.WriteLine("Payment failed: insufficient balance!");
            else
            {
                balance -= amount;
                Console.WriteLine($"Paid {amount:C} using Credit Card {cardNumber}. Remaining balance: {balance:C}");
            }
        }

        public decimal Balance => balance;
    }

}
