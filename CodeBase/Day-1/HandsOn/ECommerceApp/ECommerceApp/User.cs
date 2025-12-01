using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    // Base class for different types of users
    // Demonstrates the use of abstract classes in C# 14.0
    public abstract class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }

        public abstract void DisplayRole(); // Abstract method to be implemented by derived classes
    }

}
