using Cart.Type;

namespace Cart
{
    public class Campaign
    {
        private Category _category;
        private double _amount;
        private int _quantity;
        private DiscountType _discountType;

        public Campaign(Category category, double amount, int quantity, DiscountType discountType)
        {
            this._category = category;
            this._amount = amount;
            this._quantity = quantity;
            this._discountType = discountType;
        }

        public Category Category => _category;
        public double Amount => _amount;
        public int Quantity => _quantity;
        public DiscountType DiscountType => _discountType;
    }
}