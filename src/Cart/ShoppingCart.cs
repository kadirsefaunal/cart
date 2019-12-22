using System;
using System.Collections.Generic;

namespace Cart
{
    public class ShoppingCart
    {
        private List<CartItem> _cartItems = new List<CartItem>();
        private List<Campaign> _campaigns = new List<Campaign>();
        private List<Coupon> _coupons = new List<Coupon>();
        
        private double _totalAmount;
        private double _totalCouponDiscount;

        public List<CartItem> CartItems => _cartItems;
        public List<Campaign> Campaigns => _campaigns;
        public List<Coupon> Coupons => _coupons;
        
        public void AddItem(Product product, int quantity)
        {
            bool isProductExist = false;
            
            foreach (var cartItem in _cartItems)
            {
                if (cartItem.Product.Equals(product))
                {
                    double amount = cartItem.Product.Amount * quantity;
                    
                    cartItem.Quantity += quantity;
                    cartItem.TotalAmount += amount;
                    _totalAmount += amount;
                    isProductExist = true;
                    
                    break;
                }
            }

            if (!isProductExist)
            {
                var cartItem = new CartItem();
            
                cartItem.Product = product;
                cartItem.Quantity = quantity;
                cartItem.TotalAmount = product.Amount * quantity;

                _totalAmount += cartItem.TotalAmount;
            
                _cartItems.Add(cartItem);    
            }
        }

        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            foreach (var campaign in campaigns)
            {
                _totalAmount -= campaign.ApplyDiscount(_cartItems);
            }
        }
        
        public void ApplyCoupons(params Coupon[] coupons)
        {
            foreach (var coupon in coupons)
            {
                _totalCouponDiscount += coupon.ApplyDiscount(_totalAmount);
            }

            _totalAmount -= _totalCouponDiscount;
        }
    }
}