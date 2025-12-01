using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    // Represents a customer in the e-commerce application
    // Inherits from the User base class
    public class Customer : User
    {
        // Overrides the DisplayRole method to specify the role as Customer
        public override void DisplayRole()
        {
            Console.WriteLine($"Customer: {Name}");
        }

    }

}
