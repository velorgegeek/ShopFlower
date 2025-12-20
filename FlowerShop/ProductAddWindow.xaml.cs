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
using FlowerShopDB.Data.SqlServer;
namespace UI
{
    /// <summary>
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        ICategoryRepository categoryRepository;
        Product product;
        public ProductAddWindow(ICategoryRepository category)
        {
            InitializeComponent();
            categoryRepository = category;
            CategoryComboBox.ItemsSource = categoryRepository.GetAll();
        }
        bool valid()
        {
            if (NameProduct.Text == string.Empty) return false;
            if(CategoryComboBox.SelectedItem == null) return false;
            if(PathTextBox.Text == string.Empty) return false;
            if(DesriptionVar.Text == string.Empty) return false;
            if(CostVariation.Text == string.Empty) return false;
            return true;
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
            if (!valid())
            {
                MessageBox.Show("Данные не валидные", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (CategoryComboBox.SelectedItem is CategoryProduct catproduct)
            {
                product = new Product(NameProduct.Text, catproduct);
                product.AddVariation(DesriptionVar.Text, PathTextBox.Text ,Convert.ToUInt16(CostVariation.Text));
                DialogResult = true;
                Close();
            }
        }
        public static Product ProductAddWindowShow(ICategoryRepository category)
        {
            var app = new ProductAddWindow(category);
            if (app.ShowDialog() == true) return app.product;
            return null;
        }
    }
}
