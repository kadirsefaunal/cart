using System;

namespace Cart.Core
{
    public class Category
    {
        private string _title;
        private Category _parent;

        public Category(string title, Category parent = null)
        {
            _title = title;
            _parent = parent;
        }

        public string Title => _title;
        public Category Parent => _parent;
        
        public override bool Equals(Object obj)
        {
            return (obj is Category) && ((Category)obj).Title == _title;
        }
    }
}