using DOMAIN;
using Microsoft.EntityFrameworkCore;
using System;
namespace FlowerShopDB.Data.SqlServer
{
    public class ShopDBContext : DbContext  
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {
        }

        public ShopDBContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInSale> productInSales { get; set; }
        public DbSet<ProductInShoppingCart> productInShoppingCards { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Sale > sale { get; set; }
        public DbSet<CategoryProduct> categories { get; set; }
    }

}
