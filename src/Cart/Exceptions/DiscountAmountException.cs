using System;

namespace Cart.Exceptions
{
    public class DiscountAmountException : Exception
    {
        public DiscountAmountException() : base("Invalid discount amount")
        {
            
        }

        public DiscountAmountException(string message) : base(message)
        {
            
        }
    }
}