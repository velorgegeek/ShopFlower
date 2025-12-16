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
using static System.Net.Mime.MediaTypeNames;

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

        private bool valid()
        {
            if(MonthTextBox.Text.Length != 2)return false;
            if(YearTextBox.Text.Length != 2)return false;
            if(CvcTextBox.Text.Length != 3) return false;
            if(NumCardTextBox.Text.Length != 16) return false;
            return true;

            //< TextBox x: Name = "MonthTextBox" Text = "ММ" Foreground = "#FF928383" Grid.Column = "1" VerticalContentAlignment = "Center" TextAlignment = "Center" Margin = "0,21,117,5" />
            //       < TextBlock Text = "/" Grid.Column = "1" VerticalAlignment = "Top" Margin = "33,28,112,0" Height = "16" />
            //       < TextBox x: Name = "YearTextBox" Text = "ГГ" Foreground = "#FF928383" Grid.Column = "1" VerticalContentAlignment = "Center" TextAlignment = "Center" Margin = "38,21,79,5" />
            //       < TextBox x: Name = "CvcTextBox" Text = "CVC" Foreground = "#FF928383" Grid.Column = "2" VerticalContentAlignment = "Center" TextAlignment = "Center" Margin = "43,21,0,5" />
        }
        public static bool PaymentWindowShow()
        {
            var app = new PaymentWindow();
            if (app.ShowDialog() == true) return true;
            return false;   
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!valid()) return;
            DialogResult = true;
            Close();
        }
    }
}
