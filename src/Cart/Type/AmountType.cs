namespace Cart.Type
{
    public class AmountType : DiscountType
    {
        public override double Calculate(double totalAmount, double discountAmount)
        {
            return discountAmount;
        }
    }
}