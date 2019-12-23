using Cart.Exceptions;

namespace Cart.Type
{
    public class AmountType : DiscountType
    {
        public override double Calculate(double totalAmount, double discountAmount)
        {
            if (discountAmount < 0 || discountAmount > totalAmount) throw new DiscountAmountException();

            return discountAmount;
        }
    }
}