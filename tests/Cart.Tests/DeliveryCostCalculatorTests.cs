using Cart.Core;
using Cart.Service;
using Xunit;

namespace Cart.Tests
{
    public class DeliveryCostCalculatorTests
    {
        private const double FixedCost = 2.99;
            
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
        public void TestCalculateDelivery()
        {
            var cart = getShoppingCart();
            
            var deliveryCostCalculator = new DeliveryCostCalculator(5, 0.7, FixedCost);
            var deliveryAmount = deliveryCostCalculator.CalculateFor(cart);
            
            Assert.Equal(9.39, deliveryAmount);
        }
    }
}