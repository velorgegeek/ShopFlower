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
    /// Логика взаимодействия для ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Window
    {
        private List<ProductInSale> ShopCartList;
        int i = 0;
        public ShoppingCart(List<ProductInSale> product)
        {
            InitializeComponent();
            ShopCartList = new List<ProductInSale>(product);
            ShopCart.ItemsSource = ShopCartList;
            ListSize.Text = ShopCartList.Count.ToString() + " Товара";
            DataContext = ShopCartList;
            CalculateCost();
        }
        public void CalculateCost()
        {
            i= 0;
            foreach (ProductInSale product in ShopCartList)
            {
                i += product.ProductVariation.Price * product.Quantity;
            }
            AmountPaid.Text = $"Итого: {i}";
        }

        public void Paid_Click(object sender, RoutedEventArgs e)
        {
            PaymentWindow pay = new PaymentWindow();
            pay.Show();
        }
        public void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ProductInSale productInSale)
            {
                productInSale.Quantity++;
                ShopCart.Items.Refresh();
                CalculateCost();
            }
        }
        public void DecreaseQuantity_Click(Object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ProductInSale productInSale)
            {
                if (productInSale.Quantity > 1)
                {
                    productInSale.Quantity--;
                    ShopCart.Items.Refresh();
                    CalculateCost();
                }
            }
        }
    }
}
