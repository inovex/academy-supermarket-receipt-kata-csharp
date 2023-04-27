namespace Supermarket
{
    public class PQ
    {
        public PQ(Product p, double weight)
        {
            P = p;
            Q = weight;
        }

        public Product P { get; }
        public double Q { get; }
    }
}