using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    // Admin class inheriting from User
    // Represents an admin user in the e-commerce application
    public class Admin : User
    {
        public override void DisplayRole()
        {
            Console.WriteLine($"Admin: {Name}");
        }
    }

}
