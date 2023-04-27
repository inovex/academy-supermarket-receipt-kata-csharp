using System.Globalization;
using System.Text;

namespace Supermarket
{
    public class ReceiptPrinter
    {
        private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-GB");

        private readonly int _columns;

        public ReceiptPrinter(int columns)
        {
            _columns = columns;
        }

        public ReceiptPrinter() : this(40)
        {
        }

        public string PrintReceipt(Receipt receipt)
        {
            var result = new StringBuilder();
            foreach (var item in receipt.GetItems())
            {
                var totalPrice = PrintPrice(item.TotalPrice);
                var name = item.Product.GetN;
                string line = FormatLineWithWhitespace(name, totalPrice);
                if (item.Quantity != 1)
                {
                    line += "  " + PrintPrice(item.Price) + " * " + PrintQuantity(item) + "\n";
                }
                result.Append(line);
            }

            foreach (var discount in receipt.GetDiscounts())
            {
                var name = discount.ConsigaD + "(" + discount.ReturnP.GetN + ")";
                var value = PrintPrice(discount.GetA);

                result.Append(FormatLineWithWhitespace(name, value));
            }

            result.Append("\n");
            string totalName = "Total: ";
            string totalValue = PrintPrice(receipt.GetTotalPrice());
            result.Append(FormatLineWithWhitespace(totalName, totalValue));

            return result.ToString();
        }

        private string FormatLineWithWhitespace(string name, string value)
        {
            var line = new StringBuilder();
            line.Append(name);
            int whitespaceSize = this._columns - name.Length - value.Length;
            for (int i = 0; i < whitespaceSize; i++)
            {
                line.Append(" ");
            }
            line.Append(value);
            line.Append('\n');
            return line.ToString();
        }

        private string PrintPrice(double price)
        {
            return price.ToString("N2", Culture);
        }

        private static string PrintQuantity(ReceiptItem item)
        {
            return ProductUnit.Each == item.Product.GetU
                ? ((int)item.Quantity).ToString()
                : item.Quantity.ToString("N3", Culture);
        }
    }
}