using Data.Interfaces;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemory
{
    public class SaleRepository : ISaleRepository
    {
        private static readonly Lazy<SaleRepository> _instance =
            new Lazy<SaleRepository>(() => new SaleRepository());
        public static SaleRepository Instance = _instance.Value;
        private readonly List<Sale> _saleList = new List<Sale>();
        int countId = 0;
        private SaleRepository() { }
        public bool AddSale(int userId,List<ProductInSale> product)
        {
            if (product == null) return false;
            countId++;
            _saleList.Add(new Sale(userId,countId, product));
            return true;
        }
        public List<Sale> GetAll(SaleFilter filter)
        {
            var result = _saleList.AsEnumerable();
 
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
    }
}
