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
        private void close_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно уверены,что хотите закрыть, данные не сохранятся"
                , "Добавление продукта", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Close();
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
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Tag as string;
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == textBox.Tag as string)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.DarkGray;
            }
        }
    }
}
