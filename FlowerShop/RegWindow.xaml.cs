
using Data.InMemory;
using Date.Interfaces;
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
        public RegWindow(IUserRepository us)
        {
            repository = us;    
            InitializeComponent();
        }
        bool valid()
        {
            if (UserPhone.Text == String.Empty) return false;
            if(UserPassword.Text == String.Empty|| UserPassword.Text.Length <6) return false;
            if(UserMail.Text == String.Empty) return false;
            if(FIO.Text == String.Empty) return false;
            return true;
        }
        void Registration()
        {
            if (!valid())
            {
                MessageBox.Show("Валидация не пройдена","Регистрация",MessageBoxButton.OK, MessageBoxImage.Error);
            }  
        }
    }
}
