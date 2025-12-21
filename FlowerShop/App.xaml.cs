using FlowerShopDB.Data.SqlServer;
using Data.Interfaces;
using Date.Interfaces;
using DOMAIN;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using UI;

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       private IUserRepository _userRepository = null!;
        private ISaleRepository _sale = null!;
        private IProductsRepository _products = null!;
        private ICategoryRepository _categoryRepository = null!;
        private StatisticsService _statistics = null!;
        private ShopDBContext _shopDBContext = null!;
        private IProductInShoppingCartRepository _productInShoppingCartRepository = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1. Чтение конфигурации из файла
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.database.json")
            .Build();

            // 2. Создание DbContext через фабрику
            var factory = new ShopFlowerDbContextFactory();
            _shopDBContext = factory.CreateDbContext(configuration);

            // 3. ВАЖНО: Применение миграций автоматически при запуске

            _shopDBContext.Database.Migrate();
            // 4. Создание репозиториев на основе DbContext

            _categoryRepository = new FlowerShopDB.Data.SqlServer.CategoryRepository(_shopDBContext);
            _userRepository = new FlowerShopDB.Data.SqlServer.UserRepository(_shopDBContext);
            _products = new FlowerShopDB.Data.SqlServer.ProductsRepository(_shopDBContext);
            _productInShoppingCartRepository = new FlowerShopDB.Data.SqlServer.ProductInShoppingCartRepository(_shopDBContext);
            _sale = new FlowerShopDB.Data.SqlServer.SaleRepository(_shopDBContext);
            _statistics = new StatisticsService(_sale);
            Inits();
            _products.GetAll();
            _sale.GetAll(SaleFilter.Empty);
            // 6. Запуск главного окна
            var mainWindow = new AuthWindow(_userRepository,_sale,_products,_categoryRepository, _productInShoppingCartRepository);
            mainWindow.Show();
        }
        public static string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }
        private void Inits()
        {
            if (_userRepository.GetAll().Any() ||
            _categoryRepository.GetAll().Any() ||
            _products.GetAll().Any() || _sale.GetAll(SaleFilter.Empty).Any())
            {
                return;
            }
            User user1 = new User
            {
                Fio = "Медведев Егор Евгеньевич",
                Phone = "+79050944341",
                Mail = "da@mail.ru",
                HashPassword = CreateSHA256("da")
                ,
                Role = role.User,
                ShoppingCart = new List<ProductInShoppingCart>()
            };
            var user2 = new User
            {
                Fio = "Иванов Кирилл",
                Phone = "+79040944341",
                HashPassword = CreateSHA256("yakirill"),
                Role = role.Admin,
                ShoppingCart = new List<ProductInShoppingCart>()
            };

            _userRepository.Add(user2);
            _userRepository.Add(user1);

            _shopDBContext.SaveChanges();

            CategoryProduct buket = new CategoryProduct { Name = "Зимний букет" };
            CategoryProduct buket2 = new CategoryProduct { Name = "Богатый букет" };
            CategoryProduct buketByPiece = new CategoryProduct { Name = "Букеты поштучно" };
            _categoryRepository.Add(buket);
            _categoryRepository.Add(buket2);
            _shopDBContext.SaveChanges();

            Product product = new Product("Полярная экспедиция", buket);
            Product product2 = new Product("Лед и пламя", buket2);
            Product product3 = new Product("Букет роз 'Сладость'".Replace("'", "\""), buketByPiece);
            product3.AddVariation("'Сладость', 15 роз".Replace("'", "\""), System.IO.Path.GetFullPath("Images/sladost15.jpg"), 1500);
            product3.AddVariation("'Сладость', 30 роз".Replace("'", "\""), System.IO.Path.GetFullPath("Images/sladost30.jpg"), 2500);
            product3.AddVariation("'Сладость', 101 роза".Replace("'", "\""), System.IO.Path.GetFullPath("Images/sladost100.jpg"), 15000);
            product.AddVariation("Полярная звезда", System.IO.Path.GetFullPath("Images/PolyarnayaZvezda.jpg"), 500);
            product.AddVariation("Сиреневая зависимость", System.IO.Path.GetFullPath("Images/da.jpg"), 550);

            product2.AddVariation("Лед и пламя", System.IO.Path.GetFullPath("Images/ledIplamya.jpg"), 800);
            product2.AddVariation("Очень богатый букет", System.IO.Path.GetFullPath("Images/5f47bf7abc2d90f1db3555c16b78fc67.jpg"), 5054);

            _products.Add(product);
            _products.Add(product2);
            _products.Add(product3);
            _shopDBContext.SaveChanges();



            var random = new Random();



            for (int i = 0; i < 25; i++)
            {

                if (i % 2 == 0)
                {
                    List<ProductInSale> productInSales = new List<ProductInSale>();


                    productInSales.Add(new ProductInSale(product.Variations[0], random.Next(1, 5)));
                    productInSales.Add(new ProductInSale(product2.Variations[1], random.Next(1, 2)));
                    _sale.Add(1, productInSales);
                    _sale.GetAll(SaleFilter.Empty)[i].DateCreate = DateTime.Now.AddDays(-random.Next(0, 360));
                }
                else
                {
                    if(random.Next(5) == 0)
                    {
                        List<ProductInSale> productInSales3 = new List<ProductInSale>();
                        productInSales3.Add(new ProductInSale(product3.Variations[0], random.Next(1, 5)));
                        productInSales3.Add(new ProductInSale(product3.Variations[1], random.Next(1, 2)));
                        if (random.Next(2) == 0)
                        {
                            productInSales3.Add(new ProductInSale(product3.Variations[2], random.Next(1, 2)));
                        }
                        _sale.Add(1, productInSales3);
                        _sale.GetAll(SaleFilter.Empty)[i].DateCreate = DateTime.Now.AddDays(-random.Next(0, 360));
                    }
                    else
                    {
                        List<ProductInSale> productInSales2 = new List<ProductInSale>();
                        productInSales2.Add(new ProductInSale(product.Variations[1], random.Next(1, 5)));
                        productInSales2.Add(new ProductInSale(product2.Variations[0], random.Next(1, 5)));
                        _sale.Add(2, productInSales2);
                        _sale.GetAll(SaleFilter.Empty)[i].DateCreate = DateTime.Now.AddDays(-random.Next(0, 360));
                    }
                }

            }
            _shopDBContext.SaveChanges();

        }
        protected override void OnExit(ExitEventArgs e)
        {
            _shopDBContext?.Dispose();
            base.OnExit(e);
        }
    }
}
