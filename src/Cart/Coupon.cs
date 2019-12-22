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
        
        private bool IsApplicable(double totalAmount)
        {
            return totalAmount >= _minAmount;
        }

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