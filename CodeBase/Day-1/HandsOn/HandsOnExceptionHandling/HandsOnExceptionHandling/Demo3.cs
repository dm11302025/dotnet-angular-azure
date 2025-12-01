using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling_Demo3
{
    public class BankAccount
    {
        public decimal Balance { get; private set; } = 1000;

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");

            Balance -= amount;
        }
    }

    internal class Program
    {
        static void Main()
        {
            try
            {
                var account = new BankAccount();
                account.Withdraw(10000);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message); // "Insufficient funds."
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
