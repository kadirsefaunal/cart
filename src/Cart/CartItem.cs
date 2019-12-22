namespace Cart
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public double TotalDiscount { get; set; }
    }
}