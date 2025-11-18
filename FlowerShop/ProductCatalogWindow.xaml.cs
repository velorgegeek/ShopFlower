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

        List<Product> Products;
        public ProductCatalogWindow()
        {
            InitializeComponent();
            DataContext = Products;
            Products = new List<Product>();

            // Создаем продукты
            Product product1 = new Product("Молоко", "Свежее молоко","da");
            Product product2 = new Product("Хлеб", "Свежий хлеб", "da");

            // Добавляем вариации для продуктов
            product1.Variations = new List<ProductVariation>
        {
            new ProductVariation(product1, "Молоко 2.5%", "C:/Users/BEBERISHKA/Downloads/ShopFlower-main/ShopFlower-main/maxresdefault (1).jpg"),
            new ProductVariation(product1, "Молоко 3.2%", "C:/Users/BEBERISHKA/Downloads/ShopFlower-main/ShopFlower-main/maxresdefault.jpg")
        };
            product1.Variations[0].Price = 500;
            product1.Variations[1].Price = 550;

            product2.Variations = new List<ProductVariation>
        {
            new ProductVariation(product2, "Хлеб белый", "C:/Users/BEBERISHKA/Downloads/ShopFlower-main/ShopFlower-main/maxresdefault.jpg"),
            new ProductVariation(product2, "Хлеб черный", "C:/Users/BEBERISHKA/Downloads/ShopFlower-main/ShopFlower-main/maxresdefault (1).jpg")
        };
            product2.Variations[0].Price = 400;
            product2.Variations[1].Price = 5054;


            // Добавляем продукты в коллекцию
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
                ProductCard productCard = new ProductCard(product);
                productCard.Show(); 

            }
        }
    } 
}
