namespace Cart.Core
{
    public class Product
    {
        private string _title;
        private double _amount;
        private Category _category;

        public Product(string title, double amount, Category category)
        {
            _title = title;
            _amount = amount;
            _category = category;
        }

        public string Title => _title;
        public double Amount => _amount;
        public Category Category => _category;
    }
}