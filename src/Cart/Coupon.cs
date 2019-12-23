using Cart.Type;

namespace Cart
{
    public class Coupon
    {
        private double _minAmount;
        private double _discountAmount;
        private DiscountType _discountType;

        public Coupon(double minAmount, double discountAmount, DiscountType discountType)
        {
            _minAmount = minAmount;
            _discountAmount = discountAmount;
            _discountType = discountType;
        }

        public double MinAmount => _minAmount;
        public double DiscountAmount => _discountAmount;
        public DiscountType DiscountType => _discountType;
        
        /// <summary>
        /// Check total amount. It must be bigger than coupon min amount.
        /// </summary>
        private bool IsApplicable(double totalAmount)
        {
            return totalAmount >= _minAmount;
        }

        /// <summary>
        /// Calculate discount amount for cart
        /// </summary>
        public double ApplyDiscount(double totalAmount)
        {
            if (IsApplicable(totalAmount))
            {
                return _discountType.Calculate(totalAmount, _discountAmount);
            }

            return 0;
        }
    }
}