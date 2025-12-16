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
        private List<ProductInShoppingCard> ShopCartList;
        User user1;
        int i = 0;
        bool inCard;
        IProductsRepository products;
        public void Init()
        {
            ShopCart.ItemsSource = ShopCartList;
            ListSize.Text = ShopCartList.Count.ToString() + " Товара";
            DataContext = ShopCartList;
            AmountPaid.Text = ($"Итого: {CalculateCost()}");
        }
        public ShoppingCart(ISaleRepository SaleRep,List<ProductInShoppingCard> product,User user,IProductsRepository products)
        {
            InitializeComponent();
            inCard = false;
            this.user1 = user;
            sale = SaleRep;
            ShopCartList = product;
            this.products = products;
            Init();

        }
        public ShoppingCart(ISaleRepository SaleRep,User user, IProductsRepository products)
        {
            InitializeComponent();
            inCard = true;
            this.user1 = user;
            sale = SaleRep;
            this.products = products;
            ShopCartList =user.ShoppingCard;
            Init();
        }
        public String CalculateCost()
        {
            i= 0;
            foreach (ProductInShoppingCard product in ShopCartList)
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
                    sale.AddSale(user1.ID, ShopCartList.Select(
                        item => new ProductInSale(item.ProductVariation, item.Quantity)).ToList());
                    user1.ShopCardDelete(ShopCartList);
                    ShopCartList = user1.ShoppingCard;
                    ShopCart.Items.Refresh();
                    AmountPaid.Text = ($"Итого: {CalculateCost()}");
                }
                else
                {

                    sale.AddSale(user1.ID, ShopCartList.Select(
                    item => new ProductInSale(item.ProductVariation, item.Quantity)).ToList());
                    ShopCartList.Clear();
                    AmountPaid.Text = ($"Итого: {CalculateCost()}");
                    ListSize.Text = ShopCartList.Count.ToString() + " Товара";
                    ShopCart.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show($"Произошла ошибка", "Оплата", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ProductInShoppingCard productInSale)
            {
                productInSale.Quantity++;
                ShopCart.Items.Refresh();
                AmountPaid.Text = ($"Итого: {CalculateCost()}");
            }
        }
        public void DecreaseQuantity_Click(Object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ProductInShoppingCard productInSale)
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
            if(sender is Button button && button.DataContext is ProductInShoppingCard productInShoppingCart)
            {
                ShopCartList.Remove(productInShoppingCart);
                ShopCart.Items.Refresh();
                AmountPaid.Text = ($"Итого: {CalculateCost()}");
                ListSize.Text = ShopCartList.Count.ToString() + " Товара";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var productcatalog = new ProductCatalogWindow(sale, user1, products);
            productcatalog.Show();
            Close();
        }
    }
}
