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

        private void seed()
        {
            Product product1 = new Product("Молоко", "Свежее молоко");
            Product product2 = new Product("Хлеб", "Свежий хлеб");

            product1.AddVariation("Молоко 2.5%", System.IO.Path.GetFullPath("Images/maxresdefault (1).jpg"),500);
            product1.AddVariation("Молоко 3.2%", System.IO.Path.GetFullPath("Images/maxresdefault.jpg"), 550);
            product1.Variations[0].Price = 500;
            product1.Variations[1].Price = 550;
            product2.AddVariation("Хлеб черный", System.IO.Path.GetFullPath("Images/maxresdefault (1).jpg"),400);
            product2.AddVariation("Хлеб бели", System.IO.Path.GetFullPath("Images/maxresdefault.jpg"),5054);
            product2.Variations[0].Price = 400;
            product2.Variations[1].Price = 5054;

            products.Add(product1);
            products.Add(product2);

        }
        public ProductsRepository()
        {
            seed();
        }
        public Product GetProductsById(Guid ID)
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
            return products.ToList();
        }
    }
}
