using Cart.Core;
using Cart.Type;
using Xunit;

namespace Cart.Tests
{
    public class CouponTests
    {
        [Fact]
        public void TestApplicableAmountCoupon()
        {
            var coupon = new Coupon(100, 20, new AmountType());
            var totalAmount = coupon.ApplyDiscount(200);

            Assert.Equal(20, totalAmount);
        }

        [Fact]
        public void TestApplicableRateCoupon()
        {
            var coupon = new Coupon(100, 5, new RateType());
            var totalAmount = coupon.ApplyDiscount(200);

            Assert.Equal(10, totalAmount);
        }

        [Fact]
        public void TestNotApplicableAmountCoupon()
        {
            var coupon = new Coupon(100, 20, new AmountType());
            var totalAmount = coupon.ApplyDiscount(85);

            Assert.Equal(0, totalAmount);
        }

        [Fact]
        public void TestNotApplicableRateCoupon()
        {
            var coupon = new Coupon(100, 20, new RateType());
            var totalAmount = coupon.ApplyDiscount(85);

            Assert.Equal(0, totalAmount);
        }
    }
}