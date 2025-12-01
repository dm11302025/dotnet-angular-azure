using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling.CustomExceptions
{
    public class PaymentException : ECommerceException
    {
        public PaymentException(string message) : base(message) { }
    }
}
