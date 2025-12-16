using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    public class ProductVariation
    {
        public Product Product { get; set; }
        public Guid id { get; set; } = Guid.NewGuid();
        public int Index { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public ProductVariation(Product product, string description,string ImagePath)
        {
            this.Product = product;
            this.Description = description;
            this.ImagePath = ImagePath;
        }
        public ProductVariation(Product product, string description, string ImagePath,int price)
        {
            this.Product = product;
            this.Description = description;
            this.ImagePath = ImagePath;
            this.Price = price;
        }
        public ProductVariation() { }
    }
}