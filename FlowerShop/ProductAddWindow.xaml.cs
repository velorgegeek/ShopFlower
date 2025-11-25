using Data.Interfaces;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Data.InMemory;
namespace UI
{
    /// <summary>
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        IProductsRepository productsRepository;
        ICategoryRepository categoryRepository = new CategoryRepository();
        public ProductAddWindow(IProductsRepository pr)
        {
            InitializeComponent();
            productsRepository = pr;
            CategoryComboBox.ItemsSource = categoryRepository.GetAll();
        }
        private void path_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            bool? result = dialog.ShowDialog();
            if (result != null)
            {
                PathTextBox.Text = dialog.FileName;
            }
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //Product product = new Product()
            //productsRepository.Add()
        }


    }
}
