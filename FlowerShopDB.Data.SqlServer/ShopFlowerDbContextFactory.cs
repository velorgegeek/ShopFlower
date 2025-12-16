
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace FlowerShopDB.Data.SqlServer
{
    public class ShopFlowerDbContextFactory : IDesignTimeDbContextFactory<ShopDBContext>
    {
        public ShopDBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.database.json")
            .Build();
            return CreateDbContext(configuration);
        }
        public ShopDBContext CreateDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ShopDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ShopDBContext(optionsBuilder.Options);
        }

    }
}
