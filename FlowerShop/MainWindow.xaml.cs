using DOMAIN.Statistics;
using System.Text;
using System.Windows;
using Data.InMemory;
using Data.Interfaces;
using UI;
using DOMAIN;

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user = new User(0,"da","+7905","mail","hash");
        public MainWindow()
        {
            InitializeComponent();
        }

    private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow(SaleRepository.Instance);
            statisticsWindow.Show();
        }

        private void data_Click(object sender, RoutedEventArgs e)
        {
            //ProductCatalogWindow productCatalogWindow = new ProductCatalogWindow(SaleRepository.Instance, user);
            //productCatalogWindow.Show();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductCatalogWindow productCatalogWindow = new ProductCatalogWindow(SaleRepository.Instance, user);
            productCatalogWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductAddWindow productAddWindow = new ProductAddWindow(ProductsRepository.Instance);
            productAddWindow.Show();
        }
    }
}