using Data.Interfaces;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemory
{
    public class ProductsRepository : IProductsRepository
    {
        List<Product> products { get; set; } = new List<Product>();
        public int Id = 0;
        public Product GetProductsById(int id)
        {
            return products[0];
        }
        public bool ProductUpdate(Product product)
        {
            return true;
        }
        public bool ProductAdd(Product product)
        {
            if (product == null)
            {
                return false;
            }
            Id++;
            product.id = Id;
            products.Add(product);
            return true;
        }
        public bool ProductRemove(Product product)
        {
            if (product == null) { return false; }

            return products.Remove(product);
        }

    }
}
