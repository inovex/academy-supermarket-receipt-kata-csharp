/****************************** File Header ******************************\
File Name:    Product.cs
Project:      Supermarket Receipt
Author:       cmenzel

Description:

Copyright (c) inovex GmbH
\***************************************************************************/
namespace Supermarket
{
    /*
     * The class product contains a name and the produc unit.
     */
    public class Product
    {
        /*
        * El constructor obtiene un nombre y la ProductUnit.
        */
        public Product(string n, ProductUnit u)
        {
            GetN = n;
            GetU = u;
        }

        // Returns the name of the product
        public string GetN { get; }

        // Returns the unit of the product
        public ProductUnit GetU { get; }

        // Checks if two Products are equal
        public override bool Equals(object? obj)
        {
            var product = obj as Product;
            return product != null &&
                   GetN == product.GetN &&
                   GetU == product.GetU;
        }

        // Returns the unit of the HashCode of the Product
        public override int GetHashCode()
        {
            return HashCode.Combine(GetN, GetU);
        }
    }




}