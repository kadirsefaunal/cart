using System.Collections.Generic;
using System.Linq;
using Cart.Core;

namespace Cart.Service
{
    public class DeliveryCostCalculator
    {
        private readonly double _costPerDelivery;
        private readonly double _costPerProduct;
        private readonly double _fixedCost;

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            _costPerDelivery = costPerDelivery;
            _costPerProduct = costPerProduct;
            _fixedCost = fixedCost;
        }

        /// <summary>
        ///     Calculates the delivery amount of given cart.
        /// </summary>
        public double CalculateFor(ShoppingCart cart)
        {
            var numberOfDeliveries = GetNumberOfDeliveries(cart.CartItems);
            var numberOfProduct = GetNumberOfProduct(cart.CartItems);

            var deliveryCost = _costPerDelivery * numberOfDeliveries + _costPerProduct * numberOfProduct + _fixedCost;

            cart.SetDeliveryCost(deliveryCost);
            
            return deliveryCost;
        }

        private int GetNumberOfDeliveries(List<CartItem> cartItems)
        {
            return cartItems.Select(i => i.Product.Category.Title).Distinct().Count();
        }

        private int GetNumberOfProduct(List<CartItem> cartItems)
        {
            return cartItems.Count();
        }
    }
}