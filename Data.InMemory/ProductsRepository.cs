using Data.Interfaces;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemory
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly List<Product> products = new List<Product>();
        public int Id = 0;

        public ProductsRepository()
        {
            products = new List<Product>();
        }
        public Product GetProductsById(int ID)
        {
                return products.FirstOrDefault(i => i.id == ID);

        }
        public bool Update(Product product)
        {

                if (product == null) return false;
                int index = products.IndexOf(product);
                if (index != -1)
                {
                    products[index] = product;
                    return true;
                }
                return false;
        }
        public bool Add(Product product)
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
        public bool Remove(Product product)
        {

                if (product == null) { return false; }

                int index = products.IndexOf(product);
                if (index != -1)
                {
                    products.RemoveAt(index);
                    return true;
                }
                return false;

            }
        public List<Product> GetAll()
        {
            return products;
        }
    }
}
