using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling.CustomExceptions
{
    public class InsufficientInventoryException : Exception
    {
        public int ProductId { get; }

        public InsufficientInventoryException(int productId, string message)
            : base(message)
        {
            ProductId = productId;
        }
    }

}
