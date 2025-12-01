namespace HandsOnEncapsulationAndAbstraction
{

    #region Abstraction
    // Abstract class - defines "what" a payment must do
    public abstract class Payment
    {
        public abstract void Pay(decimal amount);
    }
    #endregion

    #region Encapsulation + Implementation
    // Concrete class using Encapsulation
    public class CreditCardPayment : Payment
    {
        // Encapsulation: hiding sensitive data
        private string cardNumber;
        private string cardHolder;
        private decimal balance;

        // Constructor
        public CreditCardPayment(string cardNumber, string cardHolder, decimal initialBalance)
        {
            this.cardNumber = cardNumber;
            this.cardHolder = cardHolder;
            this.balance = initialBalance;
        }

        // Encapsulation: exposing balance safely (read-only property)
        public decimal Balance
        {
            get { return balance; }
        }

        // Implementation of abstract method (Abstraction in action)
        public override void Pay(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid payment amount.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }

            balance -= amount;
            Console.WriteLine($"Paid {amount:C} using Credit Card of {cardHolder}. Remaining Balance: {balance:C}");
        }
    }

    public class UpiPayment : Payment
    {
        private string upiId;
        private decimal balance;

        public UpiPayment(string upiId, decimal initialBalance)
        {
            this.upiId = upiId;
            this.balance = initialBalance;
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public override void Pay(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid payment amount.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient UPI balance!");
                return;
            }

            balance -= amount;
            Console.WriteLine($"Paid {amount:C} using UPI ID {upiId}. Remaining Balance: {balance:C}");
        }
    }
    #endregion

    #region Test Program
    class Program
    {
        static void Main()
        {
            // Using abstraction (we don't care HOW payment works, just call Pay)
            Payment cardPayment = new CreditCardPayment("1234-5678-9999", "Adrija", 5000);
            Payment upiPayment = new UpiPayment("adrija@upi", 2000);

            // Making payments
            cardPayment.Pay(1200);
            upiPayment.Pay(500);
            cardPayment.Pay(4000); // should show insufficient balance
            /*
             Abstraction

Payment (abstract class) defines the contract (Pay method).

CreditCardPayment and UpiPayment implement their own versions of Pay.

Encapsulation

Sensitive data like cardNumber, upiId, and balance are private.

Access is only via public methods/properties (Balance, Pay).
             */
        }
    }
    #endregion

}
