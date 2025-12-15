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
        private readonly List<Sale> _saleList = new List<Sale>();
        int countId = 0;
        public SaleRepository() {
            Seed();
        }

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

        private void Seed()
        {
            Product pr = new Product("MOLOKO", new CategoryProduct(1, "Молоко"));
            Product pr2 = new Product("neMoloko", new CategoryProduct(1, "немолоко"));
            List<ProductInSale> productInSales = new List<ProductInSale>();
            List<ProductInSale> productInSales2 = new List<ProductInSale>();
            pr.AddVariation("dada", "netnet",100);
            productInSales.Add(new ProductInSale(pr.Variations[0], 1));
            pr2.AddVariation("DADA", "netene", 100);
            productInSales2.Add(new ProductInSale(pr2.Variations[0], 1));
            var random = new Random();
            for (int i = 0; i < 177; i++)
            {

                if (i % 2 == 0)
                {
                    AddSale(1, productInSales);
                    GetAll(SaleFilter.Empty)[i].DateCreate = DateTime.Now.AddDays(-random.Next(0, 360));
                }
                else
                {
                    AddSale(1, productInSales2);
                    GetAll(SaleFilter.Empty)[i].DateCreate = DateTime.Now.AddDays(-random.Next(0, 360));
                }

            }
        }
    }
}
