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
            if (Convert.ToInt16(MonthTextBox.Text) > 12 || Convert.ToInt16(MonthTextBox.Text) < 0) return false;
            return true;

          
        }
        public static bool PaymentWindowShow()
        {
            var app = new PaymentWindow();
            if (app.ShowDialog() == true) return true;
            return false;   
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!valid())
            {
                MessageBox.Show("Валидация не пройдена", "Оплата заказа", MessageBoxButton.OK, MessageBoxImage.Error); 
                return;
            }
                DialogResult = true;
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
