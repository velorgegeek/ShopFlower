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
        private readonly List<Sale> _saleList;
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
