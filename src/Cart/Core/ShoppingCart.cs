using System;
using System.Collections.Generic;
using System.Linq;

namespace Cart.Core
{
    public class ShoppingCart
    {
        private List<CartItem> _cartItems = new List<CartItem>();
        private List<Campaign> _campaigns = new List<Campaign>();
        private List<Coupon> _coupons = new List<Coupon>();
        
        private double _totalAmount;
        private double _totalCouponDiscount;
        private double _deliveryCost;

        public List<CartItem> CartItems => _cartItems;

        public void SetDeliveryCost(double deliveryCost) => _deliveryCost = deliveryCost;
        
        public double GetTotalAmountAfterDiscounts() => _totalAmount;

        public double GetCouponDiscounts() => _totalCouponDiscount;

        public double GetCampaingDiscount() => _cartItems.Sum(i => i.TotalDiscount);

        public double GetDeliveryCost() => _deliveryCost;
        
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

        /// <summary>
        /// Apply given discounts in given order
        /// </summary>
        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            foreach (var campaign in campaigns)
            {
                _totalAmount -= campaign.ApplyDiscount(_cartItems);
            }
        }
        
        /// <summary>
        /// Apply coupons to car in given order
        /// </summary>
        public void ApplyCoupons(params Coupon[] coupons)
        {
            foreach (var coupon in coupons)
            {
                _totalCouponDiscount += coupon.ApplyDiscount(_totalAmount);
            }

            _totalAmount -= _totalCouponDiscount;
        }

        public void Print()
        {
            var previousCategory = new Category("");

            Console.WriteLine("CategoryName" 
                              + "\t" + "ProductName" 
                              + "\n" + "Quantity" 
                              + "\t" + "Unit Price" 
                              + "\t" + "Total Price (With Campaign)" 
                              + "\t" + "Total Campaign Discount");
            
            foreach (var cartItem in CartItems)
            {
                var category = cartItem.Product.Category;

                if (!category.Equals(previousCategory)) Console.Write(category.Title);

                Console.WriteLine("\t" + cartItem.Product.Title 
                                       + "\t" + cartItem.Quantity 
                                       + "\t" + cartItem.Product.Amount 
                                       + "\t" + cartItem.TotalAmount 
                                       + "\t" + cartItem.TotalDiscount);
                
                previousCategory = category;
            }

            Console.WriteLine("Coupon discount: " + GetCouponDiscounts());
            Console.WriteLine("Total amount: " + GetTotalAmountAfterDiscounts() 
                                               + "\tDelivery cost: " + GetDeliveryCost());
        }
    }
}