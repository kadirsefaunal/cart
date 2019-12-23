using System;
using Cart;
using Cart.Core;
using Cart.Service;
using Cart.Type;

namespace App
{
    class Program
    {
        private const double FixedCost = 2.99;
        
        static void Main(string[] args)
        {
            var food = new Category("food");
            
            var apple = new Product("Apple", 100.0, food);
            var almond = new Product("Almond", 150.0, food);
            
            var cart = new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);
            
            var campaign1 = new Campaign(food, 20.0, 3, new RateType());
            var campaign2 = new Campaign(food, 50.0, 5, new RateType());
            var campaign3 = new Campaign(food, 5.0, 5, new AmountType());
            
            cart.ApplyDiscounts(campaign1, campaign2, campaign3);
            
            var coupon = new Coupon(100, 10, new RateType());

            cart.ApplyCoupons(coupon);
            
            var deliveryCostCalculator = new DeliveryCostCalculator(5.0, 1.0, FixedCost);
            var deliveryAmount = deliveryCostCalculator.CalculateFor(cart);
            
            cart.Print();
        }
    }
}
