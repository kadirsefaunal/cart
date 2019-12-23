using System.Collections.Generic;
using System.Linq;
using Cart.Type;
using Xunit;

namespace Cart.Tests
{
    public class ShoppingCartTests
    {
        private ShoppingCart getShoppingCart()
        {
            Category category = new Category("test");
            
            Product product1 = new Product("product1", 300, category);
            Product product2 = new Product("product2", 50, category);

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(product1, 2);
            shoppingCart.AddItem(product2, 6);
            shoppingCart.AddItem(product1, 1);

            return shoppingCart;
        }
        
        [Fact]
        public void TestAddCartItem()
        {
            ShoppingCart shoppingCart = getShoppingCart();
            List<CartItem> cartItems = shoppingCart.CartItems;
            
            Assert.Equal(2, cartItems.Count());
        }
        
        [Fact]
        public void TestApplyDiscounts()
        {
            Category category = new Category("test");
            
            Campaign discount1 = new Campaign(category, 100, 2, new AmountType());
            Campaign discount2 = new Campaign(category, 10, 2, new RateType());
            
            ShoppingCart shoppingCart = getShoppingCart();
            shoppingCart.ApplyDiscounts(discount1, discount2);
            
            Assert.Equal(900, shoppingCart.TotalAmount);
        }

        [Fact]
        public void TestApplyCoupon()
        {
            Category category = new Category("test");
            
            Coupon coupon = new Coupon(1000, 150, new AmountType());
            
            ShoppingCart shoppingCart = getShoppingCart();
            shoppingCart.ApplyCoupons(coupon);
            
            Assert.Equal(1050, shoppingCart.TotalAmount);
        }
    }
}