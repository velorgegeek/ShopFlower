
using Data.InMemory;
using Data.Interfaces;
using DOMAIN;
using DOMAIN.Statistics;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;
using Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Windows;


namespace UI
{
    /// <summary>
    /// Логика взаимодействия для StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window, INotifyPropertyChanged
    {
        SaleFilter filter = new SaleFilter();
        private readonly IProductsRepository products;
        private readonly ISaleRepository _saleRepository;
        private readonly StatisticsService _statistics;

        private PlotModel? _saleModel;
        private PlotModel? _monthPlotModel;

        public PlotModel? SaleModel
        {
            get => _saleModel;
            set
            {
                _saleModel = value;
                OnPropertyChanged();
            }
        }

        public PlotModel? MonthPlotModel
        {
            get => _monthPlotModel;
            set
            {
                _monthPlotModel = value;
                OnPropertyChanged();
            }
        }

        public StatisticsWindow(ISaleRepository sale)
        {
            InitializeComponent();
            this.DataContext = this;

            _saleRepository = sale;
            _statistics = new StatisticsService(_saleRepository);

            UpdateModel();
        }

        // Реализация интерфейса
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void UpdateModel()
        {
            SaleStatistics(filter);
            LoadMonthChart(filter);
        }
        private void SaleStatistics(SaleFilter filter)
        {
            var data = _statistics.GetSaleByProduct(filter);

            var plotModel = new PlotModel { Title = "Статистика по продуктам" };

            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Title = "Продукты"
            };

            foreach (var item in data)
            {
                categoryAxis.Labels.Add(item.ProductName);
            }
            plotModel.Axes.Add(categoryAxis);


            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Количество продаж",
                MinimumPadding = 0.1,
                MaximumPadding = 0.1,
            });


            var barSeries = new BarSeries
            {
                Title = "Количество продаж",
                FillColor = OxyColor.FromRgb(79, 129, 189)
            };


            foreach (var item in data)
            {
                barSeries.Items.Add(new BarItem { Value = item.Count });
            }
            plotModel.Series.Add(barSeries);

            SaleModel = plotModel;

        }

        private void LoadMonthChart(SaleFilter filter)
        {

            var data = _statistics.GetSaleByMonths(filter);

            var plotModel = new PlotModel { Title = "" };

            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Angle = -15,
                Title = "Месяцы"
            };

            foreach (var item in data)
            {
                categoryAxis.Labels.Add(item.GetMouthName());
            }
            plotModel.Axes.Add(categoryAxis);

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Количество записей",
                MinimumPadding = 0.1,
                MaximumPadding = 0.1
            });

            var lineSeries = new LineSeries
            {
                Title = "Количество записей",
                Color = OxyColor.FromRgb(79, 129, 189),
                MarkerType = MarkerType.Circle, 
                MarkerSize = 4,
                MarkerFill = OxyColor.FromRgb(79, 129, 189)
            };

            for (int i = 0; i < data.Count; i++)
            {
                lineSeries.Points.Add(new DataPoint(i, data[i].Count));
            }
            plotModel.Series.Add(lineSeries);
            MonthPlotModel = plotModel;
        }

        void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {

            filter.StartDate = Datepick.SelectedDate;
            filter.EndDate = DatePickerEnd.SelectedDate;
            UpdateModel();
        }

        void ResetFilterButton_Click(object sender, RoutedEventArgs e)
        {
            filter.StartDate = null;
            filter.EndDate = null;

            Datepick.SelectedDate = null;
            DatePickerEnd.SelectedDate = null;

            UpdateModel();
        }
    }
}

