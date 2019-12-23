using System;

namespace Cart.Exceptions
{
    public class DiscountAmountException : Exception
    {
        public DiscountAmountException() : base("Invalid discount amount")
        {
        }
    }
}