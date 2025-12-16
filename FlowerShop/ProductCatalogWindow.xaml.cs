using Data.InMemory;
using Data.Interfaces;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing.IndexedProperties;
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
    /// Логика взаимодействия для ProductCatalogWindow.xaml
    /// </summary>
    public partial class ProductCatalogWindow : Window
    {
        User user;
        IProductsRepository Products;
        ISaleRepository sale;
        public ProductCatalogWindow(ISaleRepository sale,User user, IProductsRepository productsrep)
        {
            
            InitializeComponent();
            this.user = user;
            this.sale = sale;
            DataContext = Products;
            Products = productsrep;


            // Устанавливаем контекст данных
            ProductsListBox.ItemsSource = Products.GetAll();
            DataContext = this;
          

        }

        private void ProductsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProductsListBox.SelectedItem is Product product)
            {
                ProductsListBox.SelectedItem = null;
                ProductCart productCard = new ProductCart(sale,product,user, Products);
                productCard.Show();
                Close();
            }
        }
    } 
}
