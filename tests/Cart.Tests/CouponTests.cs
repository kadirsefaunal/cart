using Cart.Type;
using Xunit;

namespace Cart.Tests
{
    public class CouponTests
    {
        [Fact]
        public void TestApplicableAmountCoupon()
        {
            Coupon coupon = new Coupon(100, 20, new AmountType());
            double totalAmount = coupon.ApplyDiscount(200);
            
            Assert.Equal(20, totalAmount);
        }
        
        [Fact]
        public void TestNotApplicableAmountCoupon()
        {
            Coupon coupon = new Coupon(100, 20, new AmountType());
            double totalAmount = coupon.ApplyDiscount(85);
            
            Assert.Equal(0, totalAmount);
        }
        
        [Fact]
        public void TestApplicableRateCoupon()
        {
            Coupon coupon = new Coupon(100, 5, new RateType());
            double totalAmount = coupon.ApplyDiscount(200);
            
            Assert.Equal(10, totalAmount);
        }
        
        [Fact]
        public void TestNotApplicableRateCoupon()
        {
            Coupon coupon = new Coupon(100, 20, new RateType());
            double totalAmount = coupon.ApplyDiscount(85);
            
            Assert.Equal(0, totalAmount);
        }
    }
}