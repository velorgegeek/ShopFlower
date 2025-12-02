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
        User user = new User(0,"da","da","da","hash");
        List<Product> Products;
        ISaleRepository sale;
        public ProductCatalogWindow(ISaleRepository sale,User user)
        {
            
            InitializeComponent();
            this.sale = sale;
            DataContext = Products;
            Products = new List<Product>();

            // Создаем продукты
            Product product1 = new Product("Молоко", "Свежее молоко","da");
            Product product2 = new Product("Хлеб", "Свежий хлеб", "da");

            product1.AddVariation("Молоко 2.5%", System.IO.Path.GetFullPath("Images/maxresdefault (1).jpg"));
            product1.AddVariation("Молоко 3.2%", System.IO.Path.GetFullPath("Images/maxresdefault.jpg"));
            product1.Variations[0].Price = 500;
            product1.Variations[1].Price = 550;
            product2.AddVariation("Хлеб черный", System.IO.Path.GetFullPath("Images/maxresdefault (1).jpg"));
            product2.AddVariation("Хлеб бели", System.IO.Path.GetFullPath("Images/maxresdefault.jpg"));
            product2.Variations[0].Price = 400;
            product2.Variations[1].Price = 5054;

            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product1);
            Products.Add(product2);


            // Устанавливаем контекст данных
            ProductsListBox.ItemsSource = Products;
            DataContext = this;
          

        }

        private void ProductsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProductsListBox.SelectedItem is Product product)
            {
                ProductsListBox.SelectedItem = null;
                ProductCart productCard = new ProductCart(sale,product,user);
                productCard.Show(); 

            }
        }
    } 
}
