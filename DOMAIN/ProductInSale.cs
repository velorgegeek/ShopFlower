using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class ProductInSale
    {
        public int Id { get; set; }
        public int SaleId { get; set; }  
        public Sale Sale { get; set; }

        public ProductVariation ProductVariation { get; set; }

        public int Quantity { get; set; }
        public int TotalPrice => ProductVariation?.Price * Quantity ?? 0;
        public ProductInSale(ProductVariation productVariation, int Quatitity)
        {
            this.ProductVariation = productVariation;
            this.Quantity = Quatitity;  
        }
        public ProductInSale(ProductInShoppingCard productInShoppingCard)
        {
            this.ProductVariation = productInShoppingCard.ProductVariation;
            this.Quantity = productInShoppingCard.Quantity;
        }
        public override string ToString()
        {
            return $"{ProductVariation.Product.Name}";
        }
        public ProductInSale() { }
    }
}
