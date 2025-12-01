using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnSOLIDPrinciples.OCP
{
    #region Violating OCP
    //public class DiscountService
    //{
    //    public double CalculateDiscount(string customerType, double amount)
    //    {
    //        if (customerType == "Regular")
    //            return amount * 0.10;
    //        else if (customerType == "Premium")
    //            return amount * 0.20;
    //        else
    //            return 0;
    //    }
    //}
    /*
     * What’s wrong here?

Every time a new customer type (like “Gold” or “Platinum”) is introduced,
we have to modify this class and recompile the code.

This violates OCP, because the class is not closed for modification.
     */
    #endregion
    #region Following OCP
    public abstract class Discount
    {
        public abstract double Calculate(double amount);
    }
    public class RegularCustomerDiscount : Discount
    {
        public override double Calculate(double amount)
        {
            return amount * 0.10;
        }
    }

    public class PremiumCustomerDiscount : Discount
    {
        public override double Calculate(double amount)
        {
            return amount * 0.20;
        }
    }
    public class DiscountCalculator
    {
        public double GetDiscount(Discount discount, double amount)
        {
            return discount.Calculate(amount);
        }
    }
    class Program
    {
        static void Main()
        {
            var calculator = new DiscountCalculator();

            var regular = new RegularCustomerDiscount();
            Console.WriteLine("Regular Discount: " + calculator.GetDiscount(regular, 1000));

            var premium = new PremiumCustomerDiscount();
            Console.WriteLine("Premium Discount: " + calculator.GetDiscount(premium, 1000));

            // New type added later
            var gold = new GoldCustomerDiscount();
            Console.WriteLine("Gold Discount: " + calculator.GetDiscount(gold, 1000));
        }
    }

    public class GoldCustomerDiscount : Discount
    {
        public override double Calculate(double amount)
        {
            return amount * 0.30;
        }
    } 
    #endregion

}
