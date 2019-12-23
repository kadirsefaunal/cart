namespace Cart.Type
{
    public abstract class DiscountType
    {
        /// <summary>
        /// calculate discount amount by discount type
        /// </summary>
        public abstract double Calculate(double totalAmount, double discountAmount);
    }
}