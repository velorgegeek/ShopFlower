using FlowerShopDB.Data.SqlServer;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Data.Interfaces;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCart : Window
    {
        Product pr;
        User user1;
        List<RadioButton> radioButtons = new List<RadioButton>();
        ISaleRepository SaleRep;
        IProductsRepository Products;
        IProductInShoppingCartRepository _productInShoppingCartRepository;
        public ProductCart(ISaleRepository SaleRep,Product product,User user, IProductsRepository Products, IProductInShoppingCartRepository _productInShoppingCartRepository)
        {
            InitializeComponent();
            pr = product;
            this.SaleRep = SaleRep;
            user1 = user;
            this.Products = Products;
            this._productInShoppingCartRepository = _productInShoppingCartRepository;   
            DataContext = product;
            ImageProduct.Source = new BitmapImage(new Uri(product.MainImagePath));
            for (int i = 0; i < product.Variations.Count; i++)
            {
                RadioButton radioButton = new RadioButton
                {
                    IsChecked = false,
                    GroupName = "variations",
                    Content = $"{product.Variations[i].Price} ₽.",
                    Margin = new Thickness(0, 5, 0, 5)
                };

                radioButton.Checked += new RoutedEventHandler(RadioButton_Checked);
                radioButtons.Add(radioButton);
                RadioButtonsPanel.Children.Add(radioButton);
            }
            if(radioButtons.Count == 1)
            {
                radioButtons[0].Visibility = Visibility.Hidden;
            }
            CostTextBlock.Text = product.Variations[0].Price.ToString();
            radioButtons[0].IsChecked = true;
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                GoInCard.Visibility = Visibility.Hidden;
                InCardButton.Visibility = Visibility.Visible;
                CostTextBlock.Text = radioButton.Content.ToString();
                int index = radioButtons.IndexOf(radioButton);
                ImageProduct.Source = new BitmapImage(new Uri(pr.Variations[index].ImagePath));
                DescriptionVariation.Text = pr.Variations[index].Description;
            }
        }
        private void AddInCard(object sender, RoutedEventArgs e)
        {
            GoInCard.Visibility = Visibility.Visible;
            InCardButton.Visibility = Visibility.Hidden;
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].IsChecked == true)
                {
                    _productInShoppingCartRepository.Add(user1,pr.Variations[i]);
                    break;
                }
            }
        }
        private void BuyClickCart(object sender, RoutedEventArgs e)
        {
            ShoppingCart shop = new ShoppingCart(SaleRep,user1,Products, _productInShoppingCartRepository);
            shop.Show();
            Close();
        }
        private void BuyClick(object sender, RoutedEventArgs e)
        {
            int i;
            for(i = 0; i < radioButtons.Count; i++)
            {
                if(radioButtons[i].IsChecked == true)
                {
                    break;
                }
            }
            List<ProductInShoppingCart> listPr = new List<ProductInShoppingCart>()
                    {
                        new ProductInShoppingCart(pr.Variations[i], 1),
                    };
            ShoppingCart shop = new ShoppingCart(SaleRep,listPr,user1,Products);
            shop.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var productCatalog = new ProductCatalogWindow(SaleRep,user1, Products, _productInShoppingCartRepository);
            productCatalog.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var productvar = new ShoppingCart(SaleRep, user1, Products, _productInShoppingCartRepository);
            productvar.Show(); 
            Close();
        }
    }
}
