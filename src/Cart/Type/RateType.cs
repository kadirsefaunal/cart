namespace Cart.Type
{
    public class RateType : DiscountType
    {
        public override double Calculate(double totalAmount, double discountAmount)
        {
            return totalAmount * (discountAmount / 100);
        }
    }
}