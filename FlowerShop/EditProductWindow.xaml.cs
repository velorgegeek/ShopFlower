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
        ICategoryRepository categoryRepository;
        public EditProductWindow(Product product, ICategoryRepository _categoryRepository)
        {
            InitializeComponent();
            this.product = product;
            this.categoryRepository = _categoryRepository;
            VariationList.ItemsSource = product.Variations;
            CategoryComboBox.ItemsSource = categoryRepository.GetAll();
            inits();
        }
        private void inits() {
            NameProduct.Text = product.Name;
            DesriptionVar.Text = product.Description;
            PathTextBox.Text = product.MainImagePath;
            CostVariation.Text = product.Variations[0].Price.ToString();
            VariationList.SelectedItem = product.Variations[0];
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
        private bool valid()
        {
            if (VariationList.SelectedItem == null) return false;
            if(CategoryComboBox.SelectedItem == null) return false;
            if (PathTextBox.Text == null) return false;
            if (CostVariation.Text == null)return false;
            if (NameProduct.Text == null) return false;
            if (DesriptionVar.Text == null) return false;
            return true;
        }
        private void EditProduct_Click(object sender, RoutedEventArgs e)

        {
            if (!valid()) return;

            product.Name = NameProduct.Text;
            if (CategoryComboBox.SelectedItem is CategoryProduct c)
            {
                product.category = c;
            }
            product.Variations[VariationList.SelectedIndex].ImagePath = PathTextBox.Text;

            product.Variations[VariationList.SelectedIndex].Description = DesriptionVar.Text;
            product.Variations[VariationList.SelectedIndex].Price = Convert.ToInt32(CostVariation.Text);
            DialogResult = true;
            Close();
        }
        public static Product EditProductShow(Product product,ICategoryRepository _categoryRepository)
        {
            var show = new EditProductWindow(product, _categoryRepository);
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
        private void ListVariation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(VariationList.SelectedItem is ProductVariation pr)
            {
                var_changed(pr);
            }
        }
    }
}
