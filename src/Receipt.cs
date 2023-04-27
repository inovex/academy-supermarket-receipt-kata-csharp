namespace Supermarket
{
    public class Receipt
    {
        private readonly List<DisC> _discounts = new List<DisC>();
        private readonly List<ReceiptItem> _items = new List<ReceiptItem>();

        public double GetTotalPrice()
        {
            var total = 0.0;
            foreach (var item in _items) total += item.TotalPrice;
            foreach (var discount in _discounts) total += discount.GetA;
            return total;
        }

        public void AddProduct(Product p, double quantity, double price, double totalPrice)
        {
            _items.Add(new ReceiptItem(p, quantity, price, totalPrice));
        }

        public List<ReceiptItem> GetItems()
        {
            return new List<ReceiptItem>(_items);
        }

        public void AddDiscount(DisC discount)
        {
            _discounts.Add(discount);
        }

        public List<DisC> GetDiscounts()
        {
            return _discounts;
        }
    }


}