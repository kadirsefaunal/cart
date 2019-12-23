using System.Collections.Generic;
using Cart.Type;

namespace Cart.Core
{
    public class Campaign
    {
        private Category _category;
        private double _amount;
        private int _quantity;
        private DiscountType _discountType;

        public Campaign(Category category, double amount, int quantity, DiscountType discountType)
        {
            _category = category;
            _amount = amount;
            _quantity = quantity;
            _discountType = discountType;
        }

        /// <summary>
        /// Check product count for apply discount
        /// </summary>
        private bool IsApplicable(List<CartItem> cartItems)
        {
            int count = 0;
            
            foreach (var cartItem in cartItems)
            {
                if (cartItem.Product.Category.Equals(_category) 
                    || (cartItem.Product.Category.Parent != null && cartItem.Product.Category.Parent.Equals(_category)))
                {
                    count += cartItem.Quantity;
                }
            }

            return count >= _quantity;
        }

        /// <summary>
        /// Apply discount to given category
        /// </summary>
        public double ApplyDiscount(List<CartItem> cartItems)
        {
            double totalDiscount = 0;
            
            if (IsApplicable(cartItems))
            {
                foreach (var cartItem in cartItems)
                {
                    if (cartItem.Product.Category.Equals(_category) 
                        || (cartItem.Product.Category.Parent != null 
                            && cartItem.Product.Category.Parent.Equals(_category)))
                    {
                        double discountAmount = _discountType.Calculate(cartItem.TotalAmount, _amount);
                        
                        cartItem.TotalDiscount += discountAmount;
                        cartItem.TotalAmount -= discountAmount;
                        totalDiscount += discountAmount;
                    }
                }
            }

            return totalDiscount;
        }
    }
}