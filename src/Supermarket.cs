namespace Supermarket
{
    public class Supermarket
    {

        public static void Main(String[] args)
        {
            var apple = new Product("apples", ProductUnit.Kilo);
            var toothbrush = new Product("toothbrush", ProductUnit.Each);

            ISupermarketCatalog catalog = null;
            // TODO: catalog needs to be initialized

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, toothbrush, 10.0);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(apple, 2.5);
            cart.AddItemQuantity(toothbrush, 3);

            var receipt = teller.ChecksOutArticlesFrom(cart);

            var printer = new ReceiptPrinter();
            var printed = printer.PrintReceipt(receipt);

            Console.WriteLine(printed);
        }
    }
}
