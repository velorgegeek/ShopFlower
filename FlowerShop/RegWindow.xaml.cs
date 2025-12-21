
using Date.Interfaces;
using FlowerShopDB.Data.SqlServer;
using Microsoft.EntityFrameworkCore.Query;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
namespace UI
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        IUserRepository repository;
        const string regexMail = @"^([a-z0-9_.-]+)@([\da-z.-]+).([a-z.]{2,6})$";
        const string regex = @"^\+?[1-9][0-9]{7,14}$";
        public RegWindow(IUserRepository us)
        {
            repository = us;    
            InitializeComponent();
        }
        bool valid()
        {
            if (UserPhone.Text == String.Empty && ValidNum()) return false;
            if(UserPassword.Text == String.Empty|| UserPassword.Text.Length <6) return false;
            if(FIO.Text == String.Empty) return false;
            return true;
        }
        bool ValidMail()
        {
            if(Regex.IsMatch(UserMail.Text, regexMail)) return true;
            return false;
        }
        bool ValidNum()
        {
            string q = "";
            for (int i = 0; i < UserPhone.Text.Length; i++)
            {
                if (char.IsDigit(UserPhone.Text[i]) || UserPhone.Text[i] == '+')
                {
                    q += UserPhone.Text[i];
                }
            }
            if (Regex.IsMatch(q, regex))
            {
                return true;
            }
            return false;
        }
        void Registration()
        {
            if (!valid())
            {
                MessageBox.Show("Валидация не пройдена","Регистрация",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (repository.CheckNumber(UserPhone.Text) != null)
            {
                MessageBox.Show("Номер занят, попробуйте другой", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (ValidMail())
            {
                repository.Add(UserMail.Text, FIO.Text, UserPassword.Text, UserPhone.Text, DOMAIN.role.User);
            }
            else
            {
                repository.Add(new DOMAIN.User
                {
                    Fio = FIO.Text,
                    HashPassword = UserPassword.Text,
                    Phone = UserPhone.Text,
                    Role = DOMAIN.role.User,
                });
            }
            MessageBox.Show("Регистрация выполнена", "Регистрация");
            Close();
        }
        private void CreateAcc_Click(object sender, RoutedEventArgs e)
        {
            Registration();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Tag as string;
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == textBox.Tag as string)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.DarkGray;
            }
        }
    }
}
