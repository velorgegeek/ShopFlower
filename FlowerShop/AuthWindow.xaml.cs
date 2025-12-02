using Data.InMemory;
using Data.Interfaces;
using Date.Interfaces;
using DOMAIN;
using FlowerShop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        IUserRepository _userRepository = new UserRepository();
        ISaleRepository _sale = new SaleRepository();
        IProductsRepository _products = new ProductsRepository();
        ITransactionRepository _transactionRepository = new TransactionRepository();
        ICategoryRepository _categoryRepository = new CategoryRepository();
        const string regex = @"^\+?[1-9][0-9]{7,14}$";
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void PasswordChecker(object sender, RoutedEventArgs e)
        {
            
            if (PassBox.Visibility == Visibility.Visible)
            {
                PassTextBox.Text = PassBox.Password;
                PassTextBox.Visibility = Visibility.Visible;
                PassBox.Visibility = Visibility.Hidden;
                PassImage.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("Images/passwordShow.png")));
            }
            else
            {
                PassBox.Password = PassTextBox.Text;
                PassTextBox.Visibility = Visibility.Hidden;
                PassBox.Visibility = Visibility.Visible;
                PassImage.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("Images/PasswordClose.png")));
            }

        }
        private string valid()
        {
            string q = "";
            for(int i = 0; i < log.Text.Length; i++)
            {
                if (char.IsDigit(log.Text[i])|| log.Text[i] == '+')
                {
                    q += log.Text[i];
                }
            }
            if (Regex.IsMatch(q, regex))
            {
                return q;
            }
            return string.Empty;
        }
        private void OpenWindow(User user)
        {
            switch (user.Role)
            {
                case role.User:
                    ProductCatalogWindow pr = new ProductCatalogWindow(_sale,user);
                    pr.Show();
                    break;
                case role.Admin:
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    break;
            }
        }
        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            string q = valid();
            if (q != string.Empty)
            {
                OpenWindow(_userRepository.GetByLogin(q, PassBox.Password));
            }
        }
    }
}
