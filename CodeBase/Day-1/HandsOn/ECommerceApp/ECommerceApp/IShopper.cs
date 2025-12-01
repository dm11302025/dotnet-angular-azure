using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    // Interface representing a shopper in the e-commerce application
    // Defines a method to add products to the shopping cart
    public interface IShopper
    {
        void AddToCart(Product product, int qty);
    }

}
