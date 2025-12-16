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

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для AddProductVariationWindow.xaml
    /// </summary>
    public partial class AddProductVariationWindow : Window
    {
        public Product product;
        public AddProductVariationWindow(Product p)
        {
            InitializeComponent();
            product = p;
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
        private bool valid()
        {
            if (PathTextBox.Text == null) return false;
            if (CostVariation.Text == null) return false;
            if (DesriptionVar.Text == null) return false;
            return true;
        }
        public static Product AddVarShow(Product p)
        {
            var Add = new AddProductVariationWindow(p);
            if(Add.ShowDialog() == true)
            {
                return Add.product;
            }
            return null;
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (valid())
            {
                product.AddVariation(DesriptionVar.Text,PathTextBox.Text,Convert.ToInt32(CostVariation.Text));
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Валидация не пройдена","Добавление вариации",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
