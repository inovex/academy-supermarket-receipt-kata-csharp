namespace Supermarket
{
    public interface ISupermarketCatalog
    {
        public void AddProduct(Product product, double price);

        public double GetUnitPrice(Product product);
    }
}