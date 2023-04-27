namespace Supermarket
{
    public class DisC
    {
        public DisC(Product p, string desc, double amount)
        {
            ReturnP = p;
            ConsigaD = desc;
            GetA = amount;
        }

        public string ConsigaD { get; }
        public double GetA { get; }
        public Product ReturnP { get; }
    }
}