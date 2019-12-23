using Cart.Exceptions;
using Cart.Type;
using Xunit;

namespace Cart.Tests
{
    public class DiscountTypeTests
    {
        [Fact]
        public void TestAmountTypeCalculate()
        {
            AmountType amountType = new AmountType();

            var result = amountType.Calculate(100, 20);
            
            Assert.Equal(20, result);
        }
        
        [Fact]
        public void TestAmountTypeCalculateInvalidAmount()
        {
            AmountType amountType = new AmountType();
            
            Assert.Throws<DiscountAmountException>(() => amountType.Calculate(100, -20));
        }
        
        [Fact]
        public void TestRateTypeCalculate()
        {
            RateType rateType = new RateType();

            var result = rateType.Calculate(200, 30);

            Assert.Equal(60, result);
        }
        
        [Fact]
        public void TestRateTypeCalculateInvalidAmount()
        {
            RateType rateType = new RateType();
            
            Assert.Throws<DiscountAmountException>(() => rateType.Calculate(200, -20));
        }
    }
}