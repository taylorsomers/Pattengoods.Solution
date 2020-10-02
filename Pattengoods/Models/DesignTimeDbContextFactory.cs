using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Pattengoods.Models
{
  public class PattengoodsContextFactory : IDesignTimeDbContextFactory<PattengooodsContext>
  {
    PattengoodsContext IDesignTimeDbContextFactory<PattengoodsContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
      
      var builder = new DbContextOptionsBuilder<PattengoodsContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new PattengoodsContext(builder.Options);
    }
  }
}