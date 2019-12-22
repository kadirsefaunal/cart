using System;
using Cart;
using Cart.Type;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Category category1 = new Category("test");
            Category category2 = new Category("test2");

            Product product1 = new Product("product 1", 100, category1);
            Product product2 = new Product("product 2", 150, category1);
            Product product3 = new Product("product 3", 60, category2);
            
            Campaign campaign = new Campaign(category1, 10, 10, new RateType());
            
            Coupon coupon = new Coupon(1200, 200, new AmountType());

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(product1, 2);
            shoppingCart.AddItem(product1, 4);
            shoppingCart.AddItem(product2, 3);
            shoppingCart.AddItem(product3, 1);
            
            shoppingCart.ApplyDiscounts(campaign);
            shoppingCart.ApplyCoupons(coupon);

            var asd = shoppingCart.CartItems;
        }
    }
}
