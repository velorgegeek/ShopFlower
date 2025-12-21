using Data.Interfaces;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopDB.Data.SqlServer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDBContext _dbContext;
        public CategoryRepository(ShopDBContext context)
        {
            _dbContext = context;
        }
        public bool Add(CategoryProduct category)
        {
            if(category == null) { return false; }
            if (_dbContext.categories.FirstOrDefault(i => i.Name == category.Name) != null) return false;
            _dbContext.categories.Add(category);
            return true;
            }
        public bool Add(string category)
        {
            var tmp = new CategoryProduct
            {
                Name = category,
            };
            _dbContext.Add(tmp);
            _dbContext.SaveChanges();
            return true;
        }
        public List<CategoryProduct> GetAll()
        {
            return _dbContext.categories.ToList();  
        }
    }
}
