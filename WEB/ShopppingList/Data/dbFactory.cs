using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ShopppingList.Data;
using System.IO;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShoppingListDbContext>
{
    public ShoppingListDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ShoppingListDbContext>();
        builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new ShoppingListDbContext(builder.Options);
    }
}
