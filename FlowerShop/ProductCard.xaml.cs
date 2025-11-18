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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCard : Window
    {
        Product pr;
        User user1;
        List<RadioButton> radioButtons = new List<RadioButton>();
        int h = 150;
        public ProductCard(Product product)
        {
            InitializeComponent();
            pr = product;
            DataContext = product;
            ImageProduct.Source = new BitmapImage(new Uri(product.MainImagePath));
            for (int i = 0; i < product.Variations.Count; i++)
            {
                RadioButton radioButton = new RadioButton
                {
                    IsChecked = false,
                    GroupName = "variations",
                    Content = $"{product.Variations[i].Price} руб.",
                    Margin = new Thickness(0, 5, 0, 5)
                };
                radioButton.Checked += new RoutedEventHandler(RadioButton_Checked);
                radioButtons.Add(radioButton);
                RadioButtonsPanel.Children.Add(radioButton);
            }
            CostTextBlock.Text = product.Variations[0].Price.ToString();
            radioButtons[0].IsChecked = true;
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                CostTextBlock.Text = radioButton.Content.ToString();
                int index = radioButtons.IndexOf(radioButton);
                ImageProduct.Source = new BitmapImage(new Uri(pr.Variations[index].ImagePath));
            }
        }
        private void BuyClickCart(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].IsChecked == true)
                {
                    user1.ShoppingCard.Add(new ProductInSale(pr.Variations[i], 1));
                    break;
                }
            }
            ShoppingCart shop = new ShoppingCart(user1.ShoppingCard);
            shop.Show();
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
            List<ProductInSale> listPr = new List<ProductInSale>()
                    {
                        new ProductInSale(pr.Variations[i], 1),
                        new ProductInSale(pr.Variations[1], 1),
                        new ProductInSale(pr.Variations[i], 1),
                        new ProductInSale(pr.Variations[1], 1),
                        new ProductInSale(pr.Variations[i], 1),
                        new ProductInSale(pr.Variations[1], 1),
                    };
            ShoppingCart shop = new ShoppingCart(listPr);
            shop.Show();
        }
    }
}
