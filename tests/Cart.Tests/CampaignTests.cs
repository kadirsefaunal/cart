using System.Collections.Generic;
using Cart.Core;
using Cart.Type;
using Xunit;

namespace Cart.Tests
{
    public class CampaignTests
    {
        private List<CartItem> getCartItems()
        {
            var cartItems = new List<CartItem>();

            var category1 = new Category("test");

            var parent = new Category("test-parent");
            var category2 = new Category("test2", parent);

            var product1 = new Product("product 1", 100, category1);
            var product2 = new Product("product 2", 150, category1);
            var product3 = new Product("product 3", 60, category2);

            var cartItem1 = new CartItem();
            cartItem1.Product = product1;
            cartItem1.Quantity = 2;
            cartItem1.TotalAmount = cartItem1.Quantity * product1.Amount;

            var cartItem2 = new CartItem();
            cartItem2.Product = product2;
            cartItem2.Quantity = 2;
            cartItem2.TotalAmount = cartItem2.Quantity * product2.Amount;

            var cartItem3 = new CartItem();
            cartItem3.Product = product3;
            cartItem3.Quantity = 2;
            cartItem3.TotalAmount = cartItem3.Quantity * product3.Amount;

            cartItems.Add(cartItem1);
            cartItems.Add(cartItem2);
            cartItems.Add(cartItem3);

            return cartItems;
        }

        [Fact]
        public void TestApplicableAmountDiscount()
        {
            var cartItems = getCartItems();
            var category = new Category("test");

            var campaign = new Campaign(category, 100, 4, new AmountType());
            var totalDiscount = campaign.ApplyDiscount(cartItems);

            Assert.Equal(200, totalDiscount);
        }

        [Fact]
        public void TestApplicableRateDiscount()
        {
            var cartItems = getCartItems();
            var category = new Category("test");

            var campaign = new Campaign(category, 10, 4, new RateType());
            var totalDiscount = campaign.ApplyDiscount(cartItems);

            Assert.Equal(50, totalDiscount);
        }

        [Fact]
        public void TestApplicableRateDiscountParentCategory()
        {
            var cartItems = getCartItems();

            var parent = new Category("test-parent");
            var category = new Category("test2", parent);

            var campaign = new Campaign(parent, 10, 1, new RateType());
            var totalDiscount = campaign.ApplyDiscount(cartItems);

            Assert.Equal(12, totalDiscount);
        }

        [Fact]
        public void TestNotApplicableAmountDiscount()
        {
            var cartItems = getCartItems();
            var category = new Category("test");

            var campaign = new Campaign(category, 100, 6, new AmountType());
            var totalDiscount = campaign.ApplyDiscount(cartItems);

            Assert.Equal(0, totalDiscount);
        }

        [Fact]
        public void TestNotApplicableRateDiscount()
        {
            var cartItems = getCartItems();
            var category = new Category("test");

            var campaign = new Campaign(category, 10, 6, new RateType());
            var totalDiscount = campaign.ApplyDiscount(cartItems);

            Assert.Equal(0, totalDiscount);
        }
    }
}