using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_Demo5
{
    // Delegates allow you to swap logic at runtime
    // — this helps in applying design patterns like Strategy or Observer.
    public delegate int DiscountStrategy(int amount);

    class ShoppingCart
    {
        public int ApplyDiscount(DiscountStrategy strategy, int total)
        {
            return strategy(total);
        }
    }

    class Program
    {
        static void Main()
        {
            ShoppingCart cart = new ShoppingCart();

            DiscountStrategy festivalDiscount = amount => amount - 500;
            DiscountStrategy regularDiscount = amount => amount - 100;

            Console.WriteLine(cart.ApplyDiscount(festivalDiscount, 3000)); // 2500
            Console.WriteLine(cart.ApplyDiscount(regularDiscount, 3000));  // 2900
        }
    }

}
