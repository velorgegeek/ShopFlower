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
    /// Логика взаимодействия для DeleteVariation.xaml
    /// </summary>
    public partial class DeleteVariation : Window
    {

        public DeleteVariation(Product product)
        {

            InitializeComponent();
            DataContext=product;
        }
        public static ProductVariation DeleteVariationShow(Product product)
        {
            var app = new DeleteVariation(product);
            if (app.ShowDialog() == true)
            {
                if (app.VariationList.SelectedItem is ProductVariation pr)
                {
                    return pr;
                }
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
