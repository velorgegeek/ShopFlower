using Data.Interfaces;
using DOMAIN;
using FlowerShopDB.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Runtime.Intrinsics.X86;
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
        IProductInShoppingCartRepository _productInShoppingCartRepository;
        public ProductCatalogWindow(ISaleRepository sale,User user, IProductsRepository productsrep, IProductInShoppingCartRepository _productInShoppingCartRepository)
        {
            
            InitializeComponent();
            this.user = user;
            this.sale = sale;
            DataContext = Products;
            Products = productsrep;
            this._productInShoppingCartRepository = _productInShoppingCartRepository;

            // Устанавливаем контекст данных
            ProductsListBox.ItemsSource = Products.GetAll();
            DataContext = this;
          

        }

        private void ProductsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProductsListBox.SelectedItem is Product product)
            {
                ProductsListBox.SelectedItem = null;
                ProductCart productCard = new ProductCart(sale,product,user, Products, _productInShoppingCartRepository);
                productCard.Show();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var productvar = new ShoppingCart(sale, user, Products, _productInShoppingCartRepository);
            productvar.Show();
            Close();
        }
    } 
}
