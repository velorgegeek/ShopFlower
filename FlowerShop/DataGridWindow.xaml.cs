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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для DataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : Window
    {
        IProductsRepository _productsRepository;
        ISaleRepository _saleRepository;

        ICategoryRepository _categoryRepository;
        public DataGridWindow(IProductsRepository _productsRepository, ISaleRepository saleRepository, ICategoryRepository _categoryRepository)
        {
            InitializeComponent();
            this._productsRepository = _productsRepository;
            this._saleRepository = saleRepository;

            this._categoryRepository = _categoryRepository;
            DataContext = this;
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            SaleDataGrid.ItemsSource = null;
            ProductsDataGrid.ItemsSource = null;

            // Затем очистить Items (теперь это разрешено)
            SaleDataGrid.Items.Clear();
            ProductsDataGrid.Items.Clear();
            SaleDataGrid.ItemsSource = _saleRepository.GetAll(SaleFilter.Empty);
            ProductsDataGrid.ItemsSource = _productsRepository.GetAll();


        }
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product pr)
            {
                var edit = EditProductWindow.EditProductShow(pr, _categoryRepository);
                if (edit != null)
                {
                    _productsRepository.Update(edit);
                    MessageBox.Show("Продукт отредактирован", "Редактирование продукта", MessageBoxButton.OK);
                    UpdateDataGrid();
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
            if (add != null)
            {
                _productsRepository.Add(add);
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Ошибка,вернулся null ", "Добавление продукта", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddVariation_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product pr)
            {
                var add = AddProductVariationWindow.AddVarShow(pr);
                if (add != null)
                {
                    MessageBox.Show("Вариация добавлена", "Добавление вариации");
                }
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product pr)
            {
                if (_productsRepository.Remove(pr))
                {
                    MessageBox.Show("Удаление завершено успешно", "Удаление");
                }
                else
                {
                    MessageBox.Show("Удаление завершено с ошибкой", "Удаление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Продукт не выбран", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void DeleteVariation_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product pr)
            {
                var app = DeleteVariation.DeleteVariationShow(pr);
                if (app != null)
                {
                    pr.DeleteVariation(app);
                    MessageBox.Show("Вариация удалена", "Удаление вариации");
                    UpdateDataGrid();
                }
                else
                {
                    MessageBox.Show("Вариация не удалена","Удаление вариации",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
        }

    }
}
