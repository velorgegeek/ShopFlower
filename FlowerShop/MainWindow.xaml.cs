using DOMAIN.Statistics;
using System.Text;
using System.Windows;
using Data.InMemory;
using Data.Interfaces;
using UI;
using DOMAIN;
using Date.Interfaces;

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUserRepository _userRepository = new UserRepository();
        ISaleRepository _saleRepository = new SaleRepository();
        IProductsRepository _productsRepository = new ProductsRepository();

        User user = new User(0,"da","+7905","mail","hash");

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(IUserRepository us,ISaleRepository Is, IProductsRepository ip)
        {
            InitializeComponent();
            _userRepository = us;
            _saleRepository = Is;
            _productsRepository = ip;
        }

    private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow(_saleRepository);
            statisticsWindow.Show();
        }

        private void data_Click(object sender, RoutedEventArgs e)
        {
            DataGridWindow dataGrid = new DataGridWindow(_productsRepository, _saleRepository);
            dataGrid.Show();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductCatalogWindow productCatalogWindow = new ProductCatalogWindow(_saleRepository, user);
            productCatalogWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductAddWindow productAddWindow = new ProductAddWindow(_productsRepository);
            productAddWindow.Show();
        }
    }
}