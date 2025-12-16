using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;
using Data.Interfaces;

namespace Data.InMemory
{
    public class CategoryRepository : ICategoryRepository
    {
        List<CategoryProduct> Category { get; set; } = new List<CategoryProduct>()
        {
            new CategoryProduct(1,"Молоко"),
            new CategoryProduct(2,"Хлеб"),
        };
        int Count = 0;

        public bool Add(string category)
        {

            Category.Add(new CategoryProduct(Count++,category));
            return true;
        }
        public List<CategoryProduct> GetAll()
        {
            return Category.ToList();
        }
    }
}
