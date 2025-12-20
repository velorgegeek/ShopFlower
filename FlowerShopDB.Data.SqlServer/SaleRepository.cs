using Data.Interfaces;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopDB.Data.SqlServer
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ShopDBContext _dbContext;
        public SaleRepository(ShopDBContext context)
        {
            _dbContext = context;
        }
        public List<Sale> GetAll(SaleFilter filter)
        {
            var result = _dbContext.sale.AsQueryable();

            if (filter.StartDate.HasValue)
            {
                result = result.Where(r => r.DateCreate >= filter.StartDate.Value);
            }
            if (filter.EndDate.HasValue)
            {
                result = result.Where(r => r.DateCreate <= filter.EndDate.Value);
            }
            return result.ToList();
        }
        public bool Add(int userid, List<ProductInSale> product)
        {
            if (product == null) return false;
            var sale = new Sale { 
                UserId = userid,
                Products = product
            };
            _dbContext.sale.Add(sale);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
