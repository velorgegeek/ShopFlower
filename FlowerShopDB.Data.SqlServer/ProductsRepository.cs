using Data.Interfaces;
using DOMAIN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopDB.Data.SqlServer
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ShopDBContext _dbContext;
        public ProductsRepository(ShopDBContext context)
        {
            _dbContext = context;
        }
        public Product GetProductsById(Guid ID)
        {
            return _dbContext.Products.FirstOrDefault(i => i.id == ID);
        }
        public bool Update(Product product)
        {
            if(product == null) return false;
            _dbContext.Entry(product).CurrentValues.SetValues(product);
            _dbContext.SaveChanges();
            return true;

        }
        public bool Add(Product product)
        {
            if(product == null) return false;
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Remove(Product product)
        {
            if( product == null) return false;
            _dbContext.Products.Remove(product);    
            _dbContext.SaveChanges();
            return true;
        }
        public List<Product> GetAll()
        {
            return _dbContext.Products
            .Include(p => p.Variations)
            .Include(p => p.category)
            .ToList();
        }
    }
}
