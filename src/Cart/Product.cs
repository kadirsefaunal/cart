namespace Cart
{
    public class Product
    {
        private string _title;
        private double _amount;
        private Category _category;

        public Product(string title, double amount, Category category)
        {
            this._title = title;
            this._amount = amount;
            this._category = category;
        }

        public string Title => _title;
        public double Amount => _amount;
        public Category Category => _category;
    }
}