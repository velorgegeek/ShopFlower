using DOMAIN.Statistics;
using System.Text;
using System.Windows;
using Data.InMemory;
using Data.Interfaces;
using UI;
using DOMAIN;
using Date.Interfaces;
using System.Windows.Media;

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
        ICategoryRepository _categoryRepository = new CategoryRepository();
        User user;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(User user,ISaleRepository Is, IProductsRepository ip,ICategoryRepository category )
        {
            InitializeComponent();
            this.user = user;   
            _saleRepository = Is;
            _productsRepository = ip;
            _categoryRepository = category;
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
            //AuthWindow auth = new AuthWindow();
            //auth.Show();
            DataGridWindow dataGrid = new DataGridWindow(_productsRepository, _saleRepository, _categoryRepository);
            dataGrid.Show();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductCatalogWindow productCatalogWindow = new ProductCatalogWindow(_saleRepository, user, _productsRepository);
            productCatalogWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            auth.Show();
        }
    }
}