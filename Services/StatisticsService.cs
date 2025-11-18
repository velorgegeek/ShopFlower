using Data.Interfaces;
using DOMAIN;
using DOMAIN.Statistics;

namespace Services
{
    public class StatisticsService
    {
        private readonly ISaleRepository _saleRepository;

        public StatisticsService(ISaleRepository saleRep)
        {
            _saleRepository = saleRep;
        }
        public List<MouthStatistics> GetSaleByMonths(SaleFilter filter)
        {
            var allSales = _saleRepository.GetAll(filter);
            return allSales.GroupBy(r => new { r.DateCreate.Year, r.DateCreate.Month })
                .Select(g => new MouthStatistics
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    count = g.Count()
                }).OrderBy(m => m.Year)
                .ThenBy(m=> m.Month).ToList();
        }
        public List<ProductStaticsItem> GetSaleByProduct(SaleFilter filter)
        {
            var allSales = _saleRepository.GetAll(filter);

            return allSales
                .SelectMany(sale =>
                    sale.Products
                        .Select(productInSale =>
                            (Sale: sale, Product: productInSale.ProductVariation!.Product)
                        )
                )
                .GroupBy(x => x.Product)
                .Select(g => new ProductStaticsItem
                {
                    ProductName = g.Key.Name,
                    Count = g.Count()
                }).OrderByDescending(m=>m.Count)
                .ToList();
        }
    }

}
