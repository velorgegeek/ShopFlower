
using Date.Interfaces;
using System.Windows;
using Data.InMemory;
namespace UI
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        List<IUserRepository> tq = new();
        public RegWindow()
        {
            InitializeComponent();
        }
        void Registration()
        {
            //tq.GetByLogin(t,q);
        }
    }
}
