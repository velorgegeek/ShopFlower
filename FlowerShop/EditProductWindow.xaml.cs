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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для ExitProduct.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        Product product;
        public EditProductWindow(Product product)
        {
            InitializeComponent();
            this.product = product;
            inits();
        }
        private void inits() {
            NameProduct.Text = product.Name;
            DesriptionVar.Text = product.Description;
            PathTextBox.Text = product.MainImagePath;
            CostVariation.Text = product.Variations[0].Price.ToString();
            CategoryComboBox.SelectedItem = product.category;
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
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        public static Product EditProductShow(Product product)
        {
            var show = new EditProductWindow(product);
            if(show.ShowDialog() == true)
            {
                return show.product;
            }
            else
            {
                return null;
            }
        }
        private void var_changed(ProductVariation pf) {
            DesriptionVar.Text = pf.Description;
            PathTextBox.Text = pf.ImagePath;
            CostVariation.Text = pf.Price.ToString();
        }
        private void VariationCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(VariationCombobox.SelectedItem is ProductVariation pr)
            {
                var_changed(pr);
            }
        }
    }
}
