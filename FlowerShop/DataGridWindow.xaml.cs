using Data.Interfaces;
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
    /// Логика взаимодействия для DataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : Window
    {
        IProductsRepository _productsRepository;
        ISaleRepository _saleRepository;
        public DataGridWindow(IProductsRepository _productsRepository,ISaleRepository saleRepository)
        {
            InitializeComponent();
           this._productsRepository = _productsRepository;
            this._saleRepository = saleRepository;
            DataContext = this;
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            SaleDataGrid.ItemsSource = _saleRepository.GetAll(SaleFilter.Empty);
            ProductsDataGrid.ItemsSource = _productsRepository.GetAll();
        }
    }
}
