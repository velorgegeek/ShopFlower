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
        private static readonly Lazy<ProductsRepository> _products =
            new Lazy<ProductsRepository>(() => new ProductsRepository());
        public static ProductsRepository Instance => _products.Value;
        private readonly List<Product> products = new List<Product>();
        public int Id = 0;
        private readonly object _lock = new object();
        private ProductsRepository()
        {
            products = new List<Product>();
        }
        public Product GetProductsById(int ID)
        {
            lock (_lock)
            {
                return products.FirstOrDefault(i => i.id == ID);
            }
        }
        public bool Update(Product product)
        {
            lock (_lock)
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
        }
        public bool Add(Product product)
        {
            lock (_lock)
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
            }
        public bool Remove(Product product)
        {
            lock (_lock)
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

            }
        }
}
