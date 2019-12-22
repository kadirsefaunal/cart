namespace Cart
{
    public class Category
    {
        private string _title;
        private Category _parent;

        public Category(string title, Category parent = null)
        {
            this._title = title;
            this._parent = parent;
        }

        public string Title => _title;
        public Category Parent => _parent;
    }
}