
using Data.InMemory;
using Date.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
namespace UI
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        IUserRepository repository;
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
            if(UserMail.Text == String.Empty) return false;
            if(FIO.Text == String.Empty) return false;
            return true;
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
            }
            repository.AddUsers(UserMail.Text, FIO.Text, UserPassword.Text, UserPhone.Text, DOMAIN.role.User);
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
    }
}
