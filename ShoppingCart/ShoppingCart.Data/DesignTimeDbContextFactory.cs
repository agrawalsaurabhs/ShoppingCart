using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ShoppingCart.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShoppingDbContext>
    {
        private readonly IConfiguration _configuration;

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DesignTimeDbContextFactory()
        {
            
        }
        public ShoppingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ShoppingDbContext>();
            var connectionString =
                "Server=.;Database=ShoppingCart;Trusted_Connection=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString);
            return new ShoppingDbContext(builder.Options);
        }
    }
}
