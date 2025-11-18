using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class ProductInSale
    {
        public ProductVariation ProductVariation { get; set; }

        public int Quantity { get; set; }
        public ProductInSale(ProductVariation productVariation, int Quatitity)
        {
            this.ProductVariation = productVariation;
            this.Quantity = Quatitity;  
        }
        public override string ToString()
        {
            return $"{ProductVariation.Product.Name}";
        }
    }
}
