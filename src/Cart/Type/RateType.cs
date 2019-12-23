using Cart.Exceptions;

namespace Cart.Type
{
    public class RateType : DiscountType
    {
        public override double Calculate(double totalAmount, double discountAmount)
        {
            if (discountAmount < 0) throw new DiscountAmountException();

            return totalAmount * (discountAmount / 100);
        }
    }
}