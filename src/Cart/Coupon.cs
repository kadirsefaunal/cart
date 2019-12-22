using Cart.Enums;

namespace Cart
{
    public class Coupon
    {
        private double _minAmount;
        private double _discountAmount;
        private DiscountType _discountType;

        public Coupon(double minAmount, double discountAmount, DiscountType discountType)
        {
            this._minAmount = minAmount;
            this._discountAmount = discountAmount;
            this._discountType = discountType;
        }

        public double MinAmount => _minAmount;
        public double DiscountAmount => _discountAmount;
        public DiscountType DiscountType => _discountType;
    }
}