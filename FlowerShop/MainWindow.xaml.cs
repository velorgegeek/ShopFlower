using DOMAIN.Statistics;
using System.Text;
using System.Windows;
using Data.Interfaces;
using UI;
using DOMAIN;
using Date.Interfaces;
using FlowerShopDB.Data.SqlServer;
using System.Windows.Media;
using Services;
using System.Windows.Media.Animation;

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISaleRepository _saleRepository;
        IProductsRepository _productsRepository;
        ICategoryRepository _categoryRepository;

        User user;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(ISaleRepository Is, IProductsRepository ip,ICategoryRepository category)
        {
            InitializeComponent();
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
            DataGridWindow dataGrid = new DataGridWindow(_productsRepository, _saleRepository, _categoryRepository);
            dataGrid.Show();


        }

    }
}