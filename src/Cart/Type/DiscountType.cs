namespace Cart.Type
{
    public abstract class DiscountType
    {
        public abstract double Calculate(double totalAmount, double discountAmount);
    }
}