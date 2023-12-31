using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConsoleEFApp.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        var config = builder.Build();
        
        var connectorString = config.GetConnectionString("DbConnection");

        optionsBuilder.UseSqlServer(connectorString,
            opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}