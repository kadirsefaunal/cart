using System.Collections.Generic;
using Cart.Type;
using Cart.Core;
using Xunit;

namespace Cart.Tests
{
    public class CampaignTests
    {
        private List<CartItem> getCartItems()
        {
            List<CartItem> cartItems = new List<CartItem>();
            
            Category category1 = new Category("test");
            
            Category parent = new Category("test-parent");
            Category category2 = new Category("test2", parent);
            

            Product product1 = new Product("product 1", 100, category1);
            Product product2 = new Product("product 2", 150, category1);
            Product product3 = new Product("product 3", 60, category2);
            
            CartItem cartItem1 = new CartItem();
            cartItem1.Product = product1;
            cartItem1.Quantity = 2;
            cartItem1.TotalAmount = cartItem1.Quantity * product1.Amount;
            
            CartItem cartItem2 = new CartItem();
            cartItem2.Product = product2;
            cartItem2.Quantity = 2;
            cartItem2.TotalAmount = cartItem2.Quantity * product2.Amount;
            
            CartItem cartItem3 = new CartItem();
            cartItem3.Product = product3;
            cartItem3.Quantity = 2;
            cartItem3.TotalAmount = cartItem3.Quantity * product3.Amount;
            
            cartItems.Add(cartItem1);
            cartItems.Add(cartItem2);
            cartItems.Add(cartItem3);

            return cartItems;
        }

        [Fact]
        private void TestApplicableAmountDiscount()
        {
            List<CartItem> cartItems = getCartItems();
            Category category = new Category("test");

            Campaign campaign = new Campaign(category, 100, 4, new AmountType());
            double totalDiscount = campaign.ApplyDiscount(cartItems);
            
            Assert.Equal(200, totalDiscount);
        }
        
        [Fact]
        private void TestNotApplicableAmountDiscount()
        {
            List<CartItem> cartItems = getCartItems();
            Category category = new Category("test");

            Campaign campaign = new Campaign(category, 100, 6, new AmountType());
            double totalDiscount = campaign.ApplyDiscount(cartItems);
            
            Assert.Equal(0, totalDiscount);
        }
        
        [Fact]
        private void TestApplicableRateDiscount()
        {
            List<CartItem> cartItems = getCartItems();
            Category category = new Category("test");

            Campaign campaign = new Campaign(category, 10, 4, new RateType());
            double totalDiscount = campaign.ApplyDiscount(cartItems);
            
            Assert.Equal(50, totalDiscount);
        }
        
        [Fact]
        private void TestNotApplicableRateDiscount()
        {
            List<CartItem> cartItems = getCartItems();
            Category category = new Category("test");

            Campaign campaign = new Campaign(category, 10, 6, new RateType());
            double totalDiscount = campaign.ApplyDiscount(cartItems);
            
            Assert.Equal(0, totalDiscount);
        }
        
        [Fact]
        private void TestApplicableRateDiscountParentCategory()
        {
            List<CartItem> cartItems = getCartItems();
            
            Category parent = new Category("test-parent");
            Category category = new Category("test2", parent);

            Campaign campaign = new Campaign(parent, 10, 1, new RateType());
            double totalDiscount = campaign.ApplyDiscount(cartItems);
            
            Assert.Equal(12, totalDiscount);
        }
    }
}