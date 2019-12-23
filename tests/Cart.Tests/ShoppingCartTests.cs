using System.Linq;
using Cart.Core;
using Cart.Type;
using Xunit;

namespace Cart.Tests
{
    public class ShoppingCartTests
    {
        private ShoppingCart getShoppingCart()
        {
            var category = new Category("test");

            var product1 = new Product("product1", 300, category);
            var product2 = new Product("product2", 50, category);

            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(product1, 2);
            shoppingCart.AddItem(product2, 6);
            shoppingCart.AddItem(product1, 1);

            return shoppingCart;
        }

        [Fact]
        public void TestAddCartItem()
        {
            var shoppingCart = getShoppingCart();
            var cartItems = shoppingCart.CartItems;

            Assert.Equal(2, cartItems.Count());
        }

        [Fact]
        public void TestApplyCoupon()
        {
            var category = new Category("test");

            var coupon = new Coupon(1000, 150, new AmountType());

            var shoppingCart = getShoppingCart();
            shoppingCart.ApplyCoupons(coupon);

            Assert.Equal(1050, shoppingCart.TotalAmount);
        }

        [Fact]
        public void TestApplyDiscounts()
        {
            var category = new Category("test");

            var discount1 = new Campaign(category, 100, 2, new AmountType());
            var discount2 = new Campaign(category, 10, 2, new RateType());

            var shoppingCart = getShoppingCart();
            shoppingCart.ApplyDiscounts(discount1, discount2);

            Assert.Equal(900, shoppingCart.TotalAmount);
        }
    }
}