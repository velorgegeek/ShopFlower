using Data.Interfaces;
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
    /// Логика взаимодействия для DataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : Window
    {
        IProductsRepository _productsRepository;
        ISaleRepository _saleRepository;
        IPaymentsRepository _paymentsRepository;
        ICategoryRepository _categoryRepository;
        public DataGridWindow(IProductsRepository _productsRepository, ISaleRepository saleRepository, IPaymentsRepository payments,ICategoryRepository _categoryRepository)
        {
            InitializeComponent();
            this._productsRepository = _productsRepository;
            this._saleRepository = saleRepository;
            _paymentsRepository = payments;
            this._categoryRepository = _categoryRepository;
            DataContext = this;
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            SaleDataGrid.ItemsSource = _saleRepository.GetAll(SaleFilter.Empty);
            ProductsDataGrid.ItemsSource = _productsRepository.GetAll();
        }
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product pr)
            {
                var edit = EditProductWindow.EditProductShow(pr);
                if (edit != null)
                {
                    _productsRepository.Update(edit);
                    MessageBox.Show("Продукт отредактирован", "Редактирование продукта", MessageBoxButton.OK);
                    return;
                }
                MessageBox.Show("Продукт вернул null", "Редактирование продукта", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Продукт для редактирования не выбран", "Редактирование продукта", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var add = ProductAddWindow.ProductAddWindowShow(_categoryRepository);
                if(add != null)
                {
                    _productsRepository.Add(add);
                    UpdateDataGrid();
                }
                else
                {
                    MessageBox.Show("Ошибка,вернулся null ", "Добавление продукта", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
