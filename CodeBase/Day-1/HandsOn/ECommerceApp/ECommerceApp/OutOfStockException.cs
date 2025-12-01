using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string msg) : base(msg) { }
    }

}
