
using Data.InMemory;
using Data.Interfaces;
using DOMAIN;
using DOMAIN.Statistics;
using Services;
using System.Windows;


namespace UI
{
    /// <summary>
    /// Логика взаимодействия для StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        Product product;
        SaleFilter filter = new SaleFilter();
        ProductVariation invar;
        private readonly ISaleRepository _saleRepository;
        private readonly StatisticsService _statistics;
        public StatisticsWindow()
        {
            InitializeComponent();
            product = new Product("moloko", "kislimolochka", "da");
            _saleRepository = new SaleRepository();
            invar = new ProductVariation(product, "molokooo oda", "images/city.jpg");
            List<ProductVariation> variations = new List<ProductVariation>();
            variations.Add(invar);
            product.Variations = variations;
            List<ProductInSale>  productInSales = new List<ProductInSale>();
            productInSales.Add(new ProductInSale(invar, 1));
            _saleRepository.AddSale(productInSales);
            _statistics = new StatisticsService(_saleRepository);
        }

        void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            filter.StartDate= Datepick.DisplayDate;
            filter.EndDate= DatePickerEnd.DisplayDate;
            _statistics.GetSaleByMonths(filter);


        }
        void ResetFilterButton_Click(Object sender, RoutedEventArgs e)
        {
            filter.StartDate = null;
            filter.EndDate = null;
        }
    }
}
