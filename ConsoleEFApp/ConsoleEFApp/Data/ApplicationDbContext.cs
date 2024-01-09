using ConsoleEFApp.Data.Entities;
using ConsoleEFApp.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Breed> Breeds { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BreedConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.UseHiLo();
    }
}