using Data.InMemory;
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
using Data.Interfaces;
using System.Collections.Specialized;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Window
    {
        public ISaleRepository sale;
        private List<ProductInSale> ShopCartList;
        User user1;
        int i = 0;
        bool inCard;
        public void Init()
        {
            ShopCart.ItemsSource = ShopCartList;
            ListSize.Text = ShopCartList.Count.ToString() + " Товара";
            DataContext = ShopCartList;
            AmountPaid.Text = ($"Итого: {CalculateCost()}");
        }
        public ShoppingCart(ISaleRepository SaleRep,List<ProductInSale> product,User user)
        {
            InitializeComponent();
            inCard = false;
            this.user1 = user;
            sale = SaleRep;
            ShopCartList = product;
            Init();

        }
        public ShoppingCart(ISaleRepository SaleRep,User user)
        {
            InitializeComponent();
            inCard = true;
            this.user1 = user;
            sale = SaleRep;
            ShopCartList = new List<ProductInSale>() { };
            for(int i = 0; i < user.ShoppingCard.Count; i++)
            {
                ShopCartList.Add(new ProductInSale(user.ShoppingCard[i]));  
            }
            Init();
        }
        public String CalculateCost()
        {
            i= 0;
            foreach (ProductInSale product in ShopCartList)
            {
                i += product.ProductVariation.Price * product.Quantity;
            }
            return i.ToString();
        }

        public void Paid_Click(object sender, RoutedEventArgs e)
        {
            if (ShopCartList.Count < 1)
            {
                MessageBox.Show($"Нет в корзине товара", "Оплата", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var app = PaymentWindow.PaymentWindowShow();
            if (app == true)
            {
                MessageBox.Show($"Вы оплатили заказ на {CalculateCost()}","Оплата", MessageBoxButton.OK);
                if (inCard == true)
                {
                    sale.AddSale(user1.ID, ShopCartList);
                    //user1.ShopCardDelete(ShopCartList); При удалении удаляется в sale решил закомментировать 
                    //ShopCartList = user1.ShoppingCard; 
                    sale.ToString();
                    ShopCart.Items.Refresh();
                    AmountPaid.Text = ($"Итого: {CalculateCost()}");
                }
                else
                {
                    sale.AddSale(user1.ID, ShopCartList);
                }
            }
            else
            {
                MessageBox.Show($"Произошла ошибка", "Оплата", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ProductInSale productInSale)
            {
                productInSale.Quantity++;
                ShopCart.Items.Refresh();
                AmountPaid.Text = ($"Итого: {CalculateCost()}");
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
                    AmountPaid.Text = ($"Итого: {CalculateCost()}");
                }
            }
        }
        public void DeleteProductInCard_Click(object sender,RoutedEventArgs e)
        {
            if(sender is Button button && button.DataContext is ProductInSale productInSale)
            {
                ShopCartList.Remove(productInSale);
                ShopCart.Items.Refresh();
                AmountPaid.Text = ($"Итого: {CalculateCost()}");
                ListSize.Text = ShopCartList.Count.ToString() + " Товара";
            }
        }
    }
}
