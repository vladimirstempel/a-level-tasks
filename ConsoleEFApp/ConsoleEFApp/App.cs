using ConsoleEFApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ConsoleEFApp;

public class App
{
    private readonly ApplicationDbContext _dbContext;

    public App(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Start()
    {
        var data = await _dbContext.Pets.ToListAsync();

        var dataString = string.Join(", ", data.Select(d => d.Name));
        
        Console.WriteLine("Data from DB: {0}", dataString.Length > 0 ? dataString : "Database created, but empty");
    }
}