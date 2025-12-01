using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnEncapsulation
{
    //Encapsulation Example
    public class BankAccount
    {
        // Private field - hidden from outside
        private decimal balance;

        // Public method - controlled access
        public void Deposit(decimal amount)
        {
            if (amount > 0)
                balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
                balance -= amount;
        }

        //// Read-Write property
        //public decimal Balance
        //{
        //    get { return balance; }
        //    set { balance = value; }
        //}
        // Read-only property
        public decimal Balance
        {
            get { return balance; }
           
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount();
            //set initial balance
            //account.Balance = 1000;
            account.Deposit(1000);
            account.Withdraw(200);

            // Can't access balance directly (account.balance ❌)
            Console.WriteLine($"Current Balance: {account.Balance}");
            /*Here, the balance field is hidden (private) and can only be accessed via methods or properties.
                    This prevents misuse like account.balance = -1000.*/
        }
    }

}
