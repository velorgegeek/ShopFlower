using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class ProductInShoppingCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Внешний ключ на заказ
        public User User { get; set; }
        public ProductVariation ProductVariation { get; set; }

        public int Quantity { get; set; }
        public ProductInShoppingCard(ProductVariation productVariation, int Quatitity)
        {
            this.ProductVariation = productVariation;
            this.Quantity = Quatitity;  
        }
        public ProductInShoppingCard(ProductInSale pr)
        {
            this.ProductVariation = pr.ProductVariation;
            this.Quantity = pr.Quantity;
        }
        public override string ToString()
        {
            return $"{ProductVariation.Product.Name}";
        }
        public ProductInShoppingCard() { }
    }
}
