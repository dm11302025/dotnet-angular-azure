namespace HandsOnPolymorphism_Demo2
{
    using System;

    public class UpiPayment : Payment
    {
        private string upiId;
        private decimal balance;

        public UpiPayment(string upiId, decimal balance)
        {
            this.upiId = upiId;
            this.balance = balance;
        }

        public override void Pay(decimal amount)
        {
            if (amount > balance)
                Console.WriteLine("Payment failed: insufficient balance!");
            else
            {
                balance -= amount;
                Console.WriteLine($"Paid {amount:C} using UPI {upiId}. Remaining balance: {balance:C}");
            }
        }
    }

}
