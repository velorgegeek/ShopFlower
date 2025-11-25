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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {  
        public PaymentWindow()
        {
            InitializeComponent();
        }

        public static bool PaymentWindowShow()
        {
            var app = new PaymentWindow();
            if (app.ShowDialog() == true) return true;
            return false;   
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            
            Close();
        }
    }
}
