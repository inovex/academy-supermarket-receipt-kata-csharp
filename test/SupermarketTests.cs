using Moq;
using NUnit.Framework;

namespace Supermarket.Test
{
    public class SupermarketTests
    {
        private Product _apple;
        private Product _toothbrush;
        private readonly double _toothbrushPrice = 0.99;
        private readonly double _applesPrice = 1.99;
        private String _expectedReceipt = "";

        [SetUp]
        public void Setup()
        {
            _apple = new Product("apples", ProductUnit.Kilo);
            _toothbrush = new Product("toothbrush", ProductUnit.Each);
            _expectedReceipt =
                    "apples                              4.97\n" +
                    "  1.99 * 2.500\n" +
                    "toothbrush                          2.97\n" +
                    "  0.99 * 3\n" +
                    "10% off(toothbrush)                -0.30\n" +
                    "\n" +
                    "Total:                              7.65\n";
        }

        [Test]
        public void SystemTest()
        {
            var catalog = new Mock<ISupermarketCatalog>();
            catalog.Setup(x => x.GetUnitPrice(_apple)).Returns(_applesPrice);
            catalog.Setup(x => x.GetUnitPrice(_toothbrush)).Returns(_toothbrushPrice);
            var cart = CreateShoppingCart();
            var teller = CreateTeller(catalog.Object);
            var receipt = teller.ChecksOutArticlesFrom(cart);

            var printer = new ReceiptPrinter();
            var printed = printer.PrintReceipt(receipt);

            Assert.That(_expectedReceipt, Is.EqualTo(printed));
        }

        private ShoppingCart CreateShoppingCart()
        {
            var cart = new ShoppingCart();

            cart.AddItemQuantity(_apple, 2.5);
            cart.AddItemQuantity(_toothbrush, 3);

            return cart;
        }

        private Teller CreateTeller(ISupermarketCatalog catalog)
        {
            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, _toothbrush, 10.0);
            return teller;
        }
    }
}

